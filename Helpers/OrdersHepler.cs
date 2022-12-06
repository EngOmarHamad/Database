

using Game_Store.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace Game_Store.Helpers
{
    internal static class OrdersHepler
    {
        private static string StringConnectionOmar => ConfigurationManager.ConnectionStrings["SqlOmar"].ConnectionString;
        private static string StringConnectionMohammed => ConfigurationManager.ConnectionStrings["SqlMohammed"].ConnectionString;

        public static List<orders> GetAllOrders()
        {
            List<orders> orderList = new List<orders>();

            try
            {
                using (SqlConnection connection = new SqlConnection(StringConnectionOmar))
                {
                    SqlCommand command = connection.CreateCommand();
                    connection.Open();
                    command.CommandText = "GetAllOrders";
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {

                        orderList.Add(new orders()
                        {
                            order_id = Convert.ToInt32(reader[0]),
                            user_id = Convert.ToInt32(reader[1]),
                            game_id = Convert.ToInt32(reader[2]),
                            price = Convert.ToInt32(reader[3]),
                            payment_id = Convert.ToInt32(reader[4]),
                            date = Convert.ToDateTime(reader[5]),

                        });



                    }

                    reader.Close();

                }

            }
            catch (Exception EX)
            {

                throw EX;
            }

            return orderList;
        }

        public static int AddOrder(orders order)
        {
            int count = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(StringConnectionOmar))
                {
                    SqlCommand command = new SqlCommand();
                    connection.Open();
                    command.CommandText = "AddOrder";
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@order_id", order.order_id);
                    command.Parameters.AddWithValue("@user_id", order.user_id);
                    command.Parameters.AddWithValue("@game_id", order.game_id);
                    command.Parameters.AddWithValue("@price", order.price);
                    command.Parameters.AddWithValue("@payment_id", order.payment_id);
                    command.Parameters.AddWithValue("@date", order.date);

                    count = command.ExecuteNonQuery();


                }

            }
            catch (Exception EX)
            {

                throw EX;
            }

            return count;
        }


        public static int UpdateOrder(orders order)
        {
            int count = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(StringConnectionOmar))
                {
                    SqlCommand command = new SqlCommand();
                    connection.Open();
                    command.CommandText = "UpdateOrder";
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@order_id", order.order_id);
                    command.Parameters.AddWithValue("@user_id", order.user_id);
                    command.Parameters.AddWithValue("@game_id", order.game_id);
                    command.Parameters.AddWithValue("@price", order.price);
                    command.Parameters.AddWithValue("@payment_id", order.payment_id);
                    command.Parameters.AddWithValue("@date", order.date);
                    count = command.ExecuteNonQuery();


                }

            }
            catch (Exception EX)
            {

                throw EX;
            }

            return count;
        }


        public static int DeleteOrderbyId(orders order)
        {
            int count = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(StringConnectionOmar))
                {
                    SqlCommand command = new SqlCommand();
                    connection.Open();
                    command.CommandText = "DeleteOrder";
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@order_id", order.order_id);
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
