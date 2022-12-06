

using Game_Store.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace Game_Store.Helpers
{
    internal static class UsersHelper
    {
        private static string StringConnectionOmar => ConfigurationManager.ConnectionStrings["SqlOmar"].ConnectionString;
        private static string StringConnectionMohammed => ConfigurationManager.ConnectionStrings["SqlMohammed"].ConnectionString;

        public static List<users> GetAllUsers()
        {
            List<users> users = new List<users>();

            try
            {
                using (SqlConnection connection = new SqlConnection(StringConnectionOmar))
                {
                    SqlCommand command = connection.CreateCommand();
                    connection.Open();
                    command.CommandText = "GetAllUsers";
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {

                        users.Add(new users()
                        {
                            user_id = Convert.ToInt32(reader[0]),
                            name = Convert.ToString(reader[1]),
                            surname = Convert.ToString(reader[2]),
                            username = Convert.ToString(reader[3]),
                            password = Convert.ToInt32(reader[4]),
                            gender = Convert.ToString(reader[5]),
                            age = Convert.ToInt32(reader[6]),
                            email = Convert.ToString(reader[7]),
                            store_id = Convert.ToInt32(reader[8]),



                        });



                    }

                    reader.Close();

                }

            }
            catch (Exception EX)
            {

                throw EX;
            }

            return users;
        }

        public static int AddUsers(users users)
        {
            int count = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(StringConnectionOmar))
                {
                    SqlCommand command = new SqlCommand();
                    connection.Open();
                    command.CommandText = "AddUsers";
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@user_id", users.user_id);
                    command.Parameters.AddWithValue("@name", users.name);
                    command.Parameters.AddWithValue("@surname", users.surname);
                    command.Parameters.AddWithValue("@username", users.username);
                    command.Parameters.AddWithValue("@password", users.password);
                    command.Parameters.AddWithValue("@gender", users.gender);
                    command.Parameters.AddWithValue("@age", users.age);
                    command.Parameters.AddWithValue("@email", users.email);
                    command.Parameters.AddWithValue("@store_id", users.store_id);

                    count = command.ExecuteNonQuery();


                }

            }
            catch (Exception EX)
            {

                throw EX;
            }

            return count;
        }


        public static int UpdateUsers(users users)
        {
            int count = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(StringConnectionOmar))
                {
                    SqlCommand command = new SqlCommand();
                    connection.Open();
                    command.CommandText = "UpdateUsers";
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@user_id", users.user_id);
                    command.Parameters.AddWithValue("@name", users.name);
                    command.Parameters.AddWithValue("@surname", users.surname);
                    command.Parameters.AddWithValue("@username", users.username);
                    command.Parameters.AddWithValue("@password", users.password);
                    command.Parameters.AddWithValue("@gender", users.gender);
                    command.Parameters.AddWithValue("@age", users.age);
                    command.Parameters.AddWithValue("@email", users.email);
                    command.Parameters.AddWithValue("@store_id", users.store_id);
                    count = command.ExecuteNonQuery();


                }

            }
            catch (Exception EX)
            {

                throw EX;
            }

            return count;
        }


        public static int DeleteUsersbyId(users users)
        {
            int count = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(StringConnectionOmar))
                {
                    SqlCommand command = new SqlCommand();
                    connection.Open();
                    command.CommandText = "DeleteUsersbyId";
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@user_id", users.user_id);
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
