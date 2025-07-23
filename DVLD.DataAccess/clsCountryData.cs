using System;
using System.Data;
using System.Data.SqlClient;
using DVLD.Entities;

namespace DVLD.DataAccess
{
    public static class clsCountryData
    {
        public static DataTable GetAllCountries()
        {
            DataTable countries = null;

            using (SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString))
            {
                string query = "SELECT CountryName FROM Countries";
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            countries = new DataTable();
                            countries.Load(reader);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new ApplicationException($"Error: get all countries.\n{ex.Message}", ex);
                }
            }
            
            return countries;
        }

        public static CountryEntity FindCountryByID(int CountryID)
        {
            CountryEntity countryEntity = null;

            using (SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString))
            {
                string query = @"SELECT *
                                FROM Countries
                                WHERE CountryID = @CountryID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@CountryID", CountryID);

                try
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            countryEntity = new CountryEntity();

                            countryEntity.CountryID = CountryID;
                            countryEntity.CountryName = reader["CountryName"].ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new ApplicationException($"Error: get country by ID.\n{ex.Message}", ex);
                }
            }

            return countryEntity;
        }

        public static CountryEntity FindCountryByName(string CountryName)
        {
            CountryEntity countryEntity = null;

            using (SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString))
            {
                string query = @"SELECT *
                                FROM Countries
                                WHERE CountryName = @CountryName";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@CountryName", CountryName);

                try
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            countryEntity = new CountryEntity();

                            countryEntity.CountryID = Convert.ToInt32(reader["CountryID"]);
                            countryEntity.CountryName = CountryName;
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new ApplicationException($"Error: get country by name.\n{ex.Message}", ex);
                }
            }

            return countryEntity;
        }

        public static bool IsCountryExist(int CountryID)
        {
            using (SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString))
            {
                string query = @"SELECT 1
                                FROM Countries
                                WHERE CountryID = @CountryID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@CountryID", CountryID);

                try
                {
                    connection.Open();

                    return command.ExecuteScalar() != null;
                }
                catch (Exception ex)
                {
                    throw new ApplicationException($"Error: check is country exist.\n{ex.Message}", ex);
                }
            }
        }

    }
}
