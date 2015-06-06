using BankrotManager;
using BankrotManager.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BankrotManager
{
    public enum TransactionType
    {
        Spending = 1,
        Saving = 2,
        Wishlist = 3,
    }

    public partial class Default : System.Web.UI.Page
    {

        Database database;
        public static Dictionary<int, string> Categories;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (repeater_categories != null)
            {
                Categories = new Dictionary<int, string> {{0, "Not categorized"}};

                if (!HelperTools.isInitialized)
                {
                    HelperTools.Initialize();
                }

                repeater_categories.DataSource = HelperTools.Categories;
                repeater_categories.DataBind();
            }
            //Test user
            Session["user_id"] = 4;
        }
        /// <summary>
        /// AJAX Call with data from the website.
        /// </summary>
        [WebMethod(EnableSession = true)]
        public static string AJAX_AddTransaction(string type, string name, string amount, string category, string comment)
        {
            //DB query to add transaction and return new daily transaction state
            TransactionType tType = TransactionType.Spending;
            switch (type)
            {
                case "1":
                    tType = TransactionType.Saving;
                    break;
                case "2":
                    tType = TransactionType.Spending;
                    break;
                case "3":
                    tType = TransactionType.Wishlist;
                    break;
            }

            if (string.IsNullOrWhiteSpace(name))
            {
                return "{ }";
            }

            int amt = -1;
            if (string.IsNullOrWhiteSpace(amount))
            {
                return "{ }";
            }
            amt = int.Parse(amount);

            if (string.IsNullOrWhiteSpace(category))
            {
                return "{ }";
            }
            var cat = int.Parse(category);


            return ValidateAndAdd(tType, name, amt, cat, comment).ToString();
        }

        private static Transaction ValidateAndAdd(TransactionType type, string name, int amount, int category_id, string comment)
        {
            Database db = new Database();
            var user = int.Parse(HttpContext.Current.Session["user_id"].ToString());
            int comment_id = -1;
            if (!string.IsNullOrWhiteSpace(comment))
            {

                comment_id = (int)db.addComment(comment);
                db.addTransaction(category_id, user, (int)comment_id, amount, DateTime.Now, name, type == TransactionType.Wishlist);
            }
            else
            {
                db.addTransactionBezKomentar(category_id, user, amount, DateTime.Now, name, type == TransactionType.Wishlist);
            }

            return new Transaction()
            {
                Category = new Category(category_id, HelperTools.Categories[category_id]),
                Date = DateTime.Now,
                Type = (int)type,
                Amount = amount,
                Comment_ID = comment_id,
                ID = -1,
                Name = name
            };
        }

        [WebMethod]
        public static string AJAX_DailyStats()
        {
            Database db = new Database();
            var transactions = db.getFromToTransactions(int.Parse(HttpContext.Current.Session["user_id"].ToString()), DateTime.Now.Subtract(new TimeSpan(1, 0, 0, 0, 0)), DateTime.Now);
            //return chart data
            return HelperTools.FormatToChartData(transactions);
        }

        [WebMethod]
        public static string AJAX_TransactionData(string from, string to)
        {
            DateTime dateFrom = Convert.ToDateTime(from);
            DateTime dateTo = Convert.ToDateTime(to);

            Database db = new Database();
            var transactions = db.getFromToTransactions(int.Parse(HttpContext.Current.Session["user_id"].ToString()), dateFrom, dateTo);
            //return chart data
            return HelperTools.FormatTransactions(transactions);
        }

        [WebMethod]
        public static string AJAX_GetChartData(string from, string to)
        {
            Database db = new Database();
            var transactions = db.getFromToTransactions(int.Parse(HttpContext.Current.Session["user_id"].ToString()), DateTime.Now.Subtract(new TimeSpan(1, 0, 0, 0, 0)), DateTime.Now);
            //return chart data
            return HelperTools.FormatToChartData(transactions);
        }


        private static void dodadiTransakcija(TransactionType type, string name, int amount, int category_id, DateTime date, string comment)
        {
            Database db = new Database();
            if (type == null || name == null || amount < 0 || category_id < 0 || date == null)
            {
                return;
            }
            ///* Ova  nadolu seto e tocno no e za verzijata pred dodavanje na bootstrap :)

            int type_t = 1;
            if (type == TransactionType.Spending)
            {
                type_t = 2;
            }
            if (type == TransactionType.Wishlist)
            {
                type_t = 3;
            }

            bool wishlist = type_t == 3;
            if (type_t != 1)
            {
                amount *= -1;
            }

            //Da se komentira ovaa linija koga ke se dodade pole za datum vo dizajnot
            date = DateTime.Now;

            // dali e ne prazen komentarot
            int comment_id = 0;
            if (!comment.Trim().Equals(""))
            {
                //string comment = tbComment.Text;
                comment_id = (int)db.addComment(comment);
                //Dodavanje na komentar u baza
                //Zemanje na indeks od baza za komentarot
            }
            int user_id = 1;

            //da se smeni so dolnata linija koga ke se raboti Login
            //int user_id = int.Parse(HttpContext.Current.Session["user_id"].ToString());


            //Funkcija za dodavanje u baza so parametrite od pogore

            //Ako e wishlist, dodavanje u tabela za wishlist kreiranata transakcija
            if (comment_id != 0)
            {
                db.addTransaction(category_id, user_id, comment_id, amount, date, name, wishlist);
            }
            else
            {
                db.addTransactionBezKomentar(category_id, user_id, amount, date, name, wishlist);
            }
        }

        protected void btnAddExpenditure_Click(object sender, ImageClickEventArgs e)
        {
            //dodadiTransakcija(2);
        }

        protected void btnAddIncome_Click(object sender, ImageClickEventArgs e)
        {
            //dodadiTransakcija(1);
        }

        protected void btnAddWish_Click(object sender, ImageClickEventArgs e)
        {
            // dodadiTransakcija(3);
        }
    }
}
