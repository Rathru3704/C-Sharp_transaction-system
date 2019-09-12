using Lab5Solution.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    // ??? Helper
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

        // ???
        List<Customer> customers = Session["customers"] as List<Customer>;
        if (customers == null)
        {
            Page.Response.Redirect("CustomerManagement.aspx");
        }

        if (drpCustomer.SelectedIndex > 0)
        {
            int index = drpCustomer.SelectedIndex -1;
            Customer customer = customers[index];

            lblCheckingAccountBalance.Text = customer.Checking.Balance.ToString("C2");
            lblSavingAccountBalance.Text = customer.Saving.Balance.ToString("C2");
        }
    }

    protected void btnDeposit_Click(object sender, EventArgs e)
    {
        List<Customer> customers = Session["customers"] as List<Customer>;
        if (customers == null)
        {
            Page.Response.Redirect("CustomerManagement.aspx");
        }

        // ???
        if (Page.IsValid)
        {
            if (customers == null)
            {
                Page.Response.Redirect("CustomerManagement.aspx");
            }

            //int index = drpCustomer.SelectedIndex;
            //Customer customer = customers[index];

            int index = drpCustomer.SelectedIndex -1;
            Customer customer = customers[index];

            Account account = null;
            if (rdbAccountType.SelectedValue == "checking")
            {
                account = customer.Checking;
            }
            else
            {
                account = customer.Saving;
            }

            Transaction transaction = new Transaction(double.Parse(txtAmount.Text), TransactionType.DEPOSIT);
            account.Deposit(transaction);

            lblCheckingAccountBalance.Text = customer.Checking.Balance.ToString("C2");
            lblSavingAccountBalance.Text = customer.Saving.Balance.ToString("C2");
            lblConfirmation.Text = "The transaction completed and the account balance has been updated.";
            txtAmount.Text = String.Empty;
        }
        
    }
}