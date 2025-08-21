using System;
using System.Data.SqlClient;
using System.Data;
using DVLD.Entities;
using System.Reflection;

namespace DVLD.DataAccess
{
    public class clsInternationalLicenseData
    {
        public static bool IsPersonHasAnActiveInternationalLicense(int PersonID)
        {
            using (SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString))
            {
                string query = @"SELECT 1
                                 FROM
	                                 InternationalLicenses
	                                 INNER JOIN Drivers ON InternationalLicenses.DriverID = Drivers.DriverID
	                                 INNER JOIN People ON Drivers.PersonID = People.PersonID
                                 WHERE 
	                                 People.PersonID = @PersonID
	                                 AND InternationalLicenses.IsActive = 1";
                                  
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@PersonID", PersonID);

                try
                {
                    connection.Open();

                    return command.ExecuteScalar() != null;
                }
                catch (Exception ex)
                {
                    throw new ApplicationException($"Error: check is person has an active international license.\n{ex.Message}", ex);
                }
            }
        }

        public static clsInternationalLicenseEntity GetActiveInternationalLicenseForPerson(int PersonID)
        {
            clsInternationalLicenseEntity internationalLicenseEntity = null;

            using (SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString))
            {
                string query = @"SELECT *
                                 FROM
	                                 InternationalLicenses
	                                 INNER JOIN Drivers ON InternationalLicenses.DriverID = Drivers.DriverID
	                                 INNER JOIN People ON Drivers.PersonID = People.PersonID
                                 WHERE 
	                                 People.PersonID = @PersonID
	                                 AND InternationalLicenses.IsActive = 1";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@PersonID", PersonID);

                try
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            internationalLicenseEntity = new clsInternationalLicenseEntity();
                            internationalLicenseEntity.InternationalLicenseID = Convert.ToInt32(reader["ApplicationID"]);
                            internationalLicenseEntity.ApplicationID = Convert.ToInt32(reader["ApplicationID"]);
                            internationalLicenseEntity.DriverID = Convert.ToInt32(reader["DriverID"]);
                            internationalLicenseEntity.IssuedUsingLocalLicenseID = Convert.ToInt32(reader["IssuedUsingLocalLicenseID"]);
                            internationalLicenseEntity.CreatedByUserID = Convert.ToInt32(reader["CreatedByUserID"]);
                            internationalLicenseEntity.IssueDate = Convert.ToDateTime(reader["IssueDate"]);
                            internationalLicenseEntity.ExpirationDate = Convert.ToDateTime(reader["ExpirationDate"]);
                            internationalLicenseEntity.IsActive = Convert.ToBoolean(reader["IsActive"]);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new ApplicationException($"Error: get active international license for person.\n{ex.Message}", ex);
                }

                return internationalLicenseEntity;
            }
        }

        public static clsInternationalLicenseEntity FindInternationalLicenseByID(int InternationalLicenseID)
        {
            clsInternationalLicenseEntity internationalLicenseEntity = null;

            using (SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString))
            {
                string query = @"SELECT * 
                                 FROM 
	                                 InternationalLicenses 
                                 WHERE
	                                 InternationalLicenseID = @InternationalLicenseID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@InternationalLicenseID", InternationalLicenseID);

                try
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            internationalLicenseEntity = new clsInternationalLicenseEntity();
                            internationalLicenseEntity.InternationalLicenseID = InternationalLicenseID;
                            internationalLicenseEntity.ApplicationID = Convert.ToInt32(reader["ApplicationID"]);
                            internationalLicenseEntity.DriverID = Convert.ToInt32(reader["DriverID"]);
                            internationalLicenseEntity.IssuedUsingLocalLicenseID = Convert.ToInt32(reader["IssuedUsingLocalLicenseID"]);
                            internationalLicenseEntity.CreatedByUserID = Convert.ToInt32(reader["CreatedByUserID"]);
                            internationalLicenseEntity.IssueDate = Convert.ToDateTime(reader["IssueDate"]);
                            internationalLicenseEntity.ExpirationDate = Convert.ToDateTime(reader["ExpirationDate"]);
                            internationalLicenseEntity.IsActive = Convert.ToBoolean(reader["IsActive"]);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new ApplicationException($"Error: find international license by ID.\n{ex.Message}", ex);
                }
            }

            return internationalLicenseEntity;
        }

        public static DataTable GetAllInternationalLicenses()
        {
            DataTable internationalLicenses = null;

            using (SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString))
            {
                string query = @"
                                 SELECT 
	                                 InternationalLicenseID,
	                                 IssuedUsingLocalLicenseID,
                                     CASE
		                                 WHEN ThirdName IS NULL THEN FirstName + ' ' + SecondName + ' ' + LastName
		                                 ELSE FirstName + ' ' + SecondName + ' ' + ThirdName + ' ' + LastName
	                                 END AS FullName,
	                                 IssueDate,
	                                 ExpirationDate,
	                                 IsActive
                                 FROM
	                                 InternationalLicenses
                                     INNER JOIN Drivers ON InternationalLicenses.DriverID = Drivers.DriverID
                                     INNER JOIN People ON Drivers.PersonID = People.PersonID
                                 ORDER BY
                                     IssueDate DESC";

                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            internationalLicenses = new DataTable();
                            internationalLicenses.Load(reader);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new ApplicationException($"Error: get all international licenses.\n{ex.Message}", ex);
                }
            }

            return internationalLicenses;
        }


        public static DataTable GetAllInternationalLicensesForPerson(int PersonID)
        {
            DataTable internationalLicenses = null;

            using (SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString))
            {
                string query = @"
                                 SELECT 
	                                 InternationalLicenseID,
	                                 ApplicationID,
	                                 IssuedUsingLocalLicenseID,
	                                 IssueDate,
	                                 ExpirationDate,
	                                 IsActive
                                 FROM
	                                 InternationalLicenses
	                                 INNER JOIN Drivers ON InternationalLicenses.DriverID = Drivers.DriverID
	                                 INNER JOIN People ON Drivers.PersonID = People.PersonID
                                 WHERE 
	                                 People.PersonID = @PersonID
                                 ORDER BY
                                     IssueDate DESC";
                             
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@PersonID", PersonID);

                try
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            internationalLicenses = new DataTable();
                            internationalLicenses.Load(reader);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new ApplicationException($"Error: get all international licenses for person.\n{ex.Message}", ex);
                }
            }

            return internationalLicenses;
        }

        public static bool AddNewInternationalLicense(clsInternationalLicenseEntity InternationalLicenseEntity)
        {
            using (SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString))
            {
                string query = @"INSERT INTO InternationalLicenses (ApplicationID, DriverID, IssuedUsingLocalLicenseID,
                                CreatedByUserID, IssueDate, ExpirationDate, IsActive)
                                VALUES
                                (
	                                @ApplicationID, 
	                                @DriverID, 
	                                @IssuedUsingLocalLicenseID, 
	                                @CreatedByUserID, 
	                                @IssueDate, 
	                                @ExpirationDate, 
	                                @IsActive
                                );
                                SELECT SCOPE_IDENTITY()"; ;

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ApplicationID", InternationalLicenseEntity.ApplicationID);
                command.Parameters.AddWithValue("@DriverID", InternationalLicenseEntity.DriverID);
                command.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", InternationalLicenseEntity.IssuedUsingLocalLicenseID);
                command.Parameters.AddWithValue("@CreatedByUserID", InternationalLicenseEntity.CreatedByUserID);
                command.Parameters.AddWithValue("@IssueDate", InternationalLicenseEntity.IssueDate);
                command.Parameters.AddWithValue("@ExpirationDate", InternationalLicenseEntity.ExpirationDate);
                command.Parameters.AddWithValue("@IsActive", InternationalLicenseEntity.IsActive);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != null)
                    {
                        InternationalLicenseEntity.InternationalLicenseID = Convert.ToInt32(result);
                        return true;
                    }

                    return false;
                }
                catch (Exception ex)
                {
                    throw new ApplicationException($"Error: add a new international license.\n{ex.Message}", ex);
                }
            }
        }

        public static bool SetInternationalLicenseToDeactivated(int InternationalLicenseID)
        {
            using (SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString))
            {
                string query = @"UPDATE 
                                    InternationalLicenses
                                 SET
	                                IsLocked = 0
                                 WHERE 
                                    InternationalLicenseID = @InternationalLicenseID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@InternationalLicenseID", InternationalLicenseID);

                try
                {
                    connection.Open();

                    return command.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {

                    throw new ApplicationException($"Error: deactivating a international license.\n{ex.Message}", ex);
                }
            }
        }

    }
}
