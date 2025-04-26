import pandas as pd
from sklearn.ensemble import RandomForestRegressor
from sklearn.model_selection import train_test_split, cross_val_score
from sklearn.metrics import r2_score, mean_squared_error
import joblib
import pyodbc
import os
import numpy as np

def get_carbon_data():
    db_path = r"C:\src\PACRES_CPE 262_Final Project\EcoCalc Plus\bin\Debug\net8.0-windows\EcoCalcPlus_Database.accdb"

    if not os.path.exists(db_path):
        print(f"Error: Database file not found at {db_path}")
        return None

    conn_str = (
        r'DRIVER={Microsoft Access Driver (*.mdb, *.accdb)};'
        f'DBQ={db_path};'
    )

    try:
        with pyodbc.connect(conn_str) as conn:
            cursor = conn.cursor()
            cursor.execute("SELECT TOP 1 * FROM UserCarbonFootprint")
            columns = [column[0] for column in cursor.description]
            print("Database columns found:", columns)

            query = """
                SELECT VehicularEmission, HomeEnergyEmission, AppliancesEmission, WasteEmission, TotalEmission
                FROM UserCarbonFootprint
                WHERE UserID IS NOT NULL
                """
            cursor.execute(query)
            rows = cursor.fetchall()
            df = pd.DataFrame.from_records(rows, columns=[column[0] for column in cursor.description])

            # Data cleaning
            for col in df.columns:
                df[col] = pd.to_numeric(df[col], errors='coerce')

            # Remove outliers using IQR
            Q1 = df.quantile(0.25)
            Q3 = df.quantile(0.75)
            IQR = Q3 - Q1
            df = df[~((df < (Q1 - 1.5 * IQR)) | (df > (Q3 + 1.5 * IQR))).any(axis=1)]
            df = df.dropna()
            df = df.astype('int64')

            print(f"Retrieved {len(df)} records after cleaning")
            print("Sample data:\n", df.head())
            return df

    except Exception as e:
        print(f"Database error: {e}")
        return None


def train_and_save_model(X, y, model_name="carbon_footprint_model.pkl"):
    try:
        feature_names = X.columns.tolist()

        # Split data
        X_train, X_test, y_train, y_test = train_test_split(
            X.values,
            y.values,
            test_size=0.2,
            random_state=42,
            shuffle=True
        )

        # Model Configuration - optimized for speed and precision
        model = RandomForestRegressor(
            n_estimators=100,  # Reduced for faster computation
            max_depth=10,  # Limited depth for faster prediction
            min_samples_split=5,
            min_samples_leaf=2,
            max_features=0.8,  # Slightly reduced for speed
            max_samples=0.7,
            bootstrap=True,
            oob_score=True,
            n_jobs=-1,
            random_state=42,
            verbose=1
        )

        # Cross-validation
        print("\nTraining model with cross-validation...")
        cv_scores = cross_val_score(
            model,
            X_train,
            y_train,
            cv=5,
            scoring='neg_root_mean_squared_error',
            n_jobs=-1
        )
        cv_rmse = -cv_scores
        print(f"Cross-validation RMSE: {np.mean(cv_rmse):.2f} (±{np.std(cv_rmse):.2f})")

        # Final training
        model.fit(X_train, y_train)

        # Evaluation
        print("\nModel Evaluation:")
        for name, X_data, y_data in [('Training', X_train, y_train),
                                     ('Testing', X_test, y_test)]:
            pred = model.predict(X_data)
            r2 = r2_score(y_data, pred)
            rmse = np.sqrt(mean_squared_error(y_data, pred))
            print(f"{name} Set:")
            print(f"  R²: {r2:.4f}")
            print(f"  RMSE: {rmse:.2f}")
            print(f"  Prediction range: {pred.min():.2f} to {pred.max():.2f}")

        # Scale target if RMSE is too high
        if rmse > 2.0:  # If RMSE is too large
            print("\nAdjusting model for better precision...")
            y_mean, y_std = y_train.mean(), y_train.std()
            y_train_scaled = (y_train - y_mean) / y_std

            model.fit(X_train, y_train_scaled)
            pred_scaled = model.predict(X_test)
            pred = pred_scaled * y_std + y_mean
            rmse = np.sqrt(mean_squared_error(y_test, pred))
            print(f"Adjusted Test RMSE: {rmse:.2f}")

        # Save model
        joblib.dump({
            'model': model,
            'metadata': {
                'feature_names': feature_names,
                'training_samples': len(X_train),
                'cv_rmse_mean': np.mean(cv_rmse),
                'test_rmse': rmse,
                'y_mean': y_mean if 'y_mean' in locals() else None,
                'y_std': y_std if 'y_std' in locals() else None
            }
        }, model_name)

        print(f"\nModel successfully saved to {model_name}")
        return True

    except Exception as e:
        print(f"\nModel training failed: {str(e)}", exc_info=True)
        return False


def use_fallback_data():
    np.random.seed(42)  # Fixed seed for reproducibility
    n_samples = 20000  # Reduced sample size for faster training

    # Generate more consistent data with lower variance
    vehicular = np.random.lognormal(mean=3.0, sigma=0.5, size=n_samples)
    home_energy = vehicular * np.random.normal(0.7, 0.1, n_samples)
    appliances = vehicular * np.random.normal(0.2, 0.02, n_samples)
    waste = vehicular * np.random.normal(0.1, 0.01, n_samples)
    total = vehicular + home_energy + appliances + waste

    df = pd.DataFrame({
        "VehicularEmission": vehicular,
        "HomeEnergyEmission": home_energy,
        "AppliancesEmission": appliances,
        "WasteEmission": waste,
        "TotalEmission": total
    })

    # Round to integers
    df = df.round().astype('int64')
    print(f"\nGenerated {len(df):,} consistent records")
    return df


if __name__ == "__main__":
    print("Starting model training...")

    carbon_data = get_carbon_data()
    if carbon_data is None or carbon_data.empty:
        carbon_data = use_fallback_data()

    X = carbon_data[["VehicularEmission", "HomeEnergyEmission",
                     "AppliancesEmission", "WasteEmission"]]
    y = carbon_data["TotalEmission"]

    print("\nCorrelation matrix:")
    print(carbon_data.corr())

    train_and_save_model(X, y)