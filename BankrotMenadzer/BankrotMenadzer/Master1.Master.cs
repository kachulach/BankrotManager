using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BankrotManager
{
    public partial class Master1 : System.Web.UI.MasterPage
    {
        private int current_user = -1;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!HelperTools.isInitialized)
            {
                HelperTools.Initialize();
            }

            string path = HttpContext.Current.Request.Url.LocalPath;
            string[] parts = path.Split('/');
            path = parts[parts.Length - 1];

            switch (path)
            {
                case "Default.aspx":
                    liHome.Attributes.Add("class", "active");
                    break;
                case "Korisnik.aspx":
                    liKorisnik.Attributes.Add("class", "active");
                    break;
                case "History.aspx":
                    liHistory.Attributes.Add("class", "active");
                    break;
                case "Wishlist.aspx":
                    liWishlist.Attributes.Add("class", "active");
                    break;
                default:
                    liHome.Attributes.Add("class", "active");
                    break;
            }
            lblUser.Text = "Корисник";

            if (Session["user_id"] != null)
            {
                lblUser.Text = Session["full_name"].ToString();
                current_user = int.Parse(Session["user_id"].ToString());
                Database db = new Database();
                lbl_funds.Text = string.Format("Funds: {0}", db.currentFunds(current_user));
                lbl_saved_funds.Text = string.Format("Saved funds: {0}", db.getSavedFunds(current_user));
            }

        }

    }
}