using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace oopC_
{
    internal class Transaction
    {
        public decimal Amount { get; set; }
        public DateTime CreationDate { get; set; }
        public Transaction(decimal amount, DateTime creationdate) 
        {
            Amount = amount;
            CreationDate = creationdate;
        }
    }
}
