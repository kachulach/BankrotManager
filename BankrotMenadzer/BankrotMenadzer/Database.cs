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

        public bool UsernameExists(string username)
        {
            string query = "SELECT 1 FROM user WHERE username='" + username+"'";
            MySqlConnection con = getConnection();
            bool result = false;
            try
            {
                con.Open();

                MySqlCommand command = new MySqlCommand(query, con);
                MySqlDataReader r = command.ExecuteReader();

                if (r.Read()) 
                {
                    result = Convert.ToInt32(r["1"]) == 1;
                }
                
            }
            catch (Exception e)
            {
                result = false;
            }
            finally
            {
                con.Close();
            }
            return result;
        }
        public bool addToSaveFunds(int user_id, int sum)
        {
            MySqlConnection con = getConnection();
            bool result = true;
            try
            {
                con.Open();

                string queryUpdateUser = "UPDATE user SET " +
                                       "funds=funds-" + sum + ", saved_funds=saved_funds+" + sum +
                                       " WHERE user_id=" + user_id;

                MySqlCommand command = new MySqlCommand(queryUpdateUser, con);
                command.Prepare();

                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                result = false;
            }
            finally
            {
                con.Close();
            }
            return result;
        }
        public List<Transaction> getAffordableItemsWishlist(int user_id, int money)
        {
            MySqlConnection con = getConnection();

            try
            {
                con.Open();

                string query = "SELECT * FROM transaction "+
                    "WHERE wishlist=true AND bought=false AND price <= " + money +
                    " user_id="+user_id;

                MySqlDataAdapter adapter = new MySqlDataAdapter(query, con);

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
                    int kom_id = Convert.ToInt32(row["comment_id"]);
                    bool wish = Convert.ToBoolean(row["wishlist"]);
                    bool bo = Convert.ToBoolean(row["bought"]);
                    
                    transactions.Add(new Transaction(tran_id, name, cat_id, price, datum, kom_id, user_id, wish, bo));
                }
                return transactions;
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
                if (wishlist)
                {
                    command.Parameters.AddWithValue("@bought", false);
                }
                else
                {
                    command.Parameters.AddWithValue("@bought", true);
                    if (category_id != 27)
                    {
                        result += updateUserFunds(user_id, price);
                    }
                    
                }
                //Pri dodavanje na savefunds ZADOLZITELNO prakanje na category_id 27
                if (category_id == 27)
                {
                    result += addToSaveFunds(user_id, price);
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
                    if (category_id != 27)
                    {
                        result += updateUserFunds(user_id, price);
                    }
                }

                if (category_id == 27)
                {
                    result += addToSaveFunds(user_id, price);
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

        public User addUser(string username, string password, string name, string email)
        {
            long returnId = -1;
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
                returnId = command.LastInsertedId;
            }
            catch (Exception e)
            {
                result = e.Message;
            }
            finally
            {
                con.Close();
            }

            return new User()
            {
                email = email,
                funds =  0,
                SavedFunds= 0,
                name = name,
                password =  "xxx",
                user_id =(int) returnId,
                username = username
            };
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
        private int getUserIdFromTransactionId(int transaction_id) 
        {
            MySqlConnection con = getConnection();
            int user_id = -1;
            
            try
            {
                con.Open();
                string query = "SELECT user_id FROM transaction WHERE transaction_id=" + transaction_id;
                MySqlCommand command = new MySqlCommand(query, con);

                MySqlDataReader r = command.ExecuteReader();

                if (r.Read()) {
                    user_id = Convert.ToInt32(r["user_id"]);
                }
            }
            catch (Exception e)
            {
                user_id = -1;
            }
            finally
            {
                con.Close();
            }
            return user_id;
        }
        private int getTransactionPrice(int transaction_id)
        {
            MySqlConnection con = getConnection();
            int price = Int32.MaxValue;

            try
            {
                con.Open();
                string query = "SELECT price FROM transaction WHERE transaction_id=" + transaction_id;
                MySqlCommand command = new MySqlCommand(query, con);

                MySqlDataReader r = command.ExecuteReader();

                if (r.Read())
                {
                    price = Convert.ToInt32(r["price"]);
                }
            }
            catch (Exception e)
            {
                price = Int32.MaxValue;
            }
            finally
            {
                con.Close();
            }
            return price;
        }
        public string buyItemFromWishlist(int transaction_id)
        {
            int user_id = getUserIdFromTransactionId(transaction_id);
            if (user_id == -1) return "error user_id: -1";
            
            int saved_funds = getSavedFunds(user_id);
            int funds = currentFunds(user_id);

            int price = getTransactionPrice(transaction_id);
            if (price == Int32.MaxValue) return "error transaction price for transaction_id:" + transaction_id;

            int priceSaved = Math.Min(saved_funds, price);
            int priceFunds = price - priceSaved;

            MySqlConnection con = getConnection();
            string result = "Ok";
            try
            {
                con.Open();

                string queryUpdateTransaction = 
                                "UPDATE transaction " +
                                "SET bought=TRUE " +
                                "WHERE transaction_id="+transaction_id;
                string queryUpdateUserFunds = 
                                "UPDATE user "+
                                "SET funds=funds-" + priceFunds +" "+
                                "WHERE user_id=" + user_id;

                string queryUpdateUserSavedFunds =
                                "UPDATE user " +
                                "SET saved_funds=saved_funds-" + priceSaved + " " +
                                "WHERE user_id=" + user_id;

                string transactionQuery = 
                    "START TRANSACTION; " +
                    queryUpdateTransaction + "; " +
                    queryUpdateUserFunds + "; " +
                    queryUpdateUserSavedFunds + "; " +
                    "COMMIT;";

                MySqlCommand command = new MySqlCommand(transactionQuery, con);
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
        public int getSavedFunds(int user_id)
        {
            MySqlConnection con = getConnection();

            try
            {
                con.Open();

                string query = "SELECT saved_funds FROM user " +
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

        internal static User authenticateUser(string username, string password)
        {
            //da se naprave funkcija za avtentikacija na korisnikot i da vrakja User so site parametri so gi ima za user
            Database db = new Database();
            MySqlConnection konekcija = db.getConnection();

            string sqlString = "SELECT * FROM user WHERE username=@username " +
                "AND password=AES_ENCRYPT(@password, SHA1(@username))";// AND is_active = 1";
            // neznam so e is_active zatoa e iskomentirano :D nema takvo nesto vo bazata zacuvano :)
            
            MySqlCommand komanda = new MySqlCommand(sqlString, konekcija);
            komanda.Parameters.AddWithValue("@username", username);
            komanda.Parameters.AddWithValue("@password", password);

            try
            {
                konekcija.Open();
                MySqlDataReader citac = komanda.ExecuteReader();
                if (citac.Read())
                {
                    // mozi da se zemi i datumot koga e kreiran userot...
                    // dokolku se dodade pole vo User klasata za datum
                    // u.datum = citac["datum"]
                    User u = new User();
                    u.username = citac["username"] as string;
                    u.name = citac["name"] as string;
                    u.user_id = int.Parse(citac["user_id"].ToString());;
                    u.funds = int.Parse(citac["funds"].ToString());;
                    u.email = citac["e_mail"] as string;
                    
                    // u.user_id = int.Parse(citac["user_id"].ToString());
                    // u.name = citac["first_name"].ToString();
                    // u.last_name = citac["last_name"].ToString();
                    // u.organization_id = int.Parse(citac["organization_id"].ToString());

                    return u;
                }
                else
                    return null;
            }
            catch (Exception err)
            {
                Console.Write(err.ToString());
            }
            finally
            {
                konekcija.Close();
            }
            
            return null;
        }

        internal void removeTransaction(int transaction_id)
        {
            //da se izbrise transakcijata so toa id
            throw new NotImplementedException();
        }
    }
}