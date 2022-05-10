using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CustomerManage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Add your code here to complete the implementation as required
        List<Account> list;
        list= ((List<Account>)Session["Account"]==null)? new List<Account>() : (List<Account>)Session["Account"];

        if (!IsPostBack)
        {
            ShowAccounts(list);
        }

    }

    protected void btnAddAccount_Click(object sender, EventArgs e)
    {
        //Add your code here to complete the implementation as required
        if (IsValid)
        {
            List<Account> list =new List<Account>();

            if (Session["Account"] == null)
            {
                list.Add(GetAccount());


            }
            else
            {
                list = (List<Account>)Session["Account"];
                list.Add(GetAccount());
            }

            Session["Account"] = list;
            ShowAccounts(list);
            drpAccountType.SelectedIndex = 0;
            txtCustomerName.Text = "";
            txtInitialDeposit.Text = "";
        }


    }
    private  Account GetAccount()
    {
        switch (drpAccountType.SelectedIndex)
        {
            case 1:
                Account checkingAccount = new CheckingAccount(txtCustomerName.Text);
                checkingAccount.Deposit( Double.Parse(txtInitialDeposit.Text));
                return checkingAccount;
            case 2:
                Account savingAccount = new SavingAccount(txtCustomerName.Text);
                savingAccount.Deposit(Double.Parse(txtInitialDeposit.Text));
                return savingAccount;
            
        }
        return null;
    }

    #region Helpers: Use ShowAccounts(...) method to display a list of accounts.
    private void ShowAccounts(List<Account> accounts)
    {
        if (accounts.Count == 0)
        {
            TableRow row = new TableRow();
            tblCourses.Rows.Add(row);

            TableCell cell = new TableCell();
            row.Cells.Add(cell);

            cell.Text = "No account in the system yet";
            cell.ForeColor = System.Drawing.Color.Red;
            cell.ColumnSpan = 4;   
        }
        else
        {
            foreach (Account ac in accounts)
            {
                TableRow row = new TableRow();
                tblCourses.Rows.Add(row);

                TableCell cell = new TableCell();
                cell.Text = ac.AccountNumber;
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = ac.OwnerName;
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = ac.AccountType;
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = ac.Balance.ToString("C2");
                row.Cells.Add(cell);
            }
        }
    }

#endregion
}