using System;
using DVLD.Entities;
using System.Data.SqlClient;
using System.Data;

namespace DVLD.DataAccess
{
    public class clsLicenseData
    {
        public static bool IsLicenseExist(int PersonID, int LicenseClassID)
        {
            using (SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString))
            {
                string query = @"SELECT 1 
                                 FROM 
                                     Licenses
                                     INNER JOIN Drivers ON Licenses.DriverID = Drivers.DriverID
                                     INNER JOIN People ON Drivers.PersonID = People.PersonID
                                 WHERE 
                                     People.PersonID = @PersonID
                                     AND LicenseClassID = @LicenseClassID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@PersonID", PersonID);
                command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

                try
                {
                    connection.Open();

                    return command.ExecuteScalar() != null;
                }
                catch (Exception ex)
                {
                    throw new ApplicationException($"Error: check is license exist.\n{ex.Message}", ex);
                }
            }
        }

        public static clsLicenseEntity FindLicenseByApplicationID(int ApplicationID)
        {
            clsLicenseEntity licenseEntity = null;

            using (SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString))
            {
                string query = @"SELECT * 
                                 FROM 
	                                 Licenses 
                                 WHERE
	                                 ApplicationID = @ApplicationID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

                try
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            licenseEntity = new clsLicenseEntity();
                            licenseEntity.LicenseID = Convert.ToInt32(reader["LicenseID"]);
                            licenseEntity.DriverID = Convert.ToInt32(reader["DriverID"]);
                            licenseEntity.ApplicationID = ApplicationID;
                            licenseEntity.LicenseClassID = Convert.ToInt32(reader["LicenseClassID"]);
                            licenseEntity.IssueReasonID = Convert.ToInt32(reader["IssueReasonID"]);
                            licenseEntity.CreatedByUserID = Convert.ToInt32(reader["CreatedByUserID"]);
                            licenseEntity.IssueDate = Convert.ToDateTime(reader["IssueDate"]);
                            licenseEntity.ExpirationDate = Convert.ToDateTime(reader["ExpirationDate"]);
                            licenseEntity.Notes = reader["Notes"] != DBNull.Value ?
                                Convert.ToString(reader["Notes"]) :
                                string.Empty;
                            licenseEntity.PaidFees = Convert.ToSingle(reader["PaidFees"]);
                            licenseEntity.IsActive = Convert.ToBoolean(reader["IsActive"]);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new ApplicationException($"Error: find license by person ID.\n{ex.Message}", ex);
                }
            }

            return licenseEntity;
        }

        public static DataTable GetAllLicensesForPerson(int PersonID)
        {
            DataTable licenses = null;

            using (SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString))
            {
                string query = @"
                                 SELECT 
	                                 LicenseID,
	                                 ApplicationID,
	                                 LicenseClasses.ClassName,
	                                 IssueDate,
	                                 ExpirationDate,
	                                 IsActive
                                 FROM
	                                 Licenses
	                                 INNER JOIN LicenseClasses ON Licenses.LicenseClassID = LicenseClasses.LicenseClassID
	                                 INNER JOIN Drivers ON Licenses.DriverID = Drivers.DriverID
	                                 INNER JOIN People ON Drivers.PersonID = People.PersonID 
                                 WHERE
	                                 People.PersonID = @PersonID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@PersonID", PersonID);

                try
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            licenses = new DataTable();
                            licenses.Load(reader);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new ApplicationException($"Error: get all licenses for person.\n{ex.Message}", ex);
                }
            }

            return licenses;
        }

        public static bool AddNewLicense(clsLicenseEntity LicenseEntity)
        {
            using (SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString))
            {
                string query = @"INSERT INTO Licenses (DriverID, ApplicationID, LicenseClassID, IssueReasonID,
                                CreatedByUserID, IssueDate, ExpirationDate, Notes, PaidFees, IsActive)
                                VALUES
                                (
	                                @DriverID, 
	                                @ApplicationID, 
	                                @LicenseClassID, 
	                                @IssueReasonID, 
	                                @CreatedByUserID, 
	                                @IssueDate, 
	                                @ExpirationDate, 
	                                @Notes, 
	                                @PaidFees, 
	                                @IsActive
                                );
                                SELECT SCOPE_IDENTITY()"; ;

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@DriverID", LicenseEntity.DriverID);
                command.Parameters.AddWithValue("@ApplicationID", LicenseEntity.ApplicationID);
                command.Parameters.AddWithValue("@LicenseClassID", LicenseEntity.LicenseClassID);
                command.Parameters.AddWithValue("@IssueReasonID", LicenseEntity.IssueReasonID);
                command.Parameters.AddWithValue("@CreatedByUserID", LicenseEntity.CreatedByUserID);
                command.Parameters.AddWithValue("@IssueDate", LicenseEntity.IssueDate);
                command.Parameters.AddWithValue("@ExpirationDate", LicenseEntity.ExpirationDate);

                if (string.IsNullOrWhiteSpace(LicenseEntity.Notes))
                {
                    command.Parameters.AddWithValue("@Notes", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@Notes", LicenseEntity.Notes);
                }

                command.Parameters.AddWithValue("@PaidFees", LicenseEntity.PaidFees);
                command.Parameters.AddWithValue("@IsActive", LicenseEntity.IsActive);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != null)
                    {
                        LicenseEntity.LicenseID = Convert.ToInt32(result);
                        return true;
                    }

                    return false;
                }
                catch (Exception ex)
                {
                    throw new ApplicationException($"Error: add a new license.\n{ex.Message}", ex);
                }
            }
        }

        public static bool SetLicenseToDeactivated(int LicenseID)
        {
            using (SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString))
            {
                string query = @"UPDATE 
                                    Licenses
                                 SET
	                                IsLocked = 0
                                 WHERE 
                                    LicenseID = @LicenseID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@LicenseID", LicenseID);

                try
                {
                    connection.Open();

                    return command.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {

                    throw new ApplicationException($"Error: Deactivating a license.\n{ex.Message}", ex);
                }
            }
        }

    }
}
