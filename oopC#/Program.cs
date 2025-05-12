using System.Security.Principal;
using System.Text;
using oopC_;

internal class Program
{
    private static void Main(string[] args)
    {
        DateTime dob1 = new DateTime(2000, 12, 3);
        var c1 = new Customer("pippo", "de pippis", dob1, "via vannucci 3, 16123 Genova, Italy", "pippopippo@topoliniaonline.it");

        c1.Mdp = PaymentMethod.Iban;



        var c3 = new Customer("orazio", "de pippis", new DateTime(1999, 1, 1), "via vannucci 4, 16123 Genova, Italy", "orazio@topoliniaonline.it");

        var c2 = new Customer("clarabella", "de pippis", 2001, 3, 23, "via vannucci 4, 16123 Genova, Italy", "claramoltobella@topoliniaonline.it");

        var v1 = new VipCustomer("topolino", "mouse", 1990, 1, 30, "via gramsci 4, 16123 Genova, Italy", "granbeltopo@topoliniaonline.it", -10000);

        var e1 = new Employee("paperino", "de paperis", 1980, 3, 23, "genova 1");

        e1.Level = ExperienceLevels.Senior;


        List<VipCustomer> vipCustomers = [];

        vipCustomers.Add(v1);

        //vipCustomers.Add(c1);

        List<Customer> customers = new List<Customer>();

        customers.Add(c1);
        customers.Add(c3);
        customers.Add(v1);


        foreach (var customer in customers)
        {
            Console.WriteLine(customer.PrintAddress());
        }


        List<Person> persons = new List<Person>();

        persons.Add(c1);
        persons.Add(c3);
        persons.Add(v1);
        persons.Add(e1);

        // Crea un conto VIP
        BankAccount vipAccount = new BankAccount
        (
            id: "VIP001",
            owner: v1,
            creator: e1,
            creationdate: DateTime.Now,
            balance: 0
        );

        // Deposito
        vipAccount.Operate(500);
        Console.WriteLine($"Saldo dopo deposito: {vipAccount.Balance}");

        // Prelievo grande ma dentro soglia
        vipAccount.Operate(-2000);
        Console.WriteLine($"Saldo dopo prelievo -2000: {vipAccount.Balance}");

        // Prelievo troppo grande (oltre soglia)
        vipAccount.Operate(-20000);
        Console.WriteLine($"Saldo dopo prelievo -20000: {vipAccount.Balance}");


        // Crea un cliente e un impiegato fittizi
        var saver = new Customer("Saver", "Risparmioso", 1995, 6, 1, "Via dei Conti, 1", "saver@email.it");
        var banker = new Employee("Banca", "Impiegato", 1980, 1, 1, "Filiale Centrale");

        // Crea un conto SaveAccount con saldo iniziale 0
        var saveAcc = new SaveAccount("SAV001", saver, banker, DateTime.Now, 0);

        // Deposita 200 → dovrebbe risultare 204
        saveAcc.Operate(200);
        Console.WriteLine($"Saldo dopo deposito SaveAccount: {saveAcc.Balance}");  // Atteso: 204

        // Preleva 100 → dovrebbe togliere 103 → saldo: 101
        saveAcc.Operate(-100);
        Console.WriteLine($"Saldo dopo prelievo SaveAccount: {saveAcc.Balance}");  // Atteso: 101

        var cashbacker = new Customer("cashy", "backy", 1988, 4, 2, "via delle vie", "email@cashy.ui");
        var cashAcc = new CashbackAccount("CASHB001", cashbacker, banker, DateTime.Now, 0);

        cashAcc.Operate(200);
        Console.WriteLine($"Saldo dopo deposito CASHBACK: {cashAcc.Balance}");  // Atteso: 200

        cashAcc.Operate(-100);
        Console.WriteLine($"Saldo dopo prelievo CASHBACK: {cashAcc.Balance}"); // 200 - 95 ? = 105?

        Console.WriteLine("\n============== STAMPA CONTO RISPARMIO ==============");
        Console.WriteLine(saveAcc);

        Console.WriteLine("\n============== STAMPA CONTO CASHBACK ===============");
        Console.WriteLine(cashAcc);


        Console.OutputEncoding = Encoding.Unicode; //così si vedono gli special chars via ToString() su console

        BankAccount account = new BankAccount
        (
            id: "ACC001",
            owner: c3,
            creator: e1,
            creationdate: DateTime.Now,
            balance: 0
        );

        account.Operate(200m);   // Deposit
        account.Operate(50m);   // Withdrawal
        account.Operate(500m);   // Deposit
        account.Operate(-100m);  // Withdrawal
        account.Operate(20m);    // Deposit

        account.ToString();

    }
}