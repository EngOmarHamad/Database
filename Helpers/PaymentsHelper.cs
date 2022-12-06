

using Game_Store.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace Game_Store.Helpers
{
    internal static class PaymentsHelper
    {
        private static string StringConnectionOmar => ConfigurationManager.ConnectionStrings["SqlOmar"].ConnectionString;
        private static string StringConnectionMohammed => ConfigurationManager.ConnectionStrings["SqlMohammed"].ConnectionString;

        public static List<payments> GetAllPayments()
        {
            List<payments> payments = new List<payments>();

            try
            {
                using (SqlConnection connection = new SqlConnection(StringConnectionOmar))
                {
                    SqlCommand command = connection.CreateCommand();
                    connection.Open();
                    command.CommandText = "GetAllPayments";
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {

                        payments.Add(new payments()
                        {
                            payment_id = Convert.ToInt32(reader[0]),
                            user_id = Convert.ToInt32(reader[1]),
                            payment_type = Convert.ToString(reader[2]),
                            card_number = Convert.ToInt32(reader[3]),
                            valid = Convert.ToInt32(reader[4]),

                        });



                    }

                    reader.Close();

                }

            }
            catch (Exception EX)
            {

                throw EX;
            }

            return payments;
        }

        public static int AddPayment(payments payment)
        {
            int count = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(StringConnectionOmar))
                {
                    SqlCommand command = new SqlCommand();
                    connection.Open();
                    command.CommandText = "AddPayment";
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@payment_id", payment.payment_id);
                    command.Parameters.AddWithValue("@user_id", payment.user_id);
                    command.Parameters.AddWithValue("@payment_type", payment.payment_type);
                    command.Parameters.AddWithValue("@card_number", payment.card_number);
                    command.Parameters.AddWithValue("@valid", payment.valid);
                    count = command.ExecuteNonQuery();


                }

            }
            catch (Exception EX)
            {

                throw EX;
            }

            return count;
        }


        public static int UpdatePayment(payments payment)
        {
            int count = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(StringConnectionOmar))
                {
                    SqlCommand command = new SqlCommand();
                    connection.Open();
                    command.CommandText = "UpdatePayment";
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@payment_id", payment.payment_id);
                    command.Parameters.AddWithValue("@user_id", payment.user_id);
                    command.Parameters.AddWithValue("@payment_type", payment.payment_type);
                    command.Parameters.AddWithValue("@card_number", payment.card_number);
                    command.Parameters.AddWithValue("@valid", payment.valid);
                    count = command.ExecuteNonQuery();


                }

            }
            catch (Exception EX)
            {

                throw EX;
            }

            return count;
        }


        public static int DeletePaymentbyId(payments payment)
        {
            int count = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(StringConnectionOmar))
                {
                    SqlCommand command = new SqlCommand();
                    connection.Open();
                    command.CommandText = "DeletePayment";
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@payment_id", payment.payment_id);
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
