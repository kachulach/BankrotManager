using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using BankrotManager.Models;
namespace BankrotManager
{
    public class Database
    {
        public MySqlConnection getConnection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString;
            return new MySqlConnection(connectionString);
        }


        //Return Transaction instead of String
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

        //TODO List<Category>
        public List<Category> getAllCategories()
        {
            MySqlConnection con = getConnection();

            try
            {
                con.Open();

                string query = "SELECT * FROM category";

                MySqlDataAdapter adapter = new MySqlDataAdapter(query, con);
                
                DataSet ds = new DataSet();

                adapter.Fill(ds);

                List<Category> categories = new List<Category>();
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    int id = Convert.ToInt32(row["category_id"]);
                    string name = row["name"] as String;
                    
                    categories.Add(new Category(id, name));
                }
                return categories;
            }
            catch (Exception e)
            {
                return null;
            }
            finally
            {
                con.Close();
            }

            /*
            List<Category> categories = new List<Category>();
            foreach (DataRow cat in cats)
            {
                categories.Add(new Category(int.Parse(cat["category_id"].ToString()), cat["name"].ToString()));
            }
            return categories;
             * 
             * Ja vaka za testiranje konvertirav data
            */

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
        public DataTable getWishlist(int user_id)
        {
            MySqlConnection con = getConnection();

            try
            {
                con.Open();

                string query = "SELECT * FROM transaction "+
                                "WHERE user_id=" + user_id + " AND wishlist=TRUE AND bought=FALSE";
                
                MySqlCommand command = new MySqlCommand(query, con);
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable dt = new DataTable();

                adapter.Fill(dt);
                return dt;
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

        public DataTable getBoughtItemsFromWishlist(int user_id)
        {
            MySqlConnection con = getConnection();

            try
            {
                con.Open();

                string query = "SELECT * FROM transaction " +
                                "WHERE user_id=" + user_id + " AND price < 0 AND wishlist=TRUE AND bought=TRUE order By datum DESC";

                MySqlCommand command = new MySqlCommand(query, con);
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable dt = new DataTable();

                adapter.Fill(dt);
                return dt;
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

        public DataTable getBoughtItems(int user_id)
        {
            MySqlConnection con = getConnection();

            try
            {
                con.Open();

                string query = "SELECT * FROM transaction " +
                                "WHERE user_id=" + user_id + " AND price < 0  AND bought=TRUE order by datum DESC";

                MySqlCommand command = new MySqlCommand(query, con);
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable dt = new DataTable();

                adapter.Fill(dt);
                return dt;
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

        
        public DataTable getIncomes(int user_id)
        {
            MySqlConnection con = getConnection();

            try
            {
                con.Open();

                string query = "SELECT * FROM transaction " +
                                "WHERE user_id=" + user_id + " AND price > 0 AND bought=TRUE AND wishlist=FALSE";

                MySqlCommand command = new MySqlCommand(query, con);
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable dt = new DataTable();

                adapter.Fill(dt);
                return dt;
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

        public string buyItemFromWishlist(int transaction_id)
        {
            MySqlConnection con = getConnection();
            string result = "Ok";
            try
            {
                con.Open();

                string query = "UPDATE transaction " +
                               "SET bought=TRUE " +
                               "WHERE transaction_id=@transaction_id";

                MySqlCommand command = new MySqlCommand(query, con);
                command.Prepare();
                command.Parameters.AddWithValue("@transaction_id", transaction_id);
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                result = "error: " + e.Message;
            }
            finally
            {
                con.Close();
            }
            return result;
        }

        //Ova moze bool da e
        public bool testConnection()
        {
            MySqlConnection con = getConnection();
            bool b = true;
            try
            {
                con.Open();
            }
            catch(Exception e)
            {
                b = false;
            }
            finally
            {
                con.Close();
            }

            return b;
        }

        public List<Transaction> getFromToTransactions(int user_id, DateTime from, DateTime to, int type = 0)
        {
            //TODO
            MySqlConnection con = getConnection();

            try
            {
                con.Open();

                string query = "SELECT * FROM transaction " +
                                "WHERE user_id=" + user_id +
                                " AND datum BETWEEN '" + from.ToString("yyyy-MM-dd HH:mm:ss")
                                + "' AND '" + to.ToString("yyyy-MM-dd HH:mm:ss") + "'";

                switch (type)
                {
                    case 0:
                        break;
                    case 1:
                        query += " AND price >= 0";
                        break;
                    case 2:
                        query += " AND price <= 0";
                        break;
                    case 3:
                        query += " AND wishlist = 1";
                        break;
                }

                MySqlCommand command = new MySqlCommand(query, con);
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataSet ds = new DataSet();
               
                adapter.Fill(ds);

                List<Transaction> transactions = new List<Transaction>();
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    int tran_id = Convert.ToInt32(row["transaction_id"]);
                    string name = row["name"] as String;
                    int cat_id = Convert.ToInt32(row["category_id"]);
                    int price = Convert.ToInt32(row["price"]);
                    DateTime datum = (DateTime) row["datum"];
                    int kom_id = -1;
                    if (row["comment_id"].GetType() != typeof(DBNull))
                    {
                        kom_id = Convert.ToInt32(row["comment_id"]);
                    }
                    bool wish = (bool)row["wishlist"];
                    bool bo = (bool)row["bought"];

                    transactions.Add(new Transaction(tran_id, name, cat_id, price,datum, kom_id, user_id, wish, bo));
                }
                return transactions;
                
            }
            catch (Exception e)
            {
                HttpContext.Current.Response.Write(e.Message);
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public User currentLoggedUser()
        {
            //TODO
            //NOTE Ova moze vo sesija da se pamti?
            // DEFINITIVNO vo sesija se cuva logiran user
            return null;
        }

        //Returns category_id from category name
        public int categoryID(string categoryName)
        {
            MySqlConnection con = getConnection();

            try
            {
                con.Open();

                string query = "SELECT category_id FROM category " +
                                "WHERE name=" + categoryName;

                MySqlCommand command = new MySqlCommand(query, con);
                MySqlDataReader res = command.ExecuteReader();
                while (res.Read())
                {
                    int id = res.GetInt32(0);
                    return id;
                }
                
                return -1;
            }
            catch (Exception e)
            {
                return -1;
            }
            finally
            {
                con.Close();
            }
        }

        //Current user funds
        public int currentFunds(int user_id)
        {
            MySqlConnection con = getConnection();

            try
            {
                con.Open();

                string query = "SELECT funds FROM user " +
                                "WHERE user_id=" + user_id;

                MySqlCommand command = new MySqlCommand(query, con);
                MySqlDataReader res = command.ExecuteReader();
                while (res.Read())
                {
                    int funds = res.GetInt32(0);
                    return funds;
                }

                return 0;
            }
            catch (Exception e)
            {
                return 0;
            }
            finally
            {
                con.Close();
            }
        }

    }
}