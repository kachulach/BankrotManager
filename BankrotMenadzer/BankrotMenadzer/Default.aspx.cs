using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
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

        protected void btnAddIncome_Click(object sender, EventArgs e)
        {
            dodadiPrihod();
        }

        private void dodadiPrihod()
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
        }

        protected void btnAddExpenditure_Click(object sender, EventArgs e)
        {
            dodadiRashod();
        }

        private void dodadiRashod()
        {
            //Slicno na funkcijata za Prihod
        }

        protected void btnAddWishlist_Click(object sender, EventArgs e)
        {
            dodadiZelba();
        }

        private void dodadiZelba()
        {
            //Slicno na funkcijata za Prihod, moze da se naprave samo edna funkcija za site tri slicaja
        }

    }
}
