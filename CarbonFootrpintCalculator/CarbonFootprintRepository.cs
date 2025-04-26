using System;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Windows.Forms;
using EcoCalc_Plus.UtilityClass; 

namespace EcoCalc_Plus.CarbonFootrpintCalculator
{
    class CarbonFootprintRepository
    {
        private bool _disposed;
        private OleDbConnection _openConnection;
        public int GetUserId(string username)
        {
            if (string.IsNullOrEmpty(username)) return 0;

            try
            {
                using (var connection = new OleDbConnection(DatabaseHelper.ConnectionString))
                {
                    connection.Open();
                    string query = "SELECT UserID FROM Users WHERE Username = ?";

                    using (var command = new OleDbCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", username);
                        var result = command.ExecuteScalar();
                        return result != null ? Convert.ToInt32(result) : 0;
                    }
                }
            }
            catch
            {
                return 0;
            }
        }

        public string GetUserSex(int userId)
        {
            if (userId <= 0) return string.Empty;

            try
            {
                using (var connection = new OleDbConnection(DatabaseHelper.ConnectionString))
                {
                    connection.Open();
                    string query = "SELECT Sex FROM Users WHERE UserID = ?";

                    using (var command = new OleDbCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserID", userId);
                        var result = command.ExecuteScalar();
                        return result?.ToString() ?? string.Empty;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving user sex: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                return string.Empty;
            }
        }

        public bool SaveFootprint(int userId, double vehicle, double homeEnergy, double appliance, double waste)
        {
            if (!DatabaseHelper.DatabaseExists())
            {
                MessageBox.Show("Database file not found at: " + Path.Combine(Application.StartupPath, "Resources", "EcoCalcPlus_Database.accdb"),
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            try
            {
                DatabaseHelper.InsertFootprint(userId, vehicle, homeEnergy, appliance, waste);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving footprint: {ex.Message}\n\nStack Trace:\n{ex.StackTrace}",
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public DataTable GetUserFootprintHistory(int userId)
        {
            DataTable table = new DataTable();

            try
            {
                _openConnection = new OleDbConnection(DatabaseHelper.ConnectionString);
                _openConnection.Open();
                using (var connection = new OleDbConnection(DatabaseHelper.ConnectionString))
                {
                    connection.Open();
                    string query = @"SELECT FootprintID, VehicularEmission, HomeEnergyEmission, 
                    AppliancesEmission, WasteEmission, TotalEmission, DateRecorded 
                    FROM CarbonFootprint 
                    WHERE UserID = ? 
                    ORDER BY DateRecorded DESC";

                    using (var command = new OleDbCommand(query, connection))
                    {
                        command.Parameters.Add("@UserID", OleDbType.Integer).Value = userId;

                        using (var adapter = new OleDbDataAdapter(command))
                        {
                            int rows = adapter.Fill(table);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading footprint history: {ex.Message}");
            }
            finally
            {
                Dispose();
            }

            return table;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    // Dispose managed resources
                    if (_openConnection != null)
                    {
                        if (_openConnection.State != ConnectionState.Closed)
                        {
                            try
                            {
                                _openConnection.Close();
                            }
                            catch (Exception e)
                            {
                                MessageBox.Show($"Error: {e}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        _openConnection.Dispose();
                        _openConnection = null;
                    }
                }
                _disposed = true;
            }
        }

        ~CarbonFootprintRepository()
        {
            Dispose(false);
        }

        public bool DeleteFootprint(int footprintId)
        {
            try
            {
                using (var connection = new OleDbConnection(DatabaseHelper.ConnectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM CarbonFootprint WHERE FootprintID = ?";

                    using (var command = new OleDbCommand(query, connection))
                    {
                        command.Parameters.Add("@FootprintID", OleDbType.Integer).Value = footprintId;
                        return command.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateFootprint(int footprintId, double vehicle, double homeEnergy, double appliance, double waste)
        {
            try
            {
                double total = vehicle + homeEnergy + appliance + waste;

                using (var connection = new OleDbConnection(DatabaseHelper.ConnectionString))
                {
                    connection.Open();
                    string query = @"UPDATE CarbonFootprint 
                            SET VehicularEmission = ?, 
                                HomeEnergyEmission = ?, 
                                AppliancesEmission = ?, 
                                WasteEmission = ?, 
                                TotalEmission = ?
                            WHERE FootprintID = ?";

                    using (var command = new OleDbCommand(query, connection))
                    {
                        command.Parameters.Add("@Vehicle", OleDbType.Double).Value = vehicle;
                        command.Parameters.Add("@HomeEnergy", OleDbType.Double).Value = homeEnergy;
                        command.Parameters.Add("@Appliances", OleDbType.Double).Value = appliance;
                        command.Parameters.Add("@Waste", OleDbType.Double).Value = waste;
                        command.Parameters.Add("@Total", OleDbType.Double).Value = total;
                        command.Parameters.Add("@FootprintID", OleDbType.Integer).Value = footprintId;

                        return command.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteUserAccount(int userId)
        {
            if (userId == 0) return false;
            try
            {
                using (var connection = new OleDbConnection(DatabaseHelper.ConnectionString))
                {
                    connection.Open();
                    using (var transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            string deleteFootprintsQuery = "DELETE FROM CarbonFootprint WHERE UserID = ?";
                            using (var command = new OleDbCommand(deleteFootprintsQuery, connection, transaction))
                            {
                                command.Parameters.Add("@UserID", OleDbType.Integer).Value = userId;
                                command.ExecuteNonQuery();
                            }
                            string deleteUserQuery = "DELETE FROM Users WHERE UserID = ?";
                            using (var command = new OleDbCommand(deleteUserQuery, connection, transaction))
                            {
                                command.Parameters.Add("@UserID", OleDbType.Integer).Value = userId;
                                int rowsAffected = command.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                    transaction.Commit();
                                    return true;
                                }
                                else
                                {
                                    transaction.Rollback();
                                    return false;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting account: {ex.Message}", "Error",
                      MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool SavePrediction(int userId, double metricTons, double pounds)
        {
            try
            {
                // Get the most recent footprint ID for this user
                int footprintId = GetMostRecentFootprintId(userId);
                if (footprintId <= 0) return false;

                using (var connection = new OleDbConnection(DatabaseHelper.ConnectionString))
                {
                    connection.Open();
                    string query = @"INSERT INTO [Prediction] 
                           ([UserID], [FootprintID], [PredictionValue(MetricTons)], 
                            [PredictionValue(Pounds)], [PredictionDate]) 
                           VALUES (?, ?, ?, ?, ?)";

                    using (var command = new OleDbCommand(query, connection))
                    {
                        command.Parameters.Add("@UserID", OleDbType.Integer).Value = userId;
                        command.Parameters.Add("@FootprintID", OleDbType.Integer).Value = footprintId;
                        command.Parameters.Add("@MetricTons", OleDbType.Double).Value = metricTons;
                        command.Parameters.Add("@Pounds", OleDbType.Double).Value = pounds;
                        command.Parameters.Add("@PredictionDate", OleDbType.Date).Value = DateTime.Now;

                        return command.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving prediction: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public int GetMostRecentFootprintId(int userId)
        {
            try
            {
                using (var connection = new OleDbConnection(DatabaseHelper.ConnectionString))
                {
                    connection.Open();
                    string query = @"SELECT TOP 1 [FootprintID] FROM [CarbonFootprint] 
                            WHERE [UserID] = ?
                            ORDER BY [DateRecorded] DESC";

                    using (var command = new OleDbCommand(query, connection))
                    {
                        command.Parameters.Add("@UserID", OleDbType.Integer).Value = userId;
                        object result = command.ExecuteScalar();

                        if (result != null)
                        {
                            return Convert.ToInt32(result);
                        }
                    }

                    // If no footprint exists, return -1 (you might want to handle this case differently)
                    return -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error getting footprint ID: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }


        public DataTable GetPredictionHistory(int userId)
        {
            DataTable table = new DataTable();
            try
            {
                using (var connection = new OleDbConnection(DatabaseHelper.ConnectionString))
                {
                    connection.Open();

                    // Modified query with proper syntax for MS Access
                    string query = @"SELECT 
                p.PredictionID, 
                p.FootprintID,
                p.[PredictionValue(MetricTons)] AS MetricTons, 
                p.[PredictionValue(Pounds)] AS Pounds, 
                p.PredictionDate,
                c.VehicularEmission,
                c.HomeEnergyEmission AS HomeEnergy,
                c.AppliancesEmission AS Appliances,
                c.WasteEmission
                FROM [Prediction] AS p
                INNER JOIN [CarbonFootprint] AS c ON p.FootprintID = c.FootprintID
                WHERE p.UserID = ?
                ORDER BY p.PredictionDate DESC";

                    using (var command = new OleDbCommand(query, connection))
                    {
                        command.Parameters.Add("@UserID", OleDbType.Integer).Value = userId;

                        using (var adapter = new OleDbDataAdapter(command))
                        {
                            adapter.Fill(table);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Database Error: {ex.Message}",
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return table;
        }

        public bool DeletePrediction(int predictionId)
        {
            try
            {
                using (var connection = new OleDbConnection(DatabaseHelper.ConnectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM [Prediction] WHERE [PredictionID] = ?";

                    using (var command = new OleDbCommand(query, connection))
                    {
                        command.Parameters.Add("@PredictionID", OleDbType.Integer).Value = predictionId;
                        return command.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting prediction: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool DeletePredictions(List<int> predictionIds)
        {
            try
            {
                using (var connection = new OleDbConnection(DatabaseHelper.ConnectionString))
                {
                    connection.Open();
                    using (var transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            string query = "DELETE FROM [Prediction] WHERE [PredictionID] = ?";

                            foreach (int id in predictionIds)
                            {
                                using (var command = new OleDbCommand(query, connection, transaction))
                                {
                                    command.Parameters.Add("@PredictionID", OleDbType.Integer).Value = id;
                                    command.ExecuteNonQuery();
                                }
                            }

                            transaction.Commit();
                            return true;
                        }
                        catch
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting predictions: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}