

using Game_Store.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace Game_Store.Helpers
{
    internal static class GamesHelper
    {
        private static string StringConnectionOmar => ConfigurationManager.ConnectionStrings["SqlOmar"].ConnectionString;
        private static string StringConnectionMohammed => ConfigurationManager.ConnectionStrings["SqlMohammed"].ConnectionString;

        public static List<Game> GetAllGames()
        {
            List<Game> games = new List<Game>();

            try
            {
                using (SqlConnection connection = new SqlConnection(StringConnectionOmar))
                {
                    SqlCommand command = connection.CreateCommand();
                    connection.Open();
                    command.CommandText = "GetAllGames";
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {

                        games.Add(new Game()
                        {
                            game_id = Convert.ToInt32(reader[0]),
                            name = Convert.ToString(reader[1]),
                            developer = Convert.ToInt32(reader[2]),
                            publisher = Convert.ToInt32(reader[3]),
                            store_id = Convert.ToInt32(reader[4]),
                            genre = Convert.ToString(reader[5]),
                            price = Convert.ToInt32(reader[6]),
                            review = Convert.ToInt32(reader[7]),
                            age_limit = Convert.ToInt32(reader[8]),
                            release_date = Convert.ToDateTime(reader[9]),
                            except_country = Convert.ToString(reader[10]),
                            description = Convert.ToString(reader[11]),
                            isObtainble = Convert.ToString(reader[11]) == "N" ? false : true,
                        });



                    }

                    reader.Close();

                }

            }
            catch (Exception EX)
            {

                throw EX;
            }

            return games;
        }

        public static int AddGame(Game game)
        {
            int count = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(StringConnectionOmar))
                {
                    SqlCommand command = new SqlCommand();
                    connection.Open();
                    command.CommandText = "AddGame";
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@name", game.name);
                    command.Parameters.AddWithValue("@developer", game.developer);
                    command.Parameters.AddWithValue("@publisher", game.publisher);
                    command.Parameters.AddWithValue("@store_id", game.store_id);
                    command.Parameters.AddWithValue("@genre", game.genre);
                    command.Parameters.AddWithValue("@price", game.price);
                    command.Parameters.AddWithValue("@review", game.review);
                    command.Parameters.AddWithValue("@age_limit", game.age_limit);
                    command.Parameters.AddWithValue("@release_date", game.release_date);
                    command.Parameters.AddWithValue("@except_country", game.except_country);
                    command.Parameters.AddWithValue("@description", game.description);
                    command.Parameters.AddWithValue("@isObtainble", game.isObtainble);
                    count = command.ExecuteNonQuery();
                }

            }
            catch (Exception EX)
            {

                throw EX;
            }

            return count;
        }


        public static int UpdateGame(Game game)
        {
            int count = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(StringConnectionOmar))
                {
                    SqlCommand command = new SqlCommand();
                    connection.Open();
                    command.CommandText = "UpdateGame";
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@game_id", game.game_id);
                    command.Parameters.AddWithValue("@name", game.name);
                    command.Parameters.AddWithValue("@developer", game.developer);
                    command.Parameters.AddWithValue("@publisher", game.publisher);
                    command.Parameters.AddWithValue("@store_id", game.store_id);
                    command.Parameters.AddWithValue("@genre", game.genre);
                    command.Parameters.AddWithValue("@price", game.price);
                    command.Parameters.AddWithValue("@review", game.review);
                    command.Parameters.AddWithValue("@age_limit", game.age_limit);
                    command.Parameters.AddWithValue("@release_date", game.release_date);
                    command.Parameters.AddWithValue("@except_country", game.except_country);
                    command.Parameters.AddWithValue("@description", game.description);
                    command.Parameters.AddWithValue("@isObtainble", game.isObtainble);

                    count = command.ExecuteNonQuery();


                }

            }
            catch (Exception EX)
            {

                throw EX;
            }

            return count;
        }


        public static int DeleteGamebyId(Game game)
        {
            int count = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(StringConnectionOmar))
                {
                    SqlCommand command = new SqlCommand();
                    connection.Open();
                    command.CommandText = "DeleteGamebyId";
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@game_id", game.game_id);
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
