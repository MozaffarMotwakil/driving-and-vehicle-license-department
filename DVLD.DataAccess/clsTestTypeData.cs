using System;
using System.Data.SqlClient;
using System.Data;
using DVLD.Entities;

namespace DVLD.DataAccess
{
    public class clsTestTypeData
    {
        public static clsTestTypeEntity FindTestTypeByID(int TestTypeID)
        {
            clsTestTypeEntity testTypeEntity = null;

            using (SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString))
            {
                string query = @"SELECT * 
                                FROM TestTypes 
                                WHERE TestTypeID = @TestTypeID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

                try
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            testTypeEntity = new clsTestTypeEntity(
                                TestTypeID,
                                reader["TestTypeTitle"].ToString(),
                                reader["TestTypeDescription"].ToString(),
                                Convert.ToSingle(reader["TestTypeFees"])
                                );
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new ApplicationException($"Error: find test type by ID.\n{ex.Message}", ex);
                }
            }

            return testTypeEntity;
        }

        public static DataTable GetAllTestTypes()
        {
            DataTable testTypes = null;

            using (SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString))
            {
                string query = "SELECT * FROM TestTypes";
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            testTypes = new DataTable();
                            testTypes.Load(reader);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new ApplicationException($"Error: get all test types.\n{ex.Message}", ex);
                }

            }

            return testTypes;
        }

        public static bool UpdateTestType(clsTestTypeEntity testTypeEntity)
        {
            using (SqlConnection connection = new SqlConnection(clsDataSettings.ConnectionString))
            {
                string query =
                    @"UPDATE TestTypes 
                    SET
                    TestTypeTitle = @TestTypeTitle,
                    TestTypeDescription = @TestTypeDescription,
                    TestTypeFees = @TestTypeFees
                    WHERE TestTypeID = @TestTypeID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TestTypeID", testTypeEntity.TypeID);
                command.Parameters.AddWithValue("@TestTypeTitle", testTypeEntity.Title);
                command.Parameters.AddWithValue("@TestTypeDescription", testTypeEntity.Description);
                command.Parameters.AddWithValue("@TestTypeFees", testTypeEntity.Fees);

                try
                {
                    connection.Open();

                    return command.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    throw new ApplicationException($"Error: update test type.\n{ex.Message}", ex);
                }

            }
        }

    }
}
