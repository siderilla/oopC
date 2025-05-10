using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oopC_
{
    internal class BankAccount
    {

        public required string Id { get; set; } 
        public required Customer Owner { get; set; }
        public required Employee Creator { get; set; }
        public required DateTime CreationDate { get; set; }
        public decimal Balance { get; set; }
        public List<Transaction>? TransactionList { get; set; }

        public BankAccount(string id, Customer owner, Employee creator, DateTime creationdate, decimal balance) 
        {
            Id = id;
            Owner = owner;
            Creator = creator;
            CreationDate = creationdate;
            Balance = balance;
            TransactionList = new List<Transaction>();
        }

        public void Operate(decimal amount)
        {
            if (amount > 0)
            {
                Balance = Balance + amount;
            }
            if (amount < 0)
            {
                Balance = Balance + amount;
            }
        }

        public bool IsVipCustomer()
        {
            if (Owner is VipCustomer)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
