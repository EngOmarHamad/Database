

using Game_Store.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace Game_Store.Helpers
{
    internal static class StoresHelper
    {
        private static string StringConnectionOmar => ConfigurationManager.ConnectionStrings["SqlOmar"].ConnectionString;
        private static string StringConnectionMohammed => ConfigurationManager.ConnectionStrings["SqlMohammed"].ConnectionString;

        public static List<stores> GetAllStores()
        {
            List<stores> stores = new List<stores>();

            try
            {
                using (SqlConnection connection = new SqlConnection(StringConnectionOmar))
                {
                    SqlCommand command = connection.CreateCommand();
                    connection.Open();
                    command.CommandText = "GetAllstores";

                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {

                        stores.Add(new stores()
                        {
                            store_id = Convert.ToInt32(reader[0]),
                            country = Convert.ToString(reader[1]),

                        });



                    }

                    reader.Close();

                }

            }
            catch (Exception EX)
            {

                throw EX;
            }

            return stores;
        }

        public static int AddStore(stores stores)
        {
            int count = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(StringConnectionOmar))
                {
                    SqlCommand command = new SqlCommand();
                    connection.Open();
                    command.CommandText = "AddStore";
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@store_id", stores.store_id);
                    command.Parameters.AddWithValue("@country", stores.country);

                    count = command.ExecuteNonQuery();


                }

            }
            catch (Exception EX)
            {

                throw EX;
            }

            return count;
        }


        public static int UpdateStore(stores stores)
        {
            int count = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(StringConnectionOmar))
                {
                    SqlCommand command = new SqlCommand();
                    connection.Open();
                    command.CommandText = "UpdateStore";
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@store_id", stores.store_id);
                    command.Parameters.AddWithValue("@country", stores.country);
                    count = command.ExecuteNonQuery();


                }

            }
            catch (Exception EX)
            {

                throw EX;
            }

            return count;
        }


        public static int DeleteStorebyId(stores stores)
        {
            int count = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(StringConnectionOmar))
                {
                    SqlCommand command = new SqlCommand();
                    connection.Open();
                    command.CommandText = "DeleteStorebyId";
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@store_id", stores.store_id);
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
