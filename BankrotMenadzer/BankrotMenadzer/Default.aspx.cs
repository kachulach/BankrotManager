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
       /* protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user_id"] == null)
            {
                Response.Redirect("Login.aspx");
            }
        }*/

        [WebMethod]
        public static string AJAX_AddTransaction()
        {
            var random = new Random().Next(0, 2000);
            return "{ \"label\": \"Test1\", \"value\": " + random + "}";
        }

        private void dodadiTransakcija()
        {
            double price = Convert.ToDouble(tbPrice.Text);
            string name = tbName.Text;
            int category_id = 0;
            if (ddCategory.SelectedIndex != -1)
            {
                category_id = Convert.ToInt32(ddCategory.SelectedItem.Value);
            }
            DateTime datum = Convert.ToDateTime(tbDatum.Text);
            int comment_id = 0;
            if (tbComment.Text != "")
            {
                string comment = tbComment.Text;
                //Dodavanje na komentar u baza
                //Zemanje na indeks od baza za komentarot
                //comment_id=
            }
            int user_id = int.Parse(Session["user_id"].ToString());
            //Funkcija za dodavanje u baza so parametrite od pogore

            //Ako e wishlist, dodavanje u tabela za wishlist kreiranata transakcija
        }

        protected void btnAddExpenditure_Click(object sender, ImageClickEventArgs e)
        {
            dodadiTransakcija();
        }

        protected void btnAddIncome_Click(object sender, ImageClickEventArgs e)
        {
            dodadiTransakcija();
        }

        protected void btnAddWish_Click(object sender, ImageClickEventArgs e)
        {
            dodadiTransakcija();
            
        }
    }
}
