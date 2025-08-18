using System;

namespace ElectricityBillingProject
{
    public partial class Login : System.Web.UI.Page
    {
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "admin" && txtPassword.Text == "admin")
            {
                Session["LoggedIn"] = true;
                Response.Redirect("Billing.aspx");
            }
            else
            {
                lblMessage.Text = "Invalid credentials";
            }
        }
    }
}
