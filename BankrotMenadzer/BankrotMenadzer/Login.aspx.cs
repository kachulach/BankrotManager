using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BankrotMenadzer
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user_id"] != null)
            {
                Response.Redirect("Default.aspx");
            }
        }

        protected void btnNajaviSe_Click(object sender, EventArgs e)
        {
            /*User u = DatabaseManagement.authenticateUser(tbUsername.Text, tbPassword.Text);
            if (u != null)
            {
                Session["user_id"] = u.user_id;
                Session["full_name"] = u.getFullName();
                Session["organization_id"] = u.getOrganizationId();
                Response.Redirect("Default.aspx");

            }
            else
            {
                lblError.Text = "Неуспешна најава. Обидете се повторно.";
            }*/
        }

        protected void LoginView1_ViewChanged(object sender, EventArgs e)
        {

        }
    }
}