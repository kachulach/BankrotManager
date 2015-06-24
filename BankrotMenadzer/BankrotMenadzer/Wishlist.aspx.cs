using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BankrotManager
{
    public partial class Wishlist : System.Web.UI.Page
    {
        private Database db = new Database();
        private int current_funds = 0;
        private int user_id = -1;
        private int current_id = 0;
        private int saved_funds;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user_id"] == null)
            {
                Response.Redirect("Login.aspx");
                return;
            }
            user_id = int.Parse(Session["user_id"].ToString());

            current_funds = db.currentFunds(user_id);
            saved_funds = db.getSavedFunds(user_id);

            ShowData();
        }

        private void ShowData()
        {
            var wishlist = db.getWishlist(int.Parse(Session["user_id"].ToString()));

            var total = current_funds + saved_funds;
            wishlist.Sort((item1, item2) => (total - item2.Amount).CompareTo(total - item1.Amount));

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

        [WebMethod]
        public static string AJAX_BuyWishlist(string id)
        {
            int _id = int.Parse(id);
            Database db = new Database();
            return db.buyItemFromWishlist(_id);
        }

        [WebMethod]
        public static string AJAX_RemoveWishlist(string id)
        {
            int _id = int.Parse(id);
            Database db = new Database();
            return db.removeTransaction(_id).ToString();
        }

        public string GetClass(string value)
        {
            int _val = int.Parse(value);
            if (_val <= saved_funds)
            {
                return "success";
            }
            else if (_val <= saved_funds + current_funds)
            {
                return "warning";
            }
            else
            {
                return "error";
            }
        }
    }
}