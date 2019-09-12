using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5Solution.Entities
{
    public class CheckingAccount : Account
    {
        public const double MaxWithdrawAmount = 300.0;
        // Constant fields and locals aren't variables and may not be modified.
        // Constants can be numbers, Boolean values, strings, or a null reference. 
        // Don’t create a constant to represent information that you expect to change at any time.

        public CheckingAccount(Customer customer) : base(customer) { }

        public override TransactionResult Withdraw(Transaction tran)
        {
            if(tran.Type == TransactionType.WITHDRAW && Owner.Status != CustomerStatus.PREMIER)
            {
                if (tran.Amount > MaxWithdrawAmount)
                {
                    return TransactionResult.EXCEED_MAX_WITHDRAW_AMOUNT;
                }
            }
            return base.Withdraw(tran);
        }
    }
}
