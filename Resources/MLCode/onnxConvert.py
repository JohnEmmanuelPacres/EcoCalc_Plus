import joblib
from skl2onnx import convert_sklearn
from skl2onnx.common.data_types import FloatTensorType


def convert_to_onnx(model_path="carbon_footprint_model.pkl", onnx_path="carbon_footprint_model.onnx"):
    try:
        # Load the saved model data
        model_data = joblib.load(model_path)
        model = model_data['model']

        # Print model metadata for verification
        print("Model Metadata:")
        print(f"Features: {model_data['metadata']['feature_names']}")
        print(f"Training samples: {model_data['metadata']['training_samples']}")
        print(f"Test RMSE: {model_data['metadata']['test_rmse']:.2f}")

        # Define input type (4 features)
        initial_type = [('float_input', FloatTensorType([None, 4]))]

        # Convert the model
        onnx_model = convert_sklearn(
            model,
            initial_types=initial_type,
            target_opset=12
        )

        # Save the ONNX model
        with open(onnx_path, "wb") as f:
            f.write(onnx_model.SerializeToString())

        print(f"\nModel successfully converted to ONNX and saved to {onnx_path}")
        return True

    except Exception as e:
        print(f"\nONNX conversion failed: {str(e)}")
        return False


if __name__ == "__main__":
    convert_to_onnx()