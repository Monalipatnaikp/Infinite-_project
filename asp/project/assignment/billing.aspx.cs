using System;
using System.Web.UI;

namespace ElectricityBillingProject
{
    public partial class Billing : System.Web.UI.Page
    {
        private int numBills;
        private int currentBill = 0;
        private ElectricityBoard ebBoard = new ElectricityBoard();
        private BillValidator validator = new BillValidator();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedIn"] == null) Response.Redirect("Login.aspx");
            if (IsPostBack)
            {
                if (ViewState["numBills"] != null)
                    numBills = (int)ViewState["numBills"];
                if (ViewState["currentBill"] != null)
                    currentBill = (int)ViewState["currentBill"];
            }
        }

        protected void btnStartAdding_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtNumBills.Text, out numBills) && numBills > 0)
            {
                pnlAddBills.Visible = true;
                lblOutput.Text = "";
                currentBill = 0;
                ViewState["numBills"] = numBills;
                ViewState["currentBill"] = currentBill;
            }
            else
            {
                lblError.Text = "Invalid number of bills";
            }
        }

        protected void btnAddBill_Click(object sender, EventArgs e)
        {
            lblError.Text = "";
            try
            {
                int units;
                if (!int.TryParse(txtUnits.Text, out units))
                {
                    lblError.Text = "Invalid units";
                    return;
                }

                string validationMsg = validator.ValidateUnitsConsumed(units);
                if (validationMsg != null)
                {
                    lblError.Text = validationMsg;
                    return;
                }

                ElectricityBill bill = new ElectricityBill();
                bill.ConsumerNumber = txtConsumerNumber.Text;
                bill.ConsumerName = txtConsumerName.Text;
                bill.UnitsConsumed = units;

                ebBoard.CalculateBill(bill);
                ebBoard.AddBill(bill);

                lblOutput.Text += $"{bill.ConsumerNumber} {bill.ConsumerName} {bill.UnitsConsumed} Bill Amount: {bill.BillAmount}<br />";

                currentBill++;
                ViewState["currentBill"] = currentBill;

                if (currentBill >= numBills)
                {
                    pnlAddBills.Visible = false;
                }
                else
                {
                    ClearInputs();
                }
            }
            catch (FormatException ex)
            {
                lblError.Text = ex.Message;
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        private void ClearInputs()
        {
            txtConsumerNumber.Text = "";
            txtConsumerName.Text = "";
            txtUnits.Text = "";
        }
    }
}