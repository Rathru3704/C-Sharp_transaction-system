using Lab5Solution.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CustomerManagement : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {   // ??? Why I can't use entities!
        // ??? *** Important Skill ***
        List<Customer> customers = Session["customers"] as List<Customer>;
        if (customers == null)
        {
            customers = new List<Customer>();
            Session["customers"] = customers;
        }
        ShowCustomersInfo(customers);
    }

    protected void btnAddCustomer_Click(object sender, EventArgs e)
    {
        
        List<Customer> customers = Session["customers"] as List<Customer>;
        if (customers == null)
        {
            customers = new List<Customer>();
            Session["customers"] = customers;
        }

        Customer customer = new Customer(txtCustomerName.Text);
        double initialDeposit = double.Parse(txtInitialDeposit.Text);
        customer.Checking = new CheckingAccount(customer);
        customer.Saving = new SavingAccount(customer, initialDeposit);
        customers.Add(customer);
        ShowCustomersInfo(customers);
    }

    private void ShowCustomersInfo(List<Customer> customers)
    {
        for (int i = tblCourses.Rows.Count -1; i > 0; i--)
        {
            tblCourses.Rows.RemoveAt(i);
            // use Remove() method to remove an element.
            // use RemoveAt() method to remove an element by setting the position (Index).
        }

        if (customers.Count == 0)
        {
            TableRow firstRow = new TableRow();
            TableCell firstRowCell = new TableCell();
            firstRowCell.Text = "No customer in the system yet";
            firstRowCell.ForeColor = System.Drawing.Color.Red;
            firstRowCell.ColumnSpan = 4;
            firstRowCell.HorizontalAlign = HorizontalAlign.Center;
            firstRow.Cells.Add(firstRowCell);
            tblCourses.Rows.Add(firstRow);
        }
        else
        {
            foreach (Customer customer in customers)
            {
                TableRow row = new TableRow();

                TableCell cell = new TableCell();
                cell.Text = customer.Name;
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = customer.Checking.Balance.ToString("C2");
                // "C" or "c" is for Currency; "2" is for Number of decimal digits.
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = customer.Saving.Balance.ToString("C2");
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = customer.Status.ToString();
                row.Cells.Add(cell);

                tblCourses.Rows.Add(row);
            }
        }
        
    }
}