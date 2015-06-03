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

namespace MacedonianRedCrossYouth
{
    public partial class Default : System.Web.UI.Page
    {
       protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Database db = new Database();
                DataSet ds = db.getAllCategories();
                ddCategory.DataTextField = "name";
                ddCategory.DataValueField = "category_id";

                ddCategory.DataSource = ds;
                ddCategory.DataBind();
            }
            // if (Session["user_id"] == null)
            // {
            //    Response.Redirect("Login.aspx");
            // }
        }

        [WebMethod]
        public static string AJAX_AddTransaction()
        {
            var random = new Random().Next(0, 2000);
            return "{ \"label\": \"Test1\", \"value\": " + random + "}";
        }

        private void dodadiTransakcija(int type)
        {
            Database db = new Database();

            bool wishlist = type == 3;
            int price = Math.Abs(Convert.ToInt32(tbPrice.Text));
            if (type != 1)
            {
                price *= -1;
            }
            string name = tbName.Text;
            int category_id = 0;
            if (ddCategory.SelectedIndex != -1)
            {
                category_id = Convert.ToInt32(ddCategory.SelectedItem.Value);
            }
            DateTime datum = Convert.ToDateTime(tbDatum.Text);
            int comment_id = 0;
            // dali e ne prazen komentarot
            if (!tbComment.Text.Trim().Equals(""))
            {
                string comment = tbComment.Text;
                comment_id = (int)db.addComment(comment);
                //Dodavanje na komentar u baza
                //Zemanje na indeks od baza za komentarot
            }

            int user_id = int.Parse(Session["user_id"].ToString());
            //Funkcija za dodavanje u baza so parametrite od pogore

            //Ako e wishlist, dodavanje u tabela za wishlist kreiranata transakcija
            if (comment_id != 0)
            {
                db.addTransaction(category_id, user_id, comment_id, price, datum, name, wishlist);
            }
            else
            {
                db.addTransactionBezKomentar(category_id, user_id, price, datum, name, wishlist);
            }

        }

        protected void btnAddExpenditure_Click(object sender, ImageClickEventArgs e)
        {
            dodadiTransakcija(2);
        }

        protected void btnAddIncome_Click(object sender, ImageClickEventArgs e)
        {
            dodadiTransakcija(1);
        }

        protected void btnAddWish_Click(object sender, ImageClickEventArgs e)
        {
            dodadiTransakcija(3);
        }
    }
}
