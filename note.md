CHIAVI EREDITARIETA in C#

virtual	 ->	Nella classe madre	->	"Puoi sovrascrivermi"
override ->	Nella classe figlia	->	"Sto cambiando un metodo virtual del padre"
abstract ->	Nella classe madre	->	"Devi implementarlo nel figlio (obbligatorio)"


╔══════════════════════════════════════════════════════════╗
║ 🧠 Appunti C# – Ereditarietà, override e concetti base   ║
╚══════════════════════════════════════════════════════════╝

╔═══🔷 Classi e ereditarietà ═════════════════════════════╗
║ - Classe madre (base class): es. BankAccount           ║
║ - Classe figlia (derived class): eredita tutto         ║
║   └─ Esempio: class SaveAccount : BankAccount          ║
╚═════════════════════════════════════════════════════════╝

  ▸ : base(...) → nel costruttore della figlia per chiamare quello della madre
  ▸ base. → per accedere ai metodi della madre da dentro la figlia

╔═══🟢 Override e metodi virtuali ════════════════════════╗
║ virtual   → nella madre, abilita override nei figli    ║
║ override  → nella figlia, modifica un metodo virtuale  ║
╚═════════════════════════════════════════════════════════╝

  Esempio:
    public virtual void Operate(decimal amount)   // madre
    public override void Operate(decimal amount)  // figlia

╔═══🧩 Altri concetti chiave ═════════════════════════════╗
║ is → verifica il tipo di un oggetto                   ║
║   es: if (Owner is VipCustomer)                       ║
║                                                       ║
║ as → prova a fare cast in modo sicuro                 ║
║   es: VipCustomer vip = Owner as VipCustomer          ║
╚════════════════════════════════════════════════════════╝

╔═══🧮 Calcoli e casting ═════════════════════════════════╗
║ - C# non permette decimal * double                    ║
║   Soluzioni:                                          ║
║     amount * (decimal)1.03                            ║
║     amount * 1.03m   ← usa la 'm' per decimal         ║
║                                                       ║
║ Percentuali:                                          ║
║   +2%  → amount * 1.02m                               ║
║   -3%  → amount * 1.03m                               ║
║   +5% cashback → amount * 0.95m                       ║
╚════════════════════════════════════════════════════════╝

╔═══🗂 Liste e oggetti ═══════════════════════════════════╗
║ Dichiarazione:                                         ║
║   List<Transaction> TransactionList { get; set; }     ║
║ Aggiungere:                                            ║
║   TransactionList.Add(newTransaction);                ║
╚════════════════════════════════════════════════════════╝

╔═══🧾 ToString() per stampa leggibile ══════════════════╗
║ public override string ToString()                    ║
║ { return $"Conto di {Owner}, Saldo: {Balance}"; }    ║
╚════════════════════════════════════════════════════════╝

╔═══✅ Pattern generale del metodo Operate() ════════════╗
║ 1. amount > 0  → deposito                             ║
║ 2. amount < 0  → prelievo                             ║
║    └─ Se saldo < 0 e non sei VIP → blocco             ║
║    └─ Se sei VIP → verifica soglia                    ║
║ 3. Crea e aggiungi una nuova Transaction              ║
╚════════════════════════════════════════════════════════╝

╔═══📌 Note finali ══════════════════════════════════════╗
║ - Le classi figlie hanno stesso metodo con            ║
║   comportamento diverso (polimorfismo)                ║
║ - Un solo metodo `Operate`, tanti comportamenti       ║
╚════════════════════════════════════════════════════════╝


╔═══🛠 Debugging e strategia mentale ═════════════════════════════════╗
║ - Inserisci Console.WriteLine nei punti critici per seguire i dati ║
║ - Verifica cosa entra nei metodi e cosa viene modificato           ║
║ - Quando qualcosa non cambia, controlla se il codice entra davvero║
║   nel blocco previsto (if / else)                                  ║
║ - Aggiungi log anche nei rami "vuoti" per vedere se ci finisci     ║
║ - Blocchi troppo annidati? → valuta un refactoring                 ║
║   con return anticipati o estrazione in metodi privati             ║
║ - Dai nomi chiari alle variabili: newAmount, adjustedAmount, ecc. ║
║   per non perdere il senso del flusso                              ║
╚════════════════════════════════════════════════════════════════════╝
