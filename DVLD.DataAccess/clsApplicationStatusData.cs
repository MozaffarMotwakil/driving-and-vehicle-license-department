using System;
using System.Data.SqlClient;
using System.Data;
using DVLD.Entities;

namespace DVLD.DataAccess
{
    public class clsApplicationStatusData
    {
        public static DataTable GetAllApplicationStatuses()
        {
            DataTable applicationStatuses = null;

            using (SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString))
            {
                string query = "SELECT ApplicationStatusName FROM ApplicationStatuses";
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            applicationStatuses = new DataTable();
                            applicationStatuses.Load(reader);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new ApplicationException($"Error: get all application statuses.\n{ex.Message}", ex);
                }
            }

            return applicationStatuses;
        }

        public static clsApplicationStatusEntity FindApplicationStatusByID(int ApplicationStatusID)
        {
            clsApplicationStatusEntity ApplicationStatusEntity = null;

            using (SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString))
            {
                string query = @"SELECT *
                                FROM ApplicationStatuses
                                WHERE ApplicationStatusID = @ApplicationStatusID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ApplicationStatusID", ApplicationStatusID);

                try
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            ApplicationStatusEntity = new clsApplicationStatusEntity(
                                ApplicationStatusID,
                                reader["ApplicationStatusName"].ToString()
                                );
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new ApplicationException($"Error: get application status by ID.\n{ex.Message}", ex);
                }
            }

            return ApplicationStatusEntity;
        }

        public static clsApplicationStatusEntity FindApplicationStatusByName(string ApplicationStatusName)
        {
            clsApplicationStatusEntity ApplicationStatusEntity = null;

            using (SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString))
            {
                string query = @"SELECT *
                                FROM ApplicationStatuses
                                WHERE ApplicationStatusName = @ApplicationStatusName";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ApplicationStatusName", ApplicationStatusName);

                try
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            ApplicationStatusEntity = new clsApplicationStatusEntity(
                                Convert.ToInt32(reader["ApplicationStatusID"]),
                                ApplicationStatusName);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new ApplicationException($"Error: get application status by name.\n{ex.Message}", ex);
                }
            }

            return ApplicationStatusEntity;
        }

    }
}
