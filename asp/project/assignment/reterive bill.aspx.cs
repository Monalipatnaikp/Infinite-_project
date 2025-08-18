using System;

namespace ElectricityBillingProject
{
    public partial class RetrieveBills : System.Web.UI.Page
    {
        private ElectricityBoard ebBoard = new ElectricityBoard();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedIn"] == null) Response.Redirect("Login.aspx");
        }

        protected void btnRetrieve_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtN.Text, out int n) && n > 0)
            {
                var bills = ebBoard.Generate_N_BillDetails(n);
                gvBills.DataSource = bills;
                gvBills.DataBind();
            }
        }
    }
}