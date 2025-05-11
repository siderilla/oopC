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

        public virtual void Operate(decimal amount)
        {
            Console.WriteLine($"[DEBUG] amount: {amount}");
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
                else
                {
                    // se il saldo resta positivo, aggiorna normalmente
                    Transaction newTransaction = new Transaction(amount, CreationDate);
                    TransactionList?.Add(newTransaction);
                    Balance = newBalance;
                }
            }
 
        }

        public override string ToString()
        {
            string info = $"Conto ID: {Id}\n" +
                          $"Proprietario: {Owner}\n" +
                          $"Creato da: {Creator}\n" +
                          $"Data di creazione: {CreationDate.ToShortDateString()}\n" +
                          $"Saldo attuale: {Balance}€\n" +
                          $"Transazioni:\n";

            if (TransactionList != null && TransactionList.Count > 0)
            {
                foreach (var transaction in TransactionList)
                {
                    info += $"- {transaction.CreationDate.ToShortDateString()} | {transaction.Amount}€\n";
                }
            }
            else
            {
                info += "Nessuna transazione registrata.\n";
            }

            return info;
        }

    }
}
