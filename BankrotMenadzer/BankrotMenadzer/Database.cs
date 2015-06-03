using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
namespace BankrotMenadzer
{
    public class Database
    {
        public MySqlConnection getConnection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString;
            return new MySqlConnection(connectionString);
        }

        public string addTransaction(int category_id, int user_id, int comment_id, int price, DateTime datum,
            string name, bool wishlist)
        {
            MySqlConnection con = getConnection();
            string result = "OK";
            try
            {
                con.Open();

                string query = "INSERT INTO transaction (name,category_id,price,datum,"+
                                                        "comment_id,user_id,wishlist,bought)"+
                        " VALUES (@name, @category_id, @price, @datum," +
                                 "@comment_id, @user_id, @wishlist, @bought)";

                MySqlCommand command = new MySqlCommand(query, con);
                command.Prepare();
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@category_id", category_id);
                command.Parameters.AddWithValue("@price", price);
                command.Parameters.AddWithValue("@datum", datum);
                command.Parameters.AddWithValue("@comment_id", comment_id);
                command.Parameters.AddWithValue("@user_id", user_id);
                command.Parameters.AddWithValue("@wishlist", wishlist);
                if(wishlist)
                    command.Parameters.AddWithValue("@bought", false);
                else
                {
                    command.Parameters.AddWithValue("@bought", true);
                    result += updateUserFunds(user_id, price);
                }

                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                result = e.Message;
            }
            finally
            {
                con.Close();
            }
            return result;
        }

        public string addTransactionBezKomentar(int category_id, int user_id, int price, DateTime datum,
            string name, bool wishlist)
        {
            MySqlConnection con = getConnection();
            string result = "OK";
            try
            {
                con.Open();

                string query = "INSERT INTO transaction (name,category_id,price,datum," +
                                                        "user_id,wishlist,bought)" +
                        " VALUES (@name, @category_id, @price, @datum," +
                                 "@user_id, @wishlist, @bought)";

                MySqlCommand command = new MySqlCommand(query, con);
                command.Prepare();
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@category_id", category_id);
                command.Parameters.AddWithValue("@price", price);
                command.Parameters.AddWithValue("@datum", datum);
                command.Parameters.AddWithValue("@user_id", user_id);
                command.Parameters.AddWithValue("@wishlist", wishlist);
                if (wishlist)
                    command.Parameters.AddWithValue("@bought", false);
                else
                {
                    command.Parameters.AddWithValue("@bought", true);
                    result += updateUserFunds(user_id, price);
                }

                command.ExecuteNonQuery();
                
            }
            catch (Exception e)
            {
                result = e.Message;
            }
            finally
            {
                con.Close();
            }
            return result;
        }

        public string updateUserFunds(int user_id, int money)
        {
            MySqlConnection con = getConnection();
            string result = "uf";
            try
            {
                con.Open();

                string query = "UPDATE user " + 
                               "SET funds=funds + @money "+
                               "WHERE user_id=@user_id";

                MySqlCommand command = new MySqlCommand(query, con);
                command.Prepare();
                command.Parameters.AddWithValue("@money", money);
                command.Parameters.AddWithValue("@user_id", user_id);
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                result = "uf error: " + e.Message; 
            }
            finally
            {
                con.Close();
            }
            return result;
        }
        public string addNewCategory(string name)
        {
            string result = "Ok";
            MySqlConnection con = getConnection();

            try
            {
                con.Open();

                string query = "INSERT INTO category (name)"+
                                " VALUE (@name)";

                MySqlCommand command = new MySqlCommand(query, con);
                command.Prepare();
                command.Parameters.AddWithValue("@name", name);
                
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                result = e.Message;
            }
            finally
            {
                con.Close();
            }
            return result;
        }

        public DataSet getAllCategories()
        {
            MySqlConnection con = getConnection();

            try
            {
                con.Open();

                string query = "SELECT * FROM category";

                MySqlDataAdapter adapter = new MySqlDataAdapter(query, con);
                DataSet ds = new DataSet();

                adapter.Fill(ds);

                return ds;
            }
            catch (Exception e)
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public long addComment(string komentar)
        {
            MySqlConnection con = getConnection();

            try
            {
                con.Open();

                string query = "INSERT INTO komentar (komentar)" +
                                " VALUE (@komentar)";

                MySqlCommand command = new MySqlCommand(query, con);
                command.Prepare();
                command.Parameters.AddWithValue("@komentar", komentar);
                command.ExecuteNonQuery();

                long id = command.LastInsertedId;
                return id;
            }
            catch (Exception e)
            {
            }
            finally
            {
                con.Close();
            }
            return -1;
        }

        public string addUser(string username, string password, string name, string email)
        {
            MySqlConnection con = getConnection();
            string result = "OK";
            try
            {
                con.Open();

                string query = "INSERT INTO user (username, password,name, datum, e_mail)" +
                        " VALUES (@username, AES_ENCRYPT(@password, SHA1(@username)), @name, @datum,@e_mail)";

                MySqlCommand command = new MySqlCommand(query, con);
                command.Prepare();
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@password", password);
                command.Parameters.AddWithValue("@datum", DateTime.Now);
                command.Parameters.AddWithValue("@e_mail", email);
                command.Parameters.AddWithValue("@username", username);

                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                result = e.Message;
            }
            finally
            {
                con.Close();
            }
            return result;
        }

        public string testConnection()
        {
            MySqlConnection con = getConnection();
            string b = "Ok";
            try
            {
                con.Open();
            }
            catch(Exception e)
            {
                b = e.Message;
            }
            finally
            {
                con.Close();
            }

            return b;
        }

    }
}