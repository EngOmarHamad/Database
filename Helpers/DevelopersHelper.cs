

using Game_Store.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace Game_Store.Helpers
{
    internal static class DevelopersHelper
    {
        private static string StringConnectionOmar => ConfigurationManager.ConnectionStrings["SqlOmar"].ConnectionString;
        private static string StringConnectionMohammed => ConfigurationManager.ConnectionStrings["SqlMohammed"].ConnectionString;

        public static List<Developer> GetAllDevelopers()
        {
            List<Developer> Developers = new List<Developer>();

            try
            {
                using (SqlConnection connection = new SqlConnection(StringConnectionOmar))
                {
                    SqlCommand command = connection.CreateCommand();
                    connection.Open();
                    command.CommandText = "GetAllDevelopers";
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Connection = connection;
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {

                        Developers.Add(new Developer()
                        {
                            developer_id = Convert.ToInt32(reader[0]),
                            name = Convert.ToString(reader[1]),
                            website = Convert.ToString(reader[2]),
                        });



                    }

                    reader.Close();

                }

            }
            catch (Exception EX)
            {

                throw EX;
            }

            return Developers;
        }

        public static int AddDevelopers(Developer developer)
        {
            int count = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(StringConnectionOmar))
                {
                    SqlCommand command = new SqlCommand();
                    connection.Open();
                    command.CommandText = "AddDevelopers";
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@developer_id", developer.developer_id);
                    command.Parameters.AddWithValue("@name", developer.name);
                    command.Parameters.AddWithValue("@website", developer.website);
                    count = command.ExecuteNonQuery();


                }

            }
            catch (Exception EX)
            {

                throw EX;
            }

            return count;
        }


        public static int UpdateDevelopers(Developer developer)
        {
            int count = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(StringConnectionOmar))
                {
                    SqlCommand command = new SqlCommand();
                    connection.Open();
                    command.CommandText = "UpdateDeveloper";
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@developer_id", developer.developer_id);
                    command.Parameters.AddWithValue("@name", developer.name);
                    command.Parameters.AddWithValue("@website", developer.website);
                    count = command.ExecuteNonQuery();


                }

            }
            catch (Exception EX)
            {

                throw EX;
            }

            return count;
        }


        public static int DeleteDeveloperById(Developer developer)
        {
            int count = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(StringConnectionOmar))
                {
                    SqlCommand command = new SqlCommand();
                    connection.Open();
                    command.CommandText = "DeleteDevelpor";
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@developer_id", developer.developer_id);
                    count = command.ExecuteNonQuery();
                }

            }
            catch (Exception EX)
            {

                throw EX;
            }

            return count;
        }


    }
}
