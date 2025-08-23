using System;
using System.Data;
using System.Data.SqlClient;
using DVLD.Entities;

namespace DVLD.DataAccess
{
    public static class clsDetainedLicenseData
    {
        public static bool IsLicenseDetained(int LicenseID)
        {
            using (SqlConnection connection= new SqlConnection(clsDataSettings.ConnectionString))
            {
                string query = @"SELECT 1
                                 FROM 
                                     DetainedLicenses 
                                 WHERE 
                                     LicenseID = @LicenseID
                                     AND IsReleased = 0";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@LicenseID", LicenseID);

                try
                {
                    connection.Open();
                    return command.ExecuteScalar() != null;
                }
                catch (Exception ex)
                {
                    throw new ApplicationException($"Error: check is license detained.\n{ex.Message}", ex);
                }
            }
        }

        public static clsDetainedLicenseEntity FindDetainedLicense(int LicenseID)
        {
            clsDetainedLicenseEntity detainedLicenseEntity = null;

            using (SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString))
            {
                string query = @"SELECT * 
                                FROM 
                                    DetainedLicenses 
                                WHERE 
                                    LicenseID = @LicenseID
                                    AND IsReleased = 0";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@LicenseID", LicenseID);

                try
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            detainedLicenseEntity = new clsDetainedLicenseEntity();

                            detainedLicenseEntity.DetainID = Convert.ToInt32(reader["DetainID"]);
                            detainedLicenseEntity.LicenseID = LicenseID;
                            detainedLicenseEntity.DetainDate = Convert.ToDateTime(reader["DetainDate"]);
                            detainedLicenseEntity.FineFees = Convert.ToSingle(reader["FineFees"]);
                            detainedLicenseEntity.CreatedByUserID = Convert.ToInt32(reader["CreatedByUserID"]);
                            detainedLicenseEntity.IsReleased = Convert.ToBoolean(reader["IsReleased"]);

                            if (reader["ReleaseDate"] == DBNull.Value)
                            {
                                detainedLicenseEntity.ReleaseDate = DateTime.MinValue;
                            }
                            else
                            {
                                detainedLicenseEntity.ReleaseDate = Convert.ToDateTime(reader["ReleaseDate"]);
                            }

                            if (reader["ReleaseApplicationID"] == DBNull.Value)
                            {
                                detainedLicenseEntity.ReleaseApplicationID = -1;
                            }
                            else
                            {
                                detainedLicenseEntity.ReleaseApplicationID = Convert.ToInt32(reader["ReleaseApplicationID"]);
                            }

                            if (reader["ReleasedByUserID"] == DBNull.Value)
                            {
                                detainedLicenseEntity.ReleasedByUserID = -1;
                            }
                            else
                            {
                                detainedLicenseEntity.ReleasedByUserID = Convert.ToInt32(reader["ReleasedByUserID"]);
                            }

                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new ApplicationException($"Error: find detained license by ID.\n{ex.Message}", ex);
                }
            }

            return detainedLicenseEntity;
        }

        public static int DetainLicense(int LicenseID, DateTime DetainDate, float FineFees, int CreatedByUserID)
        {
            using (SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString))
            {
                string query = @"INSERT INTO DetainedLicenses 
                                 (
                                     LicenseID, DetainDate, FineFees, CreatedByUserID
                                 )
                                 VALUES
                                 (
                                    @LicenseID, @DetainDate, @FineFees, @CreatedByUserID
                                 );
                                 SELECT SCOPE_IDENTITY();";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("LicenseID", LicenseID);
                command.Parameters.AddWithValue("DetainDate", DetainDate);
                command.Parameters.AddWithValue("FineFees", FineFees);
                command.Parameters.AddWithValue("CreatedByUserID", CreatedByUserID);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != null && int.TryParse(result.ToString(), out int detainID))
                    {
                        return detainID;
                    }

                    return -1;
                }
                catch (Exception ex)
                {
                    throw new ApplicationException($"Error: add new detained license.\n{ex.Message}", ex);
                }
            }
        }

        public static bool ReleaseDetainedLicense(int LicenseID, DateTime ReleaseDate, int ReleasedByUserID, int ReleaseApplicationID)
        {
            using (SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString))
            {
                string query = @"UPDATE DetainedLicenses
                                 SET
                                    IsReleased = 1,
                                    ReleaseDate = @ReleaseDate,
                                    ReleasedByUserID = @ReleasedByUserID,
                                    ReleaseApplicationID = @ReleaseApplicationID
                                 WHERE
                                    LicenseID = @LicenseID
                                    AND IsReleased = 0";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@LicenseID", LicenseID);
                command.Parameters.AddWithValue("@ReleaseDate", ReleaseDate);
                command.Parameters.AddWithValue("@ReleasedByUserID", ReleasedByUserID);
                command.Parameters.AddWithValue("@ReleaseApplicationID", ReleaseApplicationID);

                try
                {
                    connection.Open();
                    return command.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    throw new ApplicationException($"Error: release detained license.\n{ex.Message}", ex);
                }
            }
        }

        public static DataTable GetAllDetainedLicenses()
        {
            DataTable detainedLicenses = null;

            using (SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString))
            {
                string query = "SELECT * FROM DetainedLicensesDetailed ORDER BY DetainID DESC";

                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            detainedLicenses = new DataTable();
                            detainedLicenses.Load(reader);
                        }
                    }

                    return detainedLicenses;
                }
                catch (Exception ex)
                {
                    throw new ApplicationException($"Error: get all detained licenses.\n{ex.Message}", ex);
                }
            }
        }

    }
}