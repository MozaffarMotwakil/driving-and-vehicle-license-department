using System;
using System.Data;
using System.Data.SqlClient;
using DVLD.Entities;

namespace DVLD.DataAccess
{
    public class clsDriverData
    {
        public static bool IsDriverExist(int PersonID)
        {
            using (SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString))
            {
                string query = @"SELECT 1 
                                FROM Drivers
                                WHERE PersonID = @PersonID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@PersonID", PersonID);

                try
                {
                    connection.Open();

                    return command.ExecuteScalar() != null;
                }
                catch (Exception ex)
                {
                    throw new ApplicationException($"Error: check is driver exist by ID.\n{ex.Message}", ex);
                }
            }
        }

        public static clsDriverEntity FindDriverByDriverID(int DriverID)
        {
            clsDriverEntity driverEntity = null;

            using (SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString))
            {
                string query = @"SELECT * 
                                FROM Drivers 
                                WHERE DriverID = @DriverID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@DriverID", DriverID);

                try
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            driverEntity = new clsDriverEntity();
                            driverEntity.DriverID = DriverID;
                            driverEntity.PersonID = Convert.ToInt32(reader["PersonID"]);
                            driverEntity.CreatedByUserID = Convert.ToInt32(reader["CreatedByUserID"]);
                            driverEntity.CreatedDate = Convert.ToDateTime(reader["CreatedDate"]);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new ApplicationException($"Error: find driver by ID.\n{ex.Message}", ex);
                }
            }

            return driverEntity;
        }

        public static clsDriverEntity FindDriverByPersonID(int PersonID)
        {
            clsDriverEntity driverEntity = null;

            using (SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString))
            {
                string query = @"SELECT * 
                                FROM Drivers 
                                WHERE PersonID = @PersonID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@PersonID", PersonID);

                try
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            driverEntity = new clsDriverEntity();
                            driverEntity.DriverID = Convert.ToInt32(reader["DriverID"]);
                            driverEntity.PersonID = PersonID;
                            driverEntity.CreatedByUserID = Convert.ToInt32(reader["CreatedByUserID"]);
                            driverEntity.CreatedDate = Convert.ToDateTime(reader["CreatedDate"]);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new ApplicationException($"Error: find driver by ID.\n{ex.Message}", ex);
                }
            }

            return driverEntity;
        }


        public static DataTable GetAllDrivers()
        {
            DataTable drivers = null;

            using (SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString))
            {
                string query = "SELECT * FROM DriversDetailed ORDER BY CreatedDate DESC";
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            drivers = new DataTable();
                            drivers.Load(reader);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new ApplicationException($"Error: get all drivers.\n{ex.Message}", ex);
                }

            }

            return drivers;
        }

        public static bool AddNewDriver(clsDriverEntity DriverEntity)
        {
            using (SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString))
            {
                string query = @"INSERT INTO Drivers (PersonID, CreatedDate, CreatedByUserID)
                                VALUES
                                (
	                                @PersonID, 
	                                @CreatedDate, 
                                    @CreatedByUserID
                                );
                                SELECT SCOPE_IDENTITY()"; ;

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@PersonID", DriverEntity.PersonID);
                command.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
                command.Parameters.AddWithValue("@CreatedByUserID", DriverEntity.CreatedByUserID);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != null)
                    {
                        DriverEntity.DriverID = Convert.ToInt32(result);
                        return true;
                    }

                    return false;
                }
                catch (Exception ex)
                {
                    throw new ApplicationException($"Error: add a new driver.\n{ex.Message}", ex);
                }
            }
        }

    }
}
