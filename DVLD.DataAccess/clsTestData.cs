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
                            testEntity.Notes = Convert.ToString(reader["Notes"]);
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

        public static bool AddNewTest(clsTestEntity testEntity)
        {
            using (SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString))
            {
                string query = @"
                    INSERT INTO TestAppointments
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
                command.Parameters.AddWithValue("@Notes", testEntity.Notes);
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
