using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BankrotManager
{
    public partial class Wishlist : System.Web.UI.Page
    {
        private Database db = new Database();
        private int current_funds = 0;
        private int current_id = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user_id"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            ShowData();
        }

        private void ShowData()
        {
            var wishlist = db.getWishlist(int.Parse(Session["user_id"].ToString()));

            //funkcijata za getWishlist da vrakja lista od transakcii
            //da se dodade repiter za podatocite kako kaj History so moznost za brisenje (repiter_rawdata vo history)
            //da se otkomentira kodot podolu za polnenje na podatocite vo tabelata

            this.repeater_wishlist.DataSource = wishlist;
            this.repeater_wishlist.DataBind();
        }

        private void getAffordableItemsWishlist()
        {
            User u = (User)Session["userInfo"];
            int user_id = u.getUserId();
            int money = (int)u.getFunds();
            var affordableWishlist = db.getAffordableItemsWishlist(user_id, money);

            //funkcijata za getAffordableItemsWishlist da vrakja lista od transakcii
            //da se dodade repiter za podatocite kako kaj History so moznost za brisenje (repiter_rawdata vo history)
            //da se otkomentira kodot podolu za polnenje na podatocite vo tabelata

            this.repeater_wishlist.DataSource = affordableWishlist;
            this.repeater_wishlist.DataBind();
        }
    }
}