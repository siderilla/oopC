using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oopC_
{
    internal class SaveAccount: BankAccount
    {

        public SaveAccount(string id, Customer owner, Employee creator, DateTime creationdate, decimal balance)
            : base(id, owner, creator, creationdate, balance)
        {

        }

        public override void Operate(decimal amount)
        {
            decimal newAmount = amount;

            if (amount < 0)
            {
                newAmount = amount * (decimal)1.03;
            } 
            else if (amount > 0)
            {
                newAmount = amount * 1.02m; //m dopo il numero double, lo casta automaticamente in decimal
            }

            base.Operate(newAmount); //passa al metodo operate originale di bankaccount il parametro nuovo da sovrascrivere
        }

        public override string ToString()
        {
            return base.ToString() + "\nTipo: Conto Risparmio";
        }


    }
}
