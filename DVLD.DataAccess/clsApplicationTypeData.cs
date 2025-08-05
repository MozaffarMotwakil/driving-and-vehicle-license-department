using System;
using System.Data;
using System.Data.SqlClient;
using DVLD.Entities;

namespace DVLD.DataAccess
{
    public class clsApplicationTypeData
    {

        public static clsApplicationTypeEntity FindApplicationTypeByID(int ApplicationTypeID)
        {
            clsApplicationTypeEntity applicationTypeEntity = null;

            using (SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString))
            {
                string query = @"SELECT * 
                                FROM ApplicationTypes 
                                WHERE ApplicationTypeID = @ApplicationTypeID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);

                try
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            applicationTypeEntity = new clsApplicationTypeEntity(
                                ApplicationTypeID,
                                reader["ApplicationTypeTitle"].ToString(),
                                Convert.ToSingle(reader["ApplicationFees"])
                                );
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new ApplicationException($"Error: find application type by ID.\n{ex.Message}", ex);
                }
            }

            return applicationTypeEntity;
        }

        public static DataTable GetAllApplicationTypes()
        {
            DataTable applicationTypes = null;

            using (SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString))
            {
                string query = "SELECT * FROM ApplicationTypes";
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            applicationTypes = new DataTable();
                            applicationTypes.Load(reader);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new ApplicationException($"Error: get all application types.\n{ex.Message}", ex);
                }

            }

            return applicationTypes;
        }

        public static bool UpdateApplicationType(clsApplicationTypeEntity applicationTypeEntity) 
        {
            using (SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString))
            {
                string query =
                    @"UPDATE ApplicationTypes 
                    SET
                    ApplicationTypeTitle = @ApplicationTypeTitle,
                    ApplicationFees = @ApplicationFees
                    WHERE ApplicationTypeID = @ApplicationTypeID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ApplicationTypeID", applicationTypeEntity.TypeID);
                command.Parameters.AddWithValue("@ApplicationTypeTitle", applicationTypeEntity.Title);
                command.Parameters.AddWithValue("@ApplicationFees", applicationTypeEntity.Fees);

                try
                {
                    connection.Open();

                    return command.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    throw new ApplicationException($"Error: update application type.\n{ex.Message}", ex);
                }

            }
        }

    }
}
