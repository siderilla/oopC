using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace oopC_
{
    internal class Transaction: IComparable<Transaction>
    {
        public decimal Amount { get; set; }
        public DateTime CreationDate { get; set; }
        public Transaction(decimal amount, DateTime creationdate) 
        {
            Amount = amount;
            CreationDate = creationdate;
        }

        public int CompareTo(Transaction? other)
        {
            if (other == null) return -1; // null is less than any object
            return -Amount.CompareTo(other.Amount); // Sort by amount descending
        }
    }
}
