using System;
using System.Data;
using System.Data.SqlClient;
using DVLD.Entities;

namespace DVLD.DataAccess
{
    public class clsUserData
    {
        public static bool IsPersonHasUser(int PersonID)
        {
            using (SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString))
            {
                string query = 
                    @"SELECT 1 
                    FROM Users
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
                    throw new ApplicationException($"Error: check is person has user.\n{ex.Message}", ex);
                }
            }
        }

        public static bool IsUserExist(int UserID)
        {
            using (SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString))
            {
                string query = @"SELECT 1 
                                FROM Users
                                WHERE UserID = @UserID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@UserID", UserID);

                try
                {
                    connection.Open();

                    return command.ExecuteScalar() != null;
                }
                catch (Exception ex)
                {
                    throw new ApplicationException($"Error: check is user exist by ID.\n{ex.Message}", ex);
                }
            }
        }

        public static bool IsUserExist(string Username)
        {
            using (SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString))
            {
                string query = @"SELECT 1 
                                FROM Users
                                WHERE Username = @Username";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Username", Username);

                try
                {
                    connection.Open();

                    return command.ExecuteScalar() != null;
                }
                catch (Exception ex)
                {
                    throw new ApplicationException($"Error: check is user exist by Username.\n{ex.Message}", ex);
                }
            }
        }

        public static DataTable GetAllUsers()
        {
            DataTable Users = null;

            using (SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString))
            {
                string query =
                    @"SELECT UserID, Users.PersonID, Username,
		                CASE
			                WHEN ThirdName IS NULL THEN FirstName + ' ' + SecondName + ' ' + LastName
			                ELSE FirstName + ' ' + SecondName + ' ' + ThirdName + ' ' + LastName
		                END AS FullName,
		                CASE 
			                WHEN Gender = 0 THEN 'Male'
			                ELSE 'Female'
		                END AS Gender,
		                CountryName AS Nationality, IsActive
                      FROM Users
                      INNER JOIN People ON Users.PersonID = People.PersonID
                      INNER JOIN Countries ON People.NationalityCountryID = Countries.CountryID";
                
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            Users = new DataTable();
                            Users.Load(reader);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new ApplicationException($"Error: get all users.\n{ex.Message}", ex);
                }
            }

            return Users;
        }

        public static clsUserEntity FindUserByID(int UserID)
        {
            clsUserEntity userEntity = null;

            using (SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString))
            {
                string query = @"SELECT * 
                                FROM Users 
                                WHERE UserID = @UserID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@UserID", UserID);

                try
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            userEntity = new clsUserEntity();

                            userEntity.UserID = UserID;
                            userEntity.PersonID = Convert.ToInt32(reader["PersonID"]);
                            userEntity.Username = reader["Username"].ToString();
                            userEntity.Password = reader["Password"].ToString();
                            userEntity.IsActive = Convert.ToBoolean(reader["IsActive"]);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new ApplicationException($"Error: find user by ID.\n{ex.Message}", ex);
                }
            }

            return userEntity;
        }

        public static clsUserEntity FindUserByUsername(string Username)
        {
            clsUserEntity userEntity = null;

            using (SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString))
            {
                string query = @"SELECT * 
                                FROM Users 
                                WHERE Username = @Username";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Username", Username);

                try
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            userEntity = new clsUserEntity();

                            userEntity.UserID = Convert.ToInt32(reader["UserID"]);
                            userEntity.PersonID = Convert.ToInt32(reader["PersonID"]);
                            userEntity.Username = Username;
                            userEntity.Password = reader["Password"].ToString();
                            userEntity.IsActive = Convert.ToBoolean(reader["IsActive"]);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new ApplicationException($"Error: find user by Username.\n{ex.Message}", ex);
                }
            }

            return userEntity;
        }

        public static bool AddNewUser(clsUserEntity UserEntity)
        {
            using (SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString))
            {
                string query =
                    @"INSERT INTO Users(PersonID, Username, Password, IsActive)
                      VALUES
                      (
                          @PersonID, @Username, @Password, @IsActive
                      );
                      SELECT SCOPE_IDENTITY()";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@PersonID", UserEntity.PersonID);
                command.Parameters.AddWithValue("@Username", UserEntity.Username);
                command.Parameters.AddWithValue("@Password", UserEntity.Password);
                command.Parameters.AddWithValue("@IsActive", UserEntity.IsActive);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != null)
                    {
                        UserEntity.UserID = Convert.ToInt32(result);
                        return true;
                    }

                    return false;
                }
                catch (Exception ex)
                {
                    throw new ApplicationException($"Error: add a new user.\n{ex.Message}", ex);
                }
            }
        }

        public static bool DeleteUser(int UserID)
        {
            using (SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString))
            {
                string query = @"DELETE FROM Users 
                                 WHERE UserID = @UserID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@UserID", UserID);

                try
                {
                    connection.Open();

                    return command.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    throw new ApplicationException($"Error: delete a user.\n{ex.Message}", ex);
                }
            }
        }

        public static bool UpdateUser(clsUserEntity UserEntity)
        {
            using (SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString))
            {
                string query = @"UPDATE Users
                                SET
	                                PersonID = @PersonID, Username = @Username,
                                    Password = @Password, IsActive = @IsActive
                                WHERE UserID = @UserID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@UserID", UserEntity.UserID);
                command.Parameters.AddWithValue("@PersonID", UserEntity.PersonID);
                command.Parameters.AddWithValue("@Username", UserEntity.Username);
                command.Parameters.AddWithValue("@Password", UserEntity.Password);
                command.Parameters.AddWithValue("@IsActive", UserEntity.IsActive);

                try
                {
                    connection.Open();

                    return command.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {

                    throw new ApplicationException($"Error: update a user.\n{ex.Message}", ex);
                }
            }
        }

    }
}
