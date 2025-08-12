using System;
using System.Data.SqlClient;
using System.Data;
using DVLD.Entities;

namespace DVLD.DataAccess
{
    public class clsTestAppointmentData
    {
        public static DataTable GetAllTestAppointmentsForLocalLicenseApplication(int LocalLicenseApplicationID, int TestTypeID)
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
	                                 AND TestTypeID = @TestTypeID";

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

        public static clsTestAppointmentEntity FindTestAppointmentByID(int TestAppointmentID)
        {
            clsTestAppointmentEntity testAppointmentEntity  = null;

            using (SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString))
            {
                string query = @"SELECT * 
                                FROM TestAppointments 
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
                            testAppointmentEntity = new clsTestAppointmentEntity();
                            testAppointmentEntity.TestAppointmentID = TestAppointmentID;
                            testAppointmentEntity.TestTypeID = Convert.ToInt32(reader["TestTypeID"]);
                            testAppointmentEntity.LocalLicenseApplicationID = Convert.ToInt32(reader["LocalDrivingLicenseApplicationID"]);
                            testAppointmentEntity.AppointmentDate = Convert.ToDateTime(reader["AppointmentDate"]);
                            testAppointmentEntity.PaidFees = Convert.ToSingle(reader["PaidFees"]);
                            testAppointmentEntity.IsLocked = Convert.ToBoolean(reader["IsLocked"]);
                            testAppointmentEntity.RetakeTestApplicationID = Convert.ToInt32(reader["RetakeTestApplicationID"]);
                            testAppointmentEntity.CreatedByUserID = Convert.ToInt32(reader["CreatedByUserID"]);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new ApplicationException($"Error: find test appointment by ID.\n{ex.Message}", ex);
                }
            }

            return testAppointmentEntity;
        }

        public static bool AddNewTestAppointment(clsTestAppointmentEntity TestAppointmentEntity)
        {
            using (SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString))
            {
                string query = @"
                    INSERT INTO TestAppointments
                    (
                        TestTypeID, LocalDrivingLicenseApplicationID, AppointmentDate, 
                        PaidFees, CreatedByUserID, IsLocked, RetakeTestApplicationID
                    )
                    VALUES
                    (
	                    @TestTypeID, @LocalDrivingLicenseApplicationID, @AppointmentDate,
                        @PaidFees, @CreatedByUserID, @IsLocked, @RetakeTestApplicationID
                    );
                    SELECT SCOPE_IDENTITY();";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TestTypeID", TestAppointmentEntity.TestTypeID);
                command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", TestAppointmentEntity.LocalLicenseApplicationID);
                command.Parameters.AddWithValue("@AppointmentDate", TestAppointmentEntity.AppointmentDate);
                command.Parameters.AddWithValue("@PaidFees", TestAppointmentEntity.PaidFees);
                command.Parameters.AddWithValue("@CreatedByUserID", TestAppointmentEntity.CreatedByUserID);
                command.Parameters.AddWithValue("@IsLocked", TestAppointmentEntity.IsLocked);
                command.Parameters.AddWithValue("@RetakeTestApplicationID", TestAppointmentEntity.RetakeTestApplicationID);

                try
                {
                    connection.Open();
                    object recordID = command.ExecuteScalar();

                    if (recordID != null)
                    {
                        TestAppointmentEntity.TestAppointmentID = Convert.ToInt32(recordID);
                        return true;
                    }

                    return false;
                }
                catch (Exception ex)
                {
                    throw new ApplicationException($"Error: add a new test appointment.\n{ex.Message}", ex);
                }
            }
        }

        public static bool UpdateAppointmentDate(int TestAppointmentID, DateTime NewAppointmentDate)
        {
            using (SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString))
            {
                string query = @"UPDATE TestAppointments
                                SET
	                                AppointmentDate = @AppointmentDate
                                WHERE TestAppointmentID = @TestAppointmentID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
                command.Parameters.AddWithValue("@AppointmentDate", NewAppointmentDate);

                try
                {
                    connection.Open();

                    return command.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {

                    throw new ApplicationException($"Error: update a date of test appointment.\n{ex.Message}", ex);
                }
            }
        }

        public static bool SetTestAppointmentToLocked(int TestAppointmentID)
        {
            using (SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString))
            {
                string query = @"UPDATE TestAppointments
                                SET
	                                IsLocked = 1
                                WHERE TestAppointmentID = @TestAppointmentID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);

                try
                {
                    connection.Open();

                    return command.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {

                    throw new ApplicationException($"Error: locking a test appointment.\n{ex.Message}", ex);
                }
            }
        }

    }
}
