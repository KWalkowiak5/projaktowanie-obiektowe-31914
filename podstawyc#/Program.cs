//zad1
/*
const string password = "admin123";
Console.WriteLine("Podaj hasło:");
string Input = Console.ReadLine();

while (password != Input)
{
    Console.WriteLine("Złe hasło, podaj hasło:");
    Input = Console.ReadLine();
}
Console.WriteLine("Poprawne hasło.");*/
//zad2
/*
int zero = 0;
int number;
do
{
    Console.WriteLine("Podaj liczbę większą od zera:");
     number = Convert.ToInt32(Console.ReadLine());
}
while(zero >= number);
Console.WriteLine($"{number} jest większe od zeroa.");*/
//zad3
/*
string[] cities = { "Poznań", "Warszawa", "Gdańsk", "Wrocław", "Kraków"};
foreach (string city in cities)
{
Console.WriteLine($"Miasta: {city}");
}*/
//zad4
/*
class Osoba
{
    public string Imie;
    public int Wiek;

    public void PrzedstawSie()
    {
        Console.WriteLine($"Cześć, mam na imię {Imie} i mam {Wiek} lat.");
    }
}
       class Program
{
    static void Main()
    {
        Osoba osoba1 = new Osoba();
        osoba1.Imie = "Anna";
        osoba1.Wiek = 25;

        Osoba osoba2 = new Osoba();
        osoba2.Imie = "Piotr";
        osoba2.Wiek = 30;

        Osoba osoba3 = new Osoba();
        osoba3.Imie = "Kasia";
        osoba3.Wiek = 22;

        osoba1.PrzedstawSie();
        osoba2.PrzedstawSie();
        osoba3.PrzedstawSie();
    }
}*/
//zad5
/*
class KontoBankowe
{
private double saldo;
public void Wplata(double kwota) { saldo += kwota; }

 public bool Wyplata(double kwota)
    {
        if (kwota <= saldo)
        {
            saldo -= kwota;
            return true; 
        }
        else
        {
            return false; 
        }
    }
public double PobierzSaldo() { return saldo; }
}*/
//zad6
/*
class Zwierze
{
public void Jedz() => Console.WriteLine("Zwierzę je");
}
class Pies : Zwierze
{
public void Szczekaj() => Console.WriteLine("Hau hau!");
}
class Kot : Zwierze
{
public void Miaucz() => Console.WriteLine("Miau"); 
}*/
//zad7
/*
class Zwierze
{
public virtual void DajGlos() => Console.WriteLine("Zwierzę wydaje dźwięk");
}
class Pies : Zwierze
{
public override void DajGlos() => Console.WriteLine("Hau hau!");
}
class Kot : Zwierze
{
public override void DajGlos() => Console.WriteLine("Miau!");
}

class Program
{
    static void Main()
    {
        Zwierze[] zwierzeta = new Zwierze[]
        {
            new Pies(),
            new Kot(),
            new Pies(),
            new Kot()
        };

        foreach (Zwierze zwierze in zwierzeta)
        {
            zwierze.DajGlos();
        }
    }
}*/
//mini projekt

class Pojazd
{
public virtual void Start() => Console.WriteLine("Pojazd uruchomiony");
}
class Samochod : Pojazd
{
public void Jedz() => Console.WriteLine("Samochód jedzie");
}
class ElektrycznySamochod : Samochod
{
public void Laduj() => Console.WriteLine("Ładowanie baterii...");
}