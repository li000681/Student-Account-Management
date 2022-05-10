using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class SavingAccount : Account
{
    public static double WithdrawPenaltyAmount { get; set; }
    public static double WithdrawPenaltyWaiverBalance { get; set; }

    //Add your code here to complete the definition of the class as required
    public SavingAccount(string name)
            : base(name)
    { }

    public override double GetWithdrawPenaltyAmount()
    {
        if (Balance < WithdrawPenaltyWaiverBalance)
            return WithdrawPenaltyAmount;
        else
            return base.GetWithdrawPenaltyAmount();

    }

}

