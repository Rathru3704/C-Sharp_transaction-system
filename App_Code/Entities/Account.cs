using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5Solution.Entities
{
    public class Account
    {
        public Customer Owner { get; }
        public double Balance { get; protected set; } 
        // protected: Access is limited to the containing class or types derived from the containing class; it can be inherited.

        public List<Transaction> TransactionHistory { get; }

        public Account(Customer customer)
        {
            Owner = customer;
            Balance = 0.0;
            TransactionHistory = new List<Transaction>();
        }

        public virtual TransactionResult Deposit(Transaction tran)
        // virtual: used to modify a method, property, indexer or event declaration; allow it to be overridden in a derived class.
        {
            Balance += tran.Amount;
            TransactionHistory.Add(tran);
            return TransactionResult.SUCCESS;
        }
        public virtual TransactionResult Withdraw(Transaction tran)
        {
            if(Balance < tran.Amount)
            {
                return TransactionResult.INSUFFICIENT_FUND;
            }
            Balance -= tran.Amount;
            TransactionHistory.Add(tran);
            return TransactionResult.SUCCESS;
        }
    }
}
