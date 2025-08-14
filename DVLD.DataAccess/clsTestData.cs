using System;
using DVLD.Entities;
using System.Data.SqlClient;

namespace DVLD.DataAccess
{
    public class clsTestData
    {
        public static clsTestEntity FindTestByID(int TestAppointmentID)
        {
            clsTestEntity testEntity = null;

            using (SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString))
            {
                string query = @"SELECT * 
                                FROM Tests 
                                WHERE TestAppointmentID = @TestAppointmentID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);

                try
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            testEntity = new clsTestEntity();
                            testEntity.TestID = Convert.ToInt32(reader["TestID"]);
                            testEntity.TestAppointmentID = TestAppointmentID;
                            testEntity.TestResult = Convert.ToBoolean(reader["TestResult"]);

                            if (reader["Notes"] == DBNull.Value)
                            {
                                testEntity.Notes = string.Empty;
                            }
                            else
                            {
                                testEntity.Notes = Convert.ToString(reader["Notes"]);
                            }
                                
                            testEntity.CreatedByUserID = Convert.ToInt32(reader["CreatedByUserID"]);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new ApplicationException($"Error: find test by ID.\n{ex.Message}", ex);
                }
            }

            return testEntity;
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

        public static int GetAttemptsCountForLocalLicenseApplication(int LocalLicenseApplicationID, int TestTypeID)
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

        public static int GetPassedTestsCountForLocalLicenseApplication(int LocaolLicenseApplication)
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

                    if (result != null && int.TryParse(result.ToString(), out int passedTests))
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

        public static bool AddNewTest(clsTestEntity testEntity)
        {
            using (SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString))
            {
                string query = @"
                    INSERT INTO Tests
                    (
                        TestAppointmentID, TestResult, Notes, CreatedByUserID
                    )
                    VALUES
                    (
	                    @TestAppointmentID, @TestResult, @Notes, @CreatedByUserID
                    );
                    SELECT SCOPE_IDENTITY();";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TestAppointmentID", testEntity.TestAppointmentID);
                command.Parameters.AddWithValue("@TestResult", testEntity.TestResult);

                if (string.IsNullOrWhiteSpace(testEntity.Notes))
                {
                    command.Parameters.AddWithValue("@Notes", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@Notes", testEntity.Notes);
                }

                command.Parameters.AddWithValue("@CreatedByUserID", testEntity.CreatedByUserID);

                try
                {
                    connection.Open();
                    object recordID = command.ExecuteScalar();

                    if (recordID != null)
                    {
                        testEntity.TestID = Convert.ToInt32(recordID);
                        return true;
                    }

                    return false;
                }
                catch (Exception ex)
                {
                    throw new ApplicationException($"Error: add a new test.\n{ex.Message}", ex);
                }
            }
        }

    }
}
