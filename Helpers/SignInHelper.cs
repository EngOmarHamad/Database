using Game_Store.Models;
using System;
using System.Configuration;
using System.Data.SqlClient;

namespace Game_Store.Helpers
{

    internal static class SignInHelper
    {
        private static string StringConnectionOmar => ConfigurationManager.ConnectionStrings["SqlOmar"].ConnectionString;
        private static string StringConnectionMohammed => ConfigurationManager.ConnectionStrings["SqlMohammed"].ConnectionString;

        public static int Login(users users)
        {
            int count = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(StringConnectionOmar))
                {
                    SqlCommand command = new SqlCommand();
                    connection.Open();
                    command.CommandText = "ProcSignInUser";
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@user_name", users.username);
                    command.Parameters.AddWithValue("@password", users.password);
                    SqlDataReader sqlDataReaderreader = command.ExecuteReader();
                    sqlDataReaderreader.Read();
                    string user = sqlDataReaderreader[0].ToString();
                    string password = sqlDataReaderreader[1].ToString();

                    if (user != null && password != null)
                    {
                        count = 1;
                    }



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

