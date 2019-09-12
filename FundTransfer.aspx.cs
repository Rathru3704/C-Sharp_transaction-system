using Lab5Solution.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        List<Customer> customers = Session["customers"] as List<Customer>;
        if (customers == null)
        {
            customers = new List<Customer>();
            Session["customers"] = customers;
        }

        if (!IsPostBack)
        {
            foreach (Customer customer in customers)
            {
                ListItem item = new ListItem(customer.Name);
                drpCustomer.Items.Add(item);
            }
        }
    }

    protected void drpCustomer_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtAmount.Text = "";
        lblCheckingAccountBalance.Text = "";
        lblSavingAccountBalance.Text = "";
        lblConfirmation.Text = "";

        List<Customer> customers = Session["customers"] as List<Customer>;
        if (customers == null)
        {
            Page.Response.Redirect("CustomerManagement.aspx");
        }

        if (drpCustomer.SelectedIndex > 0)
        {
            int index = drpCustomer.SelectedIndex - 1;
            Customer customer = customers[index];

            lblCheckingAccountBalance.Text = customer.Checking.Balance.ToString("C2");
            lblSavingAccountBalance.Text = customer.Saving.Balance.ToString("C2");
        }
    }

    protected void btnTransfer_Click(object sender, EventArgs e)
    {
        List<Customer> customers = Session["customers"] as List<Customer>;
        if (customers == null)
        {
            Page.Response.Redirect("CustomerManagement.aspx");
        }

        if (Page.IsValid)
        {
            if (customers == null)
            {
                Page.Response.Redirect("CustomerManagement.aspx");
            }

            int index = drpCustomer.SelectedIndex - 1;
            Customer customer = customers[index];

            Account account1 = null;
            Account account2 = null;
            if (rdbAccountType.SelectedValue == "checking")
            {
                account1 = customer.Checking;
                account2 = customer.Saving;
            }
            else
            {
                account1 = customer.Saving;
                account2 = customer.Checking;
            }

            Transaction withdrawTran = new Transaction(double.Parse(txtAmount.Text), TransactionType.TRANSFER_OUT);
            TransactionResult result = account1.Withdraw(withdrawTran);
            if (result == TransactionResult.SUCCESS)
            {
                Transaction depositTran = new Transaction(double.Parse(txtAmount.Text), TransactionType.TRANSFER_IN);
                account2.Deposit(depositTran);
                lblCheckingAccountBalance.Text = customer.Checking.Balance.ToString("C2");
                lblSavingAccountBalance.Text = customer.Saving.Balance.ToString("C2");
                lblConfirmation.Text = "The transaction completed and the account balance has been updated.";
                txtAmount.Text = String.Empty;
            }
            else
            {
                lblConfirmation.Text = "The transaction failed: " + result.ToString();
                txtAmount.Text = String.Empty;
            }
        }
    }
}