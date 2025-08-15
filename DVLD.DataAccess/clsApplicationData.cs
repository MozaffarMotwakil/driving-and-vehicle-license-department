using System;
using System.Data.SqlClient;
using DVLD.Entities;

namespace DVLD.DataAccess
{
    public class clsApplicationData
    {
        public static bool IsApplicationExist(int ApplicationID)
        {
            using (SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString))
            {
                string query = @"SELECT 1 
                                FROM Applications
                                WHERE ApplicationID = @ApplicationID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

                try
                {
                    connection.Open();

                    return command.ExecuteScalar() != null;
                }
                catch (Exception ex)
                {
                    throw new ApplicationException($"Error: check is Application exist by ID.\n{ex.Message}", ex);
                }
            }
        }

        public static clsApplicationEntity FindApplicationByID(int ApplicationID)
        {
            clsApplicationEntity ApplicationEntity = null;

            using (SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString))
            {
                string query = @"SELECT * 
                                FROM Applications 
                                WHERE ApplicationID = @ApplicationID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

                try
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            ApplicationEntity = new clsApplicationEntity();

                            ApplicationEntity.ApplicationID = ApplicationID;
                            ApplicationEntity.PersonID = Convert.ToInt32(reader["ApplicantPersonID"]);
                            ApplicationEntity.TypeID = Convert.ToInt32(reader["ApplicationTypeID"]);
                            ApplicationEntity.StatusID = Convert.ToInt32(reader["ApplicationStatusID"]);
                            ApplicationEntity.CreatedByUserID = Convert.ToInt32(reader["CreatedByUserID"]);
                            ApplicationEntity.CreatedDate = Convert.ToDateTime(reader["ApplicationDate"]);
                            ApplicationEntity.LastStatusDate = Convert.ToDateTime(reader["LastStatusDate"]);
                            ApplicationEntity.PaidFees = Convert.ToSingle(reader["PaidFees"]);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new ApplicationException($"Error: find Application by ID.\n{ex.Message}", ex);
                }
            }

            return ApplicationEntity;
        }

        public static bool AddNewApplication(clsApplicationEntity ApplicationEntity)
        {
            using (SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString))
            {
                string query = @"
                    INSERT INTO Applications (
                    ApplicantPersonID, ApplicationTypeID, ApplicationStatusID, 
                    CreatedByUserID, ApplicationDate, LastStatusDate, PaidFees
                    )
                    VALUES
                    (
	                    @PersonID, @TypeID, @StatusID, @CreatedByUserID,
	                    @CreatedDate, @LastStatusDate, @PaidFees
                    );
                    SELECT SCOPE_IDENTITY();";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@PersonID", ApplicationEntity.PersonID);
                command.Parameters.AddWithValue("@TypeID", ApplicationEntity.TypeID);
                command.Parameters.AddWithValue("@StatusID", ApplicationEntity.StatusID);
                command.Parameters.AddWithValue("@CreatedByUserID", ApplicationEntity.CreatedByUserID);
                command.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
                command.Parameters.AddWithValue("@LastStatusDate", DateTime.Now);
                command.Parameters.AddWithValue("@PaidFees", ApplicationEntity.PaidFees);
                
                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != null)
                    {
                        ApplicationEntity.ApplicationID = Convert.ToInt32(result);
                        return true;
                    }

                    return false;
                }
                catch (Exception ex)
                {
                    throw new ApplicationException($"Error: add a new Application.\n{ex.Message}", ex);
                }
            }
        }

        public static bool DeleteApplication(int ApplicationID)
        {
            using (SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString))
            {
                string query = @"DELETE FROM Applications 
                                WHERE ApplicationID = @ApplicationID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

                try
                {
                    connection.Open();

                    return command.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    throw new ApplicationException($"Error: delete a Application.\n{ex.Message}", ex);
                }
            }
        }

        public static bool UpdateApplication(clsApplicationEntity ApplicationEntity)
        {
            using (SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString))
            {
                string query = @"UPDATE Applications
                                SET
	                                ApplicantPersonID = @PersonID, ApplicationTypeID = @TypeID, ApplicationStatusID = @StatusID, 
                                    CreatedByUserID = @CreatedByUserID, PaidFees = @PaidFees
                                WHERE ApplicationID = @ApplicationID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ApplicationID", ApplicationEntity.ApplicationID);
                command.Parameters.AddWithValue("@PersonID", ApplicationEntity.PersonID);
                command.Parameters.AddWithValue("@TypeID", ApplicationEntity.TypeID);
                command.Parameters.AddWithValue("@StatusID", ApplicationEntity.StatusID);
                command.Parameters.AddWithValue("@CreatedByUserID", ApplicationEntity.CreatedByUserID);
                command.Parameters.AddWithValue("@PaidFees", ApplicationEntity.PaidFees);

                try
                {
                    connection.Open();

                    return command.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {

                    throw new ApplicationException($"Error: update a Application.\n{ex.Message}", ex);
                }
            }
        }

        public static bool UpdateStatus(int ApplicationID, int ApplicationStatusID)
        {
            using (SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString))
            {
                string query = @"UPDATE Applications
                                SET
                                    ApplicationStatusID = @ApplicationStatusID,
                                    LastStatusDate = @CurrentDateTime
                                WHERE ApplicationID = @ApplicationID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                command.Parameters.AddWithValue("@ApplicationStatusID", ApplicationStatusID);
                command.Parameters.AddWithValue("@CurrentDateTime", DateTime.Now);

                try
                {
                    connection.Open();
                    return command.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    throw new ApplicationException($"Error: update application status.\n{ex.Message}", ex);
                }
            }
        }

        public static int GetActiveApplicationID(int PersonID, int ApplicationTypeID)
        {
            using (SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString))
            {
                string query = @"SELECT 
                                    ApplicationID
                                FROM 
                                    Applications
                                WHERE
                                    ApplicantPersonID = @PersonID
                                    AND ApplicationTypeID = @ApplicationTypeID
                                    AND ApplicationStatusID = 1";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@PersonID", PersonID);
                command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);

                try
                {
                    connection.Open();

                    object result = command.ExecuteScalar();

                    if (result != null && int.TryParse(result.ToString(), out int applicationID))
                    {
                        return applicationID;
                    }

                    return -1;
                }
                catch (Exception ex)
                {
                    throw new ApplicationException($"Error: get active application ID.\n{ex.Message}", ex);
                }
            }
        }

    }
}
