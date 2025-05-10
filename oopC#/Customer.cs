using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace oopC_
{
    internal class Customer: Person //customer (nome classe figlio) : (eredita da) person (nome classe genitore)
    {

        public string Address { get; set; }

        public string? PhoneNumber { get; set; }

        public string MailAddress { get; set; }

        public PaymentMethod? Mdp { get; set; }


        //public Customer()
        //{
        //}
        public Customer(string name, string surname, DateTime dob, string address, string mailAddress): base(name, surname, dob.Year, dob.Month, dob.Day)
        {
            Address = address;
            MailAddress = mailAddress;
        }

        public Customer(string name, string surname, int year, int month, int day, string address, string mailAddress): base(name, surname, year, month, day)
        {
            Address = address;
            MailAddress = mailAddress;
        }

        public override string ToString()
        {
            return "Cliente" + " " + base.ToString(); ;
        }

        public override string Wellcome()
        {
            return "Benvenuto";
        }

        public virtual string PrintAddress()
        {
            return Name + " " + Surname + "\n" + Address.Replace(", ", "\n");
        }
    }

    public enum PaymentMethod
    {
        Iban = 1000,
        Cdc = 1001,
        Cash = 1002
    }
}
