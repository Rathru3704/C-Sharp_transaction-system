using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5Solution.Entities
{
    public class SavingAccount : Account
    {
        public static double PrimierAmount { get; set; } = 2000.0;
        public static double WithdrawPenaltyAmount { get; set; } = 10.0;

        public SavingAccount(Customer customer, double initialDeposit) : base(customer)
        {
            Transaction tran = new Transaction(initialDeposit, TransactionType.DEPOSIT);
            Deposit(tran);
        }

        public override TransactionResult Deposit(Transaction tran)
        {
            TransactionResult result = base.Deposit(tran);
            if(Balance >= PrimierAmount)
            {
                Owner.Status = CustomerStatus.PREMIER;
            }
            return result;
        }
        public override TransactionResult Withdraw(Transaction tran)
        {
            TransactionResult result = base.Withdraw(tran);
            if (result == TransactionResult.SUCCESS)
            {
                if(Balance < PrimierAmount)
                {
                    Owner.Status = CustomerStatus.REGULAR;

                    double amt = Balance < WithdrawPenaltyAmount ? Balance : WithdrawPenaltyAmount;
                    // ?: Operator - condition ? consequence : alternative
                    // e.g. if(a) func1();
                    //      else func2();   ->   a?func1():func2();

                    Transaction penaltyTrans = new Transaction(amt, TransactionType.PENALTY);
                    base.Withdraw(penaltyTrans);
                }
            }
            return result;
        }
    }
}
