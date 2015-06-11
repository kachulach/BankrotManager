using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BankrotManager
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
            User u = Database.authenticateUser(tbUsername.Text, tbPassword.Text);
            if (u != null)
            {
                Session["user_id"] = u.getUserId();
                Session["full_name"] = u.getName();
                Session["userInfo"] = u;
                Response.Redirect("Default.aspx");

            }
            else
            {
                lblError.Text = "Неуспешна најава. Обидете се повторно.";
            }
        }

        protected void LoginView1_ViewChanged(object sender, EventArgs e)
        {

        }

        protected void btn_Click(object sender, EventArgs e)
        {
            string name = tbNameReg.Text;
            string username = tbUserNameReg.Text;
            string password = tbPasswordReg.Text;
            string email = tbEmailReg.Text;
            Database db = new Database();
            string result = db.addUser(username, password, name, email);
            if ("OK" == db.addUser(username, password, name, email))
            Response.Redirect("Login.aspx");
            else
            {
                lblError.Text = "Неуспешна регистрација. Обидете се повторно.";
            }
        }
    }
}