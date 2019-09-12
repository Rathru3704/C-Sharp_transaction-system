using Lab5Solution.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    //private object getErrorMessage;

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

            //if (customer.Checking.Balance != 0)
            //{
            //    RangeValidator1.MaximumValue = customer.Checking.Balance.ToString();
            //}
        }
    }

    protected void btnWithdraw_Click(object sender, EventArgs e)
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

            Account account = null;
            if (rdbAccountType.SelectedValue == "checking")
            {
                account = customer.Checking;
                //RangeValidator1.MaximumValue = customer.Checking.Balance.ToString();
            }
            else
            {
                account = customer.Saving;
                //RangeValidator1.MaximumValue = customer.Saving.Balance.ToString();
            }

            Transaction transaction = new Transaction(double.Parse(txtAmount.Text), TransactionType.WITHDRAW);
            TransactionResult result = account.Withdraw(transaction);
            
            if (result == TransactionResult.SUCCESS)
            {
                lblCheckingAccountBalance.Text = customer.Checking.Balance.ToString("C2");
                lblSavingAccountBalance.Text = customer.Saving.Balance.ToString("C2");
                lblConfirmation.Text = "The transaction completed and the account balance has been updated.";
                //txtAmount.Text = String.Empty;
            }
            else if (result == TransactionResult.INSUFFICIENT_FUND)
            {
                //RangeValidator1.IsValid = false;
                //txtAmount.Text = String.Empty;
                lblConfirmation.Text = String.Empty;
                CompareValidator2.IsValid = false;
            }
            else
            {
                lblConfirmation.Text = "The transaction failed: " + result.ToString();
                //txtAmount.Text = String.Empty;
            }
        }
    }
}