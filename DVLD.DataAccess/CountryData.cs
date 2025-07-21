using System;
using System.Data;
using System.Data.SqlClient;

namespace DVLD.DataAccess
{
    public static class CountryData
    {
        public static DataTable GetAllCountries()
        {
            DataTable countries = null;

            using (SqlConnection connection = new SqlConnection(DataSettings.ConnectionString))
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

        public static string FindCountryByID(int CountryID)
        {
            using (SqlConnection connection = new SqlConnection(DataSettings.ConnectionString))
            {
                string query = @"SELECT CountryName
                                FROM Countries
                                WHERE CountryID = @CountryID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@CountryID", CountryID);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    return result != null ? result.ToString() : string.Empty;
                }
                catch (Exception ex)
                {
                    throw new ApplicationException($"Error: get country name.\n{ex.Message}", ex);
                }
            }
        }

    }
}
