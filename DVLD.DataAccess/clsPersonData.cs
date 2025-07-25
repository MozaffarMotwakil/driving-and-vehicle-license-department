using System;
using System.Data;
using System.Data.SqlClient;
using DVLD.Entities;

namespace DVLD.DataAccess
{
    public static class clsPersonData
    {
        public static bool IsPersonExist(int PersonID)
        {
            using (SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString))
            {
                string query = @"SELECT 1 
                                FROM People
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
                    throw new ApplicationException($"Error: check is person exist by ID.\n{ex.Message}", ex);
                }
            }
        }

        public static bool IsPersonExist(string NationalNo)
        {
            using (SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString))
            {
                string query = @"SELECT 1
                                FROM People
                                WHERE NationalNo = @NationalNo";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@NationalNo", NationalNo);

                try
                {
                    connection.Open();

                    return command.ExecuteScalar() != null;
                }
                catch (Exception ex)
                {
                    throw new ApplicationException($"Error: check is person exist by National Number.\n{ex.Message}", ex);
                }
            }
        }

        public static DataTable GetAllPeople()
        {
            DataTable people = null;

            using (SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString))
            {
                string query = @"SELECT PersonID, NationalNo, FirstName, SecondName, ThirdName, LastName,
                            		Gender =
                                        CASE
                                            WHEN Gender = 0 THEN 'Male'
                                            WHEN Gender = 1 THEN 'Female'
                                            ELSE 'Unknown'
                                        END
                                  , DateOfBirth, CountryName AS Nationality, Phone, Email 
                                FROM People
                                INNER JOIN Countries ON People.NationalityCountryID = Countries.CountryID";

                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            people = new DataTable();
                            people.Load(reader);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new ApplicationException($"Error: get all people.\n{ex.Message}", ex);
                }
            }
                
            return people;
        }

        public static clsPersonEntity FindPersonByID(int PersonID)
        {
            clsPersonEntity person = null;

            using (SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString))
            {
                string query = @"SELECT * 
                                FROM People 
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
                            person = new clsPersonEntity();

                            person.PersonID = PersonID;
                            person.NationalNo = reader["NationalNo"].ToString();
                            person.FirstName = reader["FirstName"].ToString();
                            person.SecondName = reader["SecondName"].ToString();
                            person.ThirdName = (reader["ThirdName"] != DBNull.Value) ? reader["ThirdName"].ToString() : String.Empty;
                            person.LastName = reader["LastName"].ToString();
                            person.DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]);
                            person.Gender = (clsPersonEntity.enGender)Convert.ToByte((reader["Gender"]));
                            person.Address = reader["Address"].ToString();
                            person.Phone = reader["Phone"].ToString();
                            person.Email = (reader["Email"] != DBNull.Value) ? reader["Email"].ToString() : String.Empty;
                            person.CountryInfo = clsCountryData.FindCountryByID(Convert.ToInt32(reader["NationalityCountryID"]));
                            person.ImagePath = (reader["ImagePath"] != DBNull.Value) ? reader["ImagePath"].ToString() : String.Empty;
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new ApplicationException($"Error: find person by ID.\n{ex.Message}", ex);
                }
            }

            return person;
        }

        public static clsPersonEntity FindPersonByNationalNo(string NationalNo)
        {
            clsPersonEntity person = null;

            using (SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString))
            {
                string query = @"SELECT *
                                FROM People
                                WHERE NationalNo = @NationalNo";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@NationalNo", NationalNo);

                try
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            person = new clsPersonEntity();

                            person.PersonID = Convert.ToInt32(reader["PersonID"]);
                            person.NationalNo = NationalNo;
                            person.FirstName = reader["FirstName"].ToString();
                            person.SecondName = reader["SecondName"].ToString();
                            person.ThirdName = (reader["ThirdName"] != DBNull.Value) ? reader["ThirdName"].ToString() : String.Empty;
                            person.LastName = reader["LastName"].ToString();
                            person.DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]);
                            person.Gender = (clsPersonEntity.enGender)Convert.ToByte((reader["Gender"]));
                            person.Address = reader["Address"].ToString();
                            person.Phone = reader["Phone"].ToString();
                            person.Email = (reader["Email"] != DBNull.Value) ? reader["Email"].ToString() : String.Empty;
                            person.CountryInfo = clsCountryData.FindCountryByID(Convert.ToInt32(reader["NationalityCountryID"]));
                            person.ImagePath = (reader["ImagePath"] != DBNull.Value) ? reader["ImagePath"].ToString() : String.Empty;
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new ApplicationException($"Error: find person by National Number.\n{ex.Message}", ex);
                }
            }

            return person;
        }

        public static bool AddNewPerson(clsPersonEntity person)
        {
            using (SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString))
            {
                string query = @"INSERT INTO People (NationalNo, FirstName, SecondName, ThirdName, LastName,
	                                DateOfBirth, Gender, Address, Phone, Email, NationalityCountryID, ImagePath)
                                VALUES
                                (
	                                @NationalNo, @FirstName, @SecondName, @ThirdName, @LastName, @DateOfBirth,
	                                @Gender, @Address, @Phone, @Email, @NationalityCountryID, @ImagePath
                                );
                                SELECT SCOPE_IDENTITY()"; ;

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@NationalNo", person.NationalNo);
                command.Parameters.AddWithValue("@FirstName", person.FirstName);
                command.Parameters.AddWithValue("@SecondName", person.SecondName);

                if (string.IsNullOrWhiteSpace(person.ThirdName))
                    command.Parameters.AddWithValue("@ThirdName", DBNull.Value);
                else
                    command.Parameters.AddWithValue("@ThirdName", person.ThirdName);

                command.Parameters.AddWithValue("@LastName", person.LastName);
                command.Parameters.AddWithValue("@DateOfBirth", person.DateOfBirth);
                command.Parameters.AddWithValue("@Gender", person.Gender);
                command.Parameters.AddWithValue("@Address", person.Address);
                command.Parameters.AddWithValue("@Phone", person.Phone);

                if (string.IsNullOrWhiteSpace(person.Email))
                    command.Parameters.AddWithValue("@Email", DBNull.Value);
                else
                    command.Parameters.AddWithValue("@Email", person.Email);

                command.Parameters.AddWithValue("@NationalityCountryID", person.CountryInfo.CountryID);

                if (string.IsNullOrWhiteSpace(person.ImagePath))
                    command.Parameters.AddWithValue("@ImagePath", DBNull.Value);
                else
                    command.Parameters.AddWithValue("@ImagePath", person.ImagePath);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != null)
                    {
                        person.PersonID = Convert.ToInt32(result);
                        return true;
                    }

                    return false;
                }
                catch (Exception ex)
                {
                    throw new ApplicationException($"Error: add a new person.\n{ex.Message}", ex);
                }
            }
        }

        public static bool DeletePerson(int PersonID)
        {
            using (SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString))
            {
                string query = @"DELETE FROM People 
                                WHERE PersonID = @PersonID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@PersonID", PersonID);

                try
                {
                    connection.Open();

                    return command.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    throw new ApplicationException($"Error: delete a person.\n{ex.Message}", ex);
                }
            }
        }

        public static bool UpdatePerson(clsPersonEntity person) 
        {
            using (SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString))
            {
                string query = @"UPDATE People
                                SET
	                                NationalNo = @NationalNo, FirstName = @FirstName, SecondName = @SecondName, ThirdName = @ThirdName,
                                    LastName = @LastName, DateOfBirth = @DateOfBirth, Gender = @Gender, Address = @Address, Phone = @Phone,
                                    Email = @Email, NationalityCountryID = @NationalityCountryID, ImagePath = @ImagePath
                                WHERE PersonID = @PersonID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@PersonID", person.PersonID);
                command.Parameters.AddWithValue("@NationalNo", person.NationalNo);
                command.Parameters.AddWithValue("@FirstName", person.FirstName);
                command.Parameters.AddWithValue("@SecondName", person.SecondName);

                if (string.IsNullOrWhiteSpace(person.ThirdName))
                    command.Parameters.AddWithValue("@ThirdName", DBNull.Value);
                else
                    command.Parameters.AddWithValue("@ThirdName", person.ThirdName);

                command.Parameters.AddWithValue("@LastName", person.LastName);
                command.Parameters.AddWithValue("@DateOfBirth", person.DateOfBirth);
                command.Parameters.AddWithValue("@Gender", person.Gender);
                command.Parameters.AddWithValue("@Address", person.Address);
                command.Parameters.AddWithValue("@Phone", person.Phone);

                if (string.IsNullOrWhiteSpace(person.Email))
                    command.Parameters.AddWithValue("@Email", DBNull.Value);
                else
                    command.Parameters.AddWithValue("@Email", person.Email);

                command.Parameters.AddWithValue("@NationalityCountryID", person.CountryInfo.CountryID);

                if (string.IsNullOrWhiteSpace(person.ImagePath))
                    command.Parameters.AddWithValue("@ImagePath", DBNull.Value);
                else
                    command.Parameters.AddWithValue("@ImagePath", person.ImagePath);

                try
                {
                    connection.Open();

                    return command.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {

                    throw new ApplicationException($"Error: update a person.\n{ex.Message}", ex);
                }
            }
        }

    }
}
