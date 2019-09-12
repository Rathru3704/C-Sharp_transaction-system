using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5Solution.Entities
{
    public class Transaction
    {
        public double Amount { get; set; }
        public TransactionType Type { get; }
        public DateTime TransactionDate { get; }

        public Transaction(double amountProperty, TransactionType typePorperty)
        {
            Amount = amountProperty;
            Type = typePorperty;
            TransactionDate = DateTime.Now;
        }
    }
}
