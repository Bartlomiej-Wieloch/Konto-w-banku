using Bank;

var konto = new Konto("Bartek", 5000);
Console.WriteLine($"Utworzenie konta, nazwa : {konto.Nazwa}, początkowe saldo: {konto.Bilans}\n");

Console.WriteLine(">Wpłata 300");
konto.Wplata(300);
Console.WriteLine("Saldo zwiększyło się : " + konto.Bilans + "\n");

Console.WriteLine(">Wypłata 2500");
konto.Wyplata(2500);
Console.WriteLine("Saldo zmniejsza się : " + konto.Bilans + "\n");

/*
    Nie da się wpłacić albo wypłacić ujemnej kwoty.
    Wywołanie :
    -  konto.Wplata(-1);
    -  konto.Wyplata(-1);
    Spowoduje ArgumentException
*/

Console.WriteLine(">Blokuje konto");
konto.BlokujKonto();
Console.WriteLine("Czy konto jest zablokowane ? " + konto.Blokada + "\n");

Console.WriteLine(">Odblokuje konto");
konto.OdblokujKonto();
Console.WriteLine("Czy konto jest zablokowane ? " + konto.Blokada + "\n");

/*
    Na zablokowanym podstawowym kontcie, nie da się wykonywać transakcji.
    Wywołanie :
    -  konto.Wplata(1);
    -  konto.Wyplata(1);
    Spowoduje ArgumentException
*/

Console.WriteLine("-----------------------------------------------------------------------------------------------------\n");
Console.WriteLine("Klasa KontoPlus rozszerza klasę Konto o dodatkowe metody\n");
var kontoPlus = new KontoPlus("Zofia", 500, 3000);
Console.WriteLine($"Utworzenie kontaPlus, nazwa : {kontoPlus.Nazwa}, limit debetowy {kontoPlus.Limit}, początkowe saldo: {kontoPlus.Bilans}\n");

Console.WriteLine("Na konciePlus jest możlwiość wyplaty więcej środków niż się posiada.");
Console.WriteLine("Umożliwia to właściwość limit. Wyplacana kwota nie moze przekroczyc tego limitu \n");

Console.WriteLine(">Wypłata 3400");
kontoPlus.Wyplata(3400);
Console.WriteLine("Saldo zmniejsza się : " + kontoPlus.Bilans);
Console.WriteLine($"Limit debetowy : {kontoPlus.Limit}\n");

/*
    Nie da się wypłacić więcej niż pozwala na to limit.
    Załóżmy że kwota na koncie to 200 i limit to 100
    -  kontoPlus.Wyplata(400);
    Spowoduje ArgumentException
*/

Console.WriteLine("Po takiej operacji konto staje sie zablokowane.");
Console.WriteLine("Czy konto jest zablokowane ? " + kontoPlus.Blokada + "\n");

Console.WriteLine("Mozna je odblokować gdy saldo konta będzie większe od zera \n");

//klasa KontoPlus inaczej implementuje blokadę, po zablokowaniu można wpłacać, ale nie można wypłacać

Console.WriteLine(">Wpłata 1000");
kontoPlus.Wplata(1000);
Console.WriteLine($"Saldo : {kontoPlus.Bilans}, Blokada : {kontoPlus.Blokada}");
Console.WriteLine($"Limit debetowy : {kontoPlus.Limit}\n");

Console.WriteLine("Po odblokowaniu konta powraca możliwość korzystania z limitu debetowego\n");

Console.WriteLine(">Wypłata 700");
kontoPlus.Wyplata(700);
Console.WriteLine($"Saldo : {kontoPlus.Bilans}");
Console.WriteLine($"Limit debetowy : {kontoPlus.Limit}\n");

Console.WriteLine("Limit debetowy mozna zmniejszyć lub zwiększyć\n");

Console.WriteLine(">Zmniejsz limit o 100");
kontoPlus.ZmniejszLimit(100);
Console.WriteLine($"Saldo : {kontoPlus.Bilans}");
Console.WriteLine($"Nowy limit debetowy : {kontoPlus.Limit} \n");

Console.WriteLine(">Zwiększ limit o 800");
kontoPlus.ZwiekszLimit(800);
Console.WriteLine($"Saldo : {kontoPlus.Bilans}");
Console.WriteLine($"Nowy limit debetowy : {kontoPlus.Limit} \n");

/*
    Nie da się ustawić ujemnego limitu.
    Wywołanie :
    -  kontoPlus.ZmniejszLimit(-100);
    -  kontoPlus.ZwiekszLimit(-100);
    Spowoduje ArgumentException
*/

Console.WriteLine("-----------------------------------------------------------------------------------------------------\n");

Console.WriteLine("Klasa KontoLimit bazuje na klasie Konto poprzez delegacje i implementuje wszystkie metody które są w klasie KontoPlus\n");

var kontoLimit = new KontoLimit("Kacper", 200, 1000);
Console.WriteLine($"Utworzenie kontaLimit, nazwa : {kontoLimit.Nazwa}, limit debetowy {kontoLimit.Limit}, początkowe saldo: {kontoLimit.Bilans}\n");

Console.WriteLine(">Blokuje konto");
kontoLimit.BlokujKonto();
Console.WriteLine("Czy konto jest zablokowane ? " + kontoLimit.Blokada + "\n");

Console.WriteLine(">Odblokuje konto");
kontoLimit.OdblokujKonto();
Console.WriteLine("Czy konto jest zablokowane ? " + kontoLimit.Blokada + "\n");

Console.WriteLine(">Wypłata 1100");
kontoLimit.Wyplata(1100);
Console.WriteLine("Saldo : " + kontoLimit.Bilans);
Console.WriteLine("Limit debetowy : " + kontoLimit.Limit);
Console.WriteLine("Blokada : " + kontoLimit.Blokada);

Console.WriteLine();

Console.WriteLine(">Wpłata 500");
kontoLimit.Wplata(500);
Console.WriteLine("Saldo : " + kontoLimit.Bilans);
Console.WriteLine("Limit debetowy : " + kontoLimit.Limit);
Console.WriteLine("Blokada : " + kontoLimit.Blokada);

Console.WriteLine();

Console.WriteLine(">Zwiększ limit o 600");
kontoLimit.ZwiekszLimit(600);
Console.WriteLine("Saldo : " + kontoLimit.Bilans);
Console.WriteLine("Limit debetowy : " + kontoLimit.Limit);
Console.WriteLine("Blokada : " + kontoLimit.Blokada);

Console.WriteLine();

Console.WriteLine(">Zmniejsz limit o 500");
kontoLimit.Wyplata(500);
Console.WriteLine("Saldo : " + kontoLimit.Bilans);
Console.WriteLine("Limit debetowy : " + kontoLimit.Limit);
Console.WriteLine("Blokada : " + kontoLimit.Blokada);