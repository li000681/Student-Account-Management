using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Withdraw : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Add your code here to complete the implementation as required
        List<Account> list = (List<Account>)Session["Account"];
        if (!IsPostBack)
        {
            
            if (list == null)
                Response.Redirect("AccountManage.aspx");
            else
            {
                foreach (Account account in list)
                {
                    drpAccount.Items.Add(account.ToString());
                }
            }
        }
        if (txtWithdrawAmount.Text != "" && drpAccount.SelectedIndex != 0)
        {
            if (list[drpAccount.SelectedIndex - 1].GetWithdrawPenaltyAmount() != 0)
                lblInfo.Text = "$" + list[drpAccount.SelectedIndex - 1].GetWithdrawPenaltyAmount() + " withdraw penalty will apply!";
            else
                lblInfo.Text = "";
        }

            

    }
    protected void drpAccount_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Add your code here to complete the implementation as required
        List<Account> list = (List<Account>)Session["Account"];
        if (drpAccount.SelectedIndex != 0)
        {
            txtCurrentBalance.Text = list[drpAccount.SelectedIndex-1].Balance.ToString();
        }

    }

    protected void btnWithdraw_Click(object sender, EventArgs e)
    {

        //Add your code here to complete the implementation as required
        List<Account> list = (List<Account>)Session["Account"];
        if (IsValid)

        {
            try
            {
                double totalDeduction = Double.Parse(txtWithdrawAmount.Text) + list[drpAccount.SelectedIndex - 1].GetWithdrawPenaltyAmount();
                list[drpAccount.SelectedIndex - 1].Withdraw(totalDeduction);
                lblInfo.Text = "The transaction completed, $" + totalDeduction + " has been deducted from the balance";
                txtWithdrawAmount.Text = "";
                txtCurrentBalance.Text = list[drpAccount.SelectedIndex - 1].Balance.ToString();
                Session["Account"] = list;

            }
            catch(Exception ex)
            {
                lblInfo.Text = "The transaction failed:" + ex.Message;
            }
            
        }

    }

}