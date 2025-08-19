using System;
using DVLD.Entities;
using System.Data.SqlClient;
using System.Data;

namespace DVLD.DataAccess
{
    public class clsLocalLicenseApplicationData
    {
        public static bool IsLocalLicenseApplicationExist(int LocalDrivingLicenseApplicationID)
        {
            using (SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString))
            {
                string query = @"SELECT 1 
                                FROM LocalDrivingLicenseApplications
                                WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

                try
                {
                    connection.Open();

                    return command.ExecuteScalar() != null;
                }
                catch (Exception ex)
                {
                    throw new ApplicationException($"Error: check is local driving license application exist by ID.\n{ex.Message}", ex);
                }
            }
        }

        public static int GetActiveApplicationIDForLicenseClass(int PersonID, int LicenseClassID)
        {
            using (SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString))
            {
                string query = @"SELECT 
                                    LocalDrivingLicenseApplicationID
                                FROM 
                                    Applications
                                    INNER JOIN LocalDrivingLicenseApplications ON 
                                        Applications.ApplicationID = LocalDrivingLicenseApplications.ApplicationID
                                WHERE
                                    ApplicantPersonID = @PersonID
                                    AND LicenseClassID = @LicenseClassID
                                    AND ApplicationStatusID = 1";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@PersonID", PersonID);
                command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

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
                    throw new ApplicationException($"Error: get active local license application ID for license class.\n{ex.Message}", ex);
                }
            }
        }

        public static DataTable GetAllLocalLicenseApplications()
        {
            DataTable localDrivingLicenseApplications = null;

            using (SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString))
            {
                string query = "SELECT * FROM LocalDrivingLicenseApplicationsDetailed ORDER BY ApplicationDate DESC";
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            localDrivingLicenseApplications = new DataTable();
                            localDrivingLicenseApplications.Load(reader);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new ApplicationException($"Error: get all local driving license applications.\n{ex.Message}", ex);
                }
            }

            return localDrivingLicenseApplications;
        }

        public static DateTime GetMinimumApplicationDate()
        {
            using (SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString))
            {
                string query = "SELECT MIN(ApplicationDate) FROM LocalDrivingLicenseApplicationsDetailed";
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    object minimumDate = command.ExecuteScalar();

                    if (minimumDate != null)
                    {
                        return Convert.ToDateTime(minimumDate);
                    }

                    return DateTime.Now;
                }
                catch (Exception ex)
                {
                    throw new ApplicationException($"Error: get minimum application date.\n{ex.Message}", ex);
                }
            }
        }
       
        public static DateTime GetMaximumApplicationDate()
        {
            using (SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString))
            {
                string query = "SELECT MAX(ApplicationDate) FROM LocalDrivingLicenseApplicationsDetailed";
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    object maximumDate = command.ExecuteScalar();

                    if (maximumDate != null)
                    {
                        return Convert.ToDateTime(maximumDate);
                    }

                    return DateTime.Now;
                }
                catch (Exception ex)
                {
                    throw new ApplicationException($"Error: get maximum application date.\n{ex.Message}", ex);
                }
            }
        }

        public static clsLocalLicenseApplicationEntity FindLocalLicenseApplicationByID(int LocalLicenseApplicationID)
        {
            clsLocalLicenseApplicationEntity localLicenseApplicationEntity = null;

            using (SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString))
            {
                string query = @"SELECT * 
                                FROM LocalDrivingLicenseApplications 
                                WHERE LocalDrivingLicenseApplicationID = @LocalLicenseApplicationID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@LocalLicenseApplicationID", LocalLicenseApplicationID);

                try
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            localLicenseApplicationEntity = new clsLocalLicenseApplicationEntity();
                            localLicenseApplicationEntity.LocalLicenseApplicationID = LocalLicenseApplicationID;
                            localLicenseApplicationEntity.ApplicationID = Convert.ToInt32(reader["ApplicationID"]);
                            localLicenseApplicationEntity.LicenseClassID = Convert.ToInt32(reader["LicenseClassID"]);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new ApplicationException($"Error: find local license application by ID.\n{ex.Message}", ex);
                }
            }

            return localLicenseApplicationEntity;
        }

        public static bool AddNewLocalLicenseApplication(clsLocalLicenseApplicationEntity LocalLicenseApplicationEntity)
        {
            using (SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString))
            {
                string query = @"
                    INSERT INTO LocalDrivingLicenseApplications
                    (
                        ApplicationID, LicenseClassID
                    )
                    VALUES
                    (
	                    @ApplicationID, @LicenseClassID
                    );
                    SELECT SCOPE_IDENTITY();";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ApplicationID", LocalLicenseApplicationEntity.ApplicationID);
                command.Parameters.AddWithValue("@LicenseClassID", LocalLicenseApplicationEntity.LicenseClassID);

                try
                {
                    connection.Open();
                    object recordID = command.ExecuteScalar();

                    if (recordID != null)
                    {
                        LocalLicenseApplicationEntity.LocalLicenseApplicationID = Convert.ToInt32(recordID);
                        return true;
                    }

                    return false;
                }
                catch (Exception ex)
                {
                    throw new ApplicationException($"Error: add a new local license application.\n{ex.Message}", ex);
                }
            }
        }

        public static bool DeleteLocalLicenseApplication(int LocalLicenseApplicationID)
        {
            using (SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString))
            {
                string query = @"DELETE FROM LocalDrivingLicenseApplications 
                                WHERE LocalDrivingLicenseApplicationID = @LocalLicenseApplicationID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@LocalLicenseApplicationID", LocalLicenseApplicationID);

                try
                {
                    connection.Open();

                    return command.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    throw new ApplicationException($"Error: delete a local license application.\n{ex.Message}", ex);
                }
            }
        }

        public static bool UpdateLicenseClassForLocalLicenseApplication(int LocalLicenseApplicationID, int LicenseClassID)
        {
            using (SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString))
            {
                string query = @"UPDATE LocalDrivingLicenseApplications
                                SET
	                                LicenseClassID = @LicenseClassID
                                WHERE LocalDrivingLicenseApplicationID = @LocalLicenseApplicationID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@LocalLicenseApplicationID", LocalLicenseApplicationID);
                command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

                try
                {
                    connection.Open();

                    return command.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {

                    throw new ApplicationException($"Error: update a local license application.\n{ex.Message}", ex);
                }
            }
        }

        public static int GetPassedTestID(int LocalLicenseApplicationID, int TestTypeID)
        {
            using (SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString))
            {
                string query = @"
                   SELECT 
                        Tests.TestID
                    FROM 
                        Tests
                        INNER JOIN TestAppointments ON Tests.TestAppointmentID = TestAppointments.TestAppointmentID
                        INNER JOIN LocalDrivingLicenseApplications ON TestAppointments.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID
                    WHERE
                        LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LocalLicenseApplicationID
                        AND TestAppointments.TestTypeID = @TestTypeID
                        AND Tests.TestResult = 1";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@LocalLicenseApplicationID", LocalLicenseApplicationID);
                command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != null && int.TryParse(result.ToString(), out int activeTestAppointmentID))
                    {
                        return activeTestAppointmentID;
                    }

                    return -1;
                }
                catch (Exception ex)
                {

                    throw new ApplicationException($"Error: get passed test for test type.\n{ex.Message}", ex);
                }
            }
        }

        public static int GetAttemptsCountForTestType(int LocalLicenseApplicationID, int TestTypeID)
        {
            using (SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString))
            {
                string query = @"SELECT COUNT(*)
                                 FROM
	                                 Tests
	                                 INNER JOIN TestAppointments ON Tests.TestAppointmentID = TestAppointments.TestAppointmentID
	                                 INNER JOIN LocalDrivingLicenseApplications ON TestAppointments.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID 
                                 WHERE 
	                                 LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LocalLicenseApplicationID
	                                 AND TestTypeID = @TestTypeID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@LocalLicenseApplicationID", LocalLicenseApplicationID);
                command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != null && int.TryParse(result.ToString(), out int trialCount))
                    {
                        return trialCount;
                    }

                    return -1;
                }
                catch (Exception ex)
                {
                    throw new ApplicationException($"Error: get trial count for local license application.\n{ex.Message}", ex);
                }
            }
        }

        public static sbyte GetPassedTestsCount(int LocaolLicenseApplication)
        {
            using (SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString))
            {
                string query = @"SELECT 
	                                 COUNT(*)
                                 FROM 
	                                 Tests
	                                 INNER JOIN TestAppointments ON Tests.TestAppointmentID = TestAppointments.TestAppointmentID
	                                 INNER JOIN LocalDrivingLicenseApplications ON TestAppointments.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID
                                 WHERE
	                                 LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LocaolLicenseApplication
	                                 AND Tests.TestResult = 1";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@LocaolLicenseApplication", LocaolLicenseApplication);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != null && sbyte.TryParse(result.ToString(), out sbyte passedTests))
                    {
                        return passedTests;
                    }

                    return -1;
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public static int GetActiveTestAppointmentID(int LocalLicenseApplicationID, int TestTypeID)
        {
            using (SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString))
            {
                string query = @"
                    SELECT 
	                    TestAppointments.TestAppointmentID
                    FROM 
	                    TestAppointments
	                    INNER JOIN LocalDrivingLicenseApplications ON TestAppointments.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID
                    WHERE
	                    LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LocalLicenseApplicationID
	                    AND TestAppointments.TestTypeID = @TestTypeID
	                    AND TestAppointments.IsLocked = 0";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@LocalLicenseApplicationID", LocalLicenseApplicationID);
                command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != null && int.TryParse(result.ToString(), out int activeTestAppointmentID))
                    {
                        return activeTestAppointmentID;
                    }

                    return -1;
                }
                catch (Exception ex)
                {

                    throw new ApplicationException($"Error: get active test appointment for test type.\n{ex.Message}", ex);
                }
            }
        }

        public static DataTable GetAllTestAppointments(int LocalLicenseApplicationID, int TestTypeID)
        {
            DataTable testAppointments = null;

            using (SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString))
            {
                string query = @"SELECT 
	                                 TestAppointmentID,
	                                 AppointmentDate,
	                                 PaidFees,
	                                 IsLocked
                                 FROM 
	                                 TestAppointments
                                 WHERE
	                                 LocalDrivingLicenseApplicationID = @LocalLicenseApplicationID
	                                 AND TestTypeID = @TestTypeID
                                 ORDER BY
                                     TestAppointmentID DESC";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@LocalLicenseApplicationID", LocalLicenseApplicationID);
                command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

                try
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            testAppointments = new DataTable();
                            testAppointments.Load(reader);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new ApplicationException($"Error: get all test appointments for local license application.\n{ex.Message}", ex);
                }
            }

            return testAppointments;
        }


    }
}
