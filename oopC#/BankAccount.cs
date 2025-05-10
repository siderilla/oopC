using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oopC_
{
    internal class BankAccount
    {

        public string Id { get; set; } 
        public Customer Owner { get; set; }
        public Employee Creator { get; set; }
        public DateTime CreationDate { get; set; }
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
            decimal newBalance;
            
            if (amount > 0)
            {
                newBalance = Balance + amount;
                Transaction newTransaction = new Transaction(amount, CreationDate);
                TransactionList?.Add(newTransaction);
                Balance = newBalance;
            }
            if (amount < 0)
            {
                newBalance = Balance + amount;
                if (newBalance < 0)
                {
                    if (Owner is VipCustomer customer)
                    {
                        if (customer.LimitNegativeBalance(newBalance))
                        {
                        Transaction newTransaction = new Transaction(amount, CreationDate);
                        TransactionList?.Add(newTransaction);
                        Balance = newBalance;
                        }
                        else
                        {
                            Console.WriteLine("Insufficient balance ˙◠˙");
                            return;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Insufficient balance ˙◠˙");
                        return;
                    }
                }
            }
 
        }
    }
}
