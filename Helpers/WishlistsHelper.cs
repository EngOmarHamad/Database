
using Game_Store.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace Game_Store.Helpers
{
    internal static class WishlistsHelper
    {
        private static string StringConnectionOmar => ConfigurationManager.ConnectionStrings["SqlOmar"].ConnectionString;
        private static string StringConnectionMohammed => ConfigurationManager.ConnectionStrings["SqlMohammed"].ConnectionString;

        public static List<Wishlists> GetAllWishlists()
        {
            List<Wishlists> Wishlists = new List<Wishlists>();

            try
            {
                using (SqlConnection connection = new SqlConnection(StringConnectionOmar))
                {
                    SqlCommand command = connection.CreateCommand();
                    connection.Open();
                    command.CommandText = "GetAllWishlists";
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {

                        Wishlists.Add(new Wishlists()
                        {
                            wish_id = Convert.ToInt32(reader[0]),
                            user_id = Convert.ToInt32(reader[1]),
                            game_id = Convert.ToInt32(reader[2]),
                            date = Convert.ToDateTime(reader[3]),

                        });



                    }

                    reader.Close();

                }

            }
            catch (Exception EX)
            {

                throw EX;
            }

            return Wishlists;
        }

        public static int AddWishlists(Wishlists Wishlists)
        {
            int count = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(StringConnectionOmar))
                {
                    SqlCommand command = new SqlCommand();
                    connection.Open();
                    command.CommandText = "AddWishlists";
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@wish_id", Wishlists.wish_id);
                    command.Parameters.AddWithValue("@user_id", Wishlists.user_id);
                    command.Parameters.AddWithValue("@game_id", Wishlists.game_id);
                    command.Parameters.AddWithValue("@date", Wishlists.date);

                    count = command.ExecuteNonQuery();


                }

            }
            catch (Exception EX)
            {

                throw EX;
            }

            return count;
        }
        public static int UpdateWishlists(Wishlists Wishlists)
        {
            int count = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(StringConnectionOmar))
                {
                    SqlCommand command = new SqlCommand();
                    connection.Open();
                    command.CommandText = "UpdateWishlists";
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@wish_id", Wishlists.wish_id);
                    command.Parameters.AddWithValue("@user_id", Wishlists.user_id);
                    command.Parameters.AddWithValue("@game_id", Wishlists.game_id);
                    command.Parameters.AddWithValue("@date", Wishlists.date);
                    count = command.ExecuteNonQuery();


                }

            }
            catch (Exception EX)
            {

                throw EX;
            }

            return count;
        }

        public static int DeleteWishlistsbyId(Wishlists Wishlists)
        {
            int count = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(StringConnectionOmar))
                {
                    SqlCommand command = new SqlCommand();
                    connection.Open();
                    command.CommandText = "DeleteWishlistsbyId";
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@wish_id", Wishlists.wish_id);
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
