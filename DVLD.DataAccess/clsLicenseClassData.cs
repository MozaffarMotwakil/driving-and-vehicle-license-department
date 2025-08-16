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

    }
}
