using Lab5Solution.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    private object getErrorMessage;

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

        pnlResult.Visible = false;
    }

    protected void drpCustomer_SelectedIndexChanged(object sender, EventArgs e)
    {
        List<Customer> customers = Session["customers"] as List<Customer>;
        if (customers == null)
        {
            Page.Response.Redirect("CustomerManagement.aspx");
        }

        if (drpCustomer.SelectedIndex > 0)
        {
            int index = drpCustomer.SelectedIndex - 1;
            Customer customer = customers[index];

            foreach (Transaction tran in customer.Checking.TransactionHistory)
            {
                TableRow row = new TableRow();
                TableCell cell = new TableCell();
                cell.Text = tran.TransactionDate.ToString();
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = tran.Amount.ToString();
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = tran.Type.ToString();
                row.Cells.Add(cell);

                tblCheckingResult.Rows.Add(row);
            }

            foreach (Transaction tran in customer.Saving.TransactionHistory)
            {
                TableRow row = new TableRow();
                TableCell cell = new TableCell();
                cell.Text = tran.TransactionDate.ToString();
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = tran.Amount.ToString();
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = tran.Type.ToString();
                row.Cells.Add(cell);

                tblSavingResult.Rows.Add(row);
            }

            pnlResult.Visible = true;
        }
    }
}