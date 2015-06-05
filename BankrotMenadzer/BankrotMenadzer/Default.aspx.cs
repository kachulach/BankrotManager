using BankrotMenadzer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BankrotManager
{
    public enum TransactionType {
        Spending,
        Saving,
        Wishlist
    }

    public partial class Default : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }


        /// <summary>
        /// AJAX Call with data from the website.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="name"></param>
        /// <param name="amount"></param>
        /// <param name="category"></param>
        /// <param name="comment"></param>
        /// <returns></returns>
        [WebMethod]
        public static string AJAX_AddTransaction(string type, string name, string amount, string category, string comment)
        {
            //DB query to add transaction and return new daily transaction state
            return string.Format("{0}, {1}, {2}, {3}, {4}", type, name, amount, category, comment);
        }

        [WebMethod]
        public static string AJAX_GetChartData(string from, string to)
        {
            //DB query from-to transactions raw data
            //return chart data
            return from + to;
        }


        private static void dodadiTransakcija(TransactionType type, string name, int amount, int category_id, DateTime date, string comment)
        {

            if (type == null || name == null || amount < 0 || category_id < 0 || date == null)
            {
                return;
            }
            ///* Ova  nadolu seto e tocno no e za verzijata pred dodavanje na bootstrap :)
            Database db = new Database();

            int type_t = 1;
            if (type == TransactionType.Spending)
            {
                type_t=2;
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
