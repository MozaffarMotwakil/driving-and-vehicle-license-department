using System;
using DVLD.Entities;
using System.Data.SqlClient;
using System.Data;

namespace DVLD.DataAccess
{
    public class clsLicenseClassData
    {
        public static clsLicenseClassEntity FindLicenseClassByID(int LicenseClassID)
        {
            clsLicenseClassEntity LicenseClassEntity = null;

            using (SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString))
            {
                string query = @"SELECT * 
                                FROM LicenseClasses 
                                WHERE LicenseClassID = @LicenseClassID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

                try
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            LicenseClassEntity = new clsLicenseClassEntity(
                                LicenseClassID,
                                reader["ClassName"].ToString(),
                                reader["ClassDescription"].ToString(),
                                Convert.ToByte(reader["MinimumAllowedAge"]),
                                Convert.ToByte(reader["DefaultValidityLength"]),
                                Convert.ToSingle(reader["ClassFees"])
                                );
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new ApplicationException($"Error: find license class by ID.\n{ex.Message}", ex);
                }
            }

            return LicenseClassEntity;
        }

        public static DataTable GetAllLicenseClasses()
        {
            DataTable LicenseClasses = null;

            using (SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString))
            {
                string query = "SELECT * FROM LicenseClasses";
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            LicenseClasses = new DataTable();
                            LicenseClasses.Load(reader);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new ApplicationException($"Error: get all license classes.\n{ex.Message}", ex);
                }

            }

            return LicenseClasses;
        }

        public static bool UpdateLicenseClass(clsLicenseClassEntity LicenseClassEntity)
        {
            using (SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString))
            {
                string query =
                    @"UPDATE LicenseClasses 
                    SET
                    ClassName = @ClassName,
                    ClassDescription = @ClassDescription,
                    MinimumAllowedAge = @MinimumAllowedAge,
                    DefaultValidityLength = @DefaultValidityLength,
                    ClassFees = @ClassFees
                    WHERE LicenseClassID = @LicenseClassID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@LicenseClassID", LicenseClassEntity.LicenseClassID);
                command.Parameters.AddWithValue("@ClassName", LicenseClassEntity.ClassName);
                command.Parameters.AddWithValue("@ClassDescription", LicenseClassEntity.ClassDescription);
                command.Parameters.AddWithValue("@MinimumAllowedAge", LicenseClassEntity.MinimumAllowedAge);
                command.Parameters.AddWithValue("@DefaultValidityLength", LicenseClassEntity.DefaultValidityLength);
                command.Parameters.AddWithValue("@ClassFees", LicenseClassEntity.ClassFees);

                try
                {
                    connection.Open();

                    return command.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    throw new ApplicationException($"Error: update license class.\n{ex.Message}", ex);
                }

            }
        }

    }
}
