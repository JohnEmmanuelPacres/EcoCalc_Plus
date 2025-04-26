using System.Data;
using System.Data.OleDb;

namespace EcoCalc_Plus.UtilityClass
{
    public static class DatabaseHelper
    {
        private static string _connectionString = "";

        public static string ConnectionString
        {
            get
            {
                if (string.IsNullOrEmpty(_connectionString))
                {
                    string outputPath = Path.Combine(Application.StartupPath, "Resources", "EcoCalcPlus_Database.accdb");
                    string sourcePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                        "C:\\src\\PACRES_CPE 262_Final Project\\EcoCalc Plus\\Resources", "EcoCalcPlus_Database.accdb");

                    if (File.Exists(outputPath))
                    {
                        _connectionString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={outputPath}";
                    }
                    else if (File.Exists(sourcePath))
                    {
                        _connectionString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={sourcePath}";
                    }
                    else
                    {
                        throw new FileNotFoundException("Database file not found in either location");
                    }
                }
                return _connectionString;
            }
        }

        public static bool DatabaseExists()
        {
            string databasePath = Path.Combine(Application.StartupPath, "Resources", "EcoCalcPlus_Database.accdb");
            return File.Exists(databasePath);
        }

        public static void InsertFootprint(int userId, double vehicularEmission, 
            double homeEnergyEmission, double applianceEmission, double wasteEmission)
        {
            if (!DatabaseExists())
            {
                throw new FileNotFoundException("Database file not found");
            }

            double totalEmission = vehicularEmission + homeEnergyEmission + applianceEmission + wasteEmission;

            using (var connection = new OleDbConnection(ConnectionString))
            {
                connection.Open();
                string query = @"INSERT INTO CarbonFootprint 
                    (UserID, VehicularEmission, HomeEnergyEmission, 
                     AppliancesEmission, WasteEmission, TotalEmission, DateRecorded) 
                    VALUES (?, ?, ?, ?, ?, ?, ?)";

                using (var command = new OleDbCommand(query, connection))
                {
                    command.Parameters.Add("@UserID", OleDbType.Integer).Value = userId;
                    command.Parameters.Add("@VehicularEmission", OleDbType.Decimal).Value = (decimal)vehicularEmission;
                    command.Parameters.Add("@HomeEnergyEmission", OleDbType.Decimal).Value = (decimal)homeEnergyEmission;
                    command.Parameters.Add("@AppliancesEmission", OleDbType.Decimal).Value = (decimal)applianceEmission;
                    command.Parameters.Add("@WasteEmission", OleDbType.Decimal).Value = (decimal)wasteEmission;
                    command.Parameters.Add("@TotalEmission", OleDbType.Decimal).Value = (decimal)totalEmission;
                    command.Parameters.Add("@DateRecorded", OleDbType.Date).Value = DateTime.Now;

                    command.ExecuteNonQuery();
                }
            }
        }

        public static bool StoreResetToken(string email, string token, DateTime expiration)
        {
            try
            {
                using (var connection = new OleDbConnection(ConnectionString))
                {
                    connection.Open();
                    string query = @"UPDATE [Users] 
                   SET [ResetToken] = ?, [TokenExpiration] = ?
                   WHERE [Email] = ?";

                    using (var command = new OleDbCommand(query, connection))
                    {
                        command.Parameters.Add("@ResetToken", OleDbType.VarChar, 100).Value = token;
                        command.Parameters.Add("@TokenExpiration", OleDbType.Date).Value = expiration;
                        command.Parameters.Add("@Email", OleDbType.VarChar, 100).Value = email;

                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error storing token: {ex.Message}");
                return false;
            }
        }

        public static (string Token, DateTime Expiration)? GetResetToken(string email)
        {
            try
            {
                using (var connection = new OleDbConnection(ConnectionString))
                {
                    connection.Open();
                    string query = @"SELECT [ResetToken], [TokenExpiration] 
                   FROM [Users] 
                   WHERE [Email] = ?";

                    using (var command = new OleDbCommand(query, connection))
                    {
                        command.Parameters.Add("@Email", OleDbType.VarChar).Value = email;

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Check for DBNull and that columns exist
                                int tokenOrdinal = reader.GetOrdinal("ResetToken");
                                int expOrdinal = reader.GetOrdinal("TokenExpiration");

                                if (!reader.IsDBNull(tokenOrdinal) && !reader.IsDBNull(expOrdinal))
                                {
                                    return (
                                        reader.GetString(tokenOrdinal),
                                        reader.GetDateTime(expOrdinal)
                                    );
                                }
                            }
                            return null;
                        }
                    }
                }
            }
            catch
            {
                return null;
            }
        }

        public static bool UpdatePassword(string email, string hashedPassword)
        {
            try
            {
                using (var connection = new OleDbConnection(ConnectionString))
                {
                    connection.Open();
                    string query = "UPDATE [Users] SET [Password] = ? WHERE [Email] = ?";

                    using (var command = new OleDbCommand(query, connection))
                    {
                        command.Parameters.Add("@Password", OleDbType.VarChar).Value = hashedPassword;
                        command.Parameters.Add("@Email", OleDbType.VarChar).Value = email;
                        return command.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        public static bool ClearResetToken(string email)
        {
            try
            {
                using (var connection = new OleDbConnection(ConnectionString))
                {
                    connection.Open();
                    string query = @"UPDATE [Users] 
                           SET [ResetToken] = NULL, [TokenExpiration] = NULL
                           WHERE [Email] = ?";

                    using (var command = new OleDbCommand(query, connection))
                    {
                        command.Parameters.Add("@Email", OleDbType.VarChar).Value = email;
                        return command.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        public static bool EmailExists(string email)
        {
            try
            {
                using (var connection = new OleDbConnection(ConnectionString))
                {
                    connection.Open();
                    string query = "SELECT COUNT(*) FROM [Users] WHERE [Email] = ?";

                    using (var command = new OleDbCommand(query, connection))
                    {
                        command.Parameters.Add("@Email", OleDbType.VarChar).Value = email;
                        return (int)command.ExecuteScalar() > 0;
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        public static DataTable GetDataTable(string query)
        {
            using (OleDbConnection connection = new OleDbConnection(ConnectionString))
            using (OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection))
            {
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                return dataTable;
            }
        }
    }
}
