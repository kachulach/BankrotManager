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
        protected void Page_Load(object sender, EventArgs e)
        {
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
                 default:
                     liHome.Attributes.Add("class", "active");
                     break;
             }
             lblUser.Text = "Корисник";
        /*
            if (Session["user_id"] != null)
            {
                lblUser.Text = Session["full_name"].ToString();
                int user_id = int.Parse(Session["user_id"].ToString());
                //display menu items
                if (!DatabaseManagement.canViewMenuItems(user_id))
                {
                    liVolonteri.Visible = false;
                    liClenovi.Visible = false;
                    liUlogi.Visible = false;
                }

                if (DatabaseManagement.isUserAdmin(user_id))
                {
                    liUlogi.Visible = true;
                }
                else
                {
                    liUlogi.Visible = false;
                }
            }
            else
            {
            }
*/
        }
        
    }
}