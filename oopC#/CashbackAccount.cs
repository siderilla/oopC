using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oopC_
{
    internal class CashbackAccount: BankAccount
    {
        public CashbackAccount(string id, Customer owner, Employee creator, DateTime creationdate, decimal balance)
        : base(id, owner, creator, creationdate, balance)
        {

        }

        public override void Operate(decimal amount)
        {
            decimal newCashbackAmount = amount;
            
            if (amount < 0)
            {
                newCashbackAmount = amount * (decimal)0.95;
            }

            base.Operate(newCashbackAmount);
        }

        public override string ToString()
        {
            return base.ToString() + "\nTipo: Conto Cashback";
        }


    }
}
