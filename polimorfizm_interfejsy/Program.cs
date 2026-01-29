//zad1
/*
class Zwierze
{
public virtual void DajGlos()
{
Console.WriteLine("Zwierzę wydaje dźwięk");
}
}
class Pies : Zwierze
{
public override void DajGlos()
{
Console.WriteLine("Hau hau!");
}
}
class Kot : Zwierze
{
public override void DajGlos()
{
Console.WriteLine("Miau!");
}
}
class Krowa : Zwierze
{
public override void DajGlos()
{
Console.WriteLine("Muuuu!");
}
}

class Program
{
static void Main()
{
Zwierze[] zwierzeta = { new Pies(), new Kot(), new Krowa()};
foreach (Zwierze z in zwierzeta)
{
z.DajGlos();
}
}
}*/
//zad2
/*
abstract class Pojazd
{
public string Marka { get; set; }
public abstract void UruchomSilnik();
public void Info()
{
Console.WriteLine($"Pojazd marki {Marka}");
}
}
class Samochod : Pojazd
{
public override void UruchomSilnik()
{
Console.WriteLine("Silnik samochodu został uruchomiony");
}
}
class Motocykl : Pojazd
{
public override void UruchomSilnik()
{
Console.WriteLine("Motocykl odpala z głośnym dźwiękiem");
}
}
class Ciezarowka : Pojazd
{
public override void UruchomSilnik()
{
Console.WriteLine("Ciężarówka odpala silnik");
}    
}

class Program
{
    static void Main()
    {
        List<Pojazd> pojazdy = new List<Pojazd>
        {
            new Samochod { Marka = "Toyota" },
            new Motocykl { Marka = "Yamaha" },
            new Ciezarowka { Marka = "Volvo" }
        };

        foreach (Pojazd pojazd in pojazdy)
        {
            pojazd.Info();
            pojazd.UruchomSilnik();
            Console.WriteLine();
        }
    }
}*/
//zad3
/*
interface IDrukowalne
{
void Drukuj();
}
class Dokument : IDrukowalne
{
public void Drukuj()
{
Console.WriteLine("Dokumęt się drukuje...");
}
}
class Zdjecie : IDrukowalne
{
public void Drukuj()
{
Console.WriteLine("Zdjęcie jest drukowane...");
}
}
class Program
{
static void Main()
{
IDrukowalne[] wydruki =
{
new Dokument(),
new Zdjecie()
};
foreach (IDrukowalne w in wydruki)
{
w.Drukuj();
}
}
}*/
//zad4
abstract class Zwierze
{
public string Nazwa { get; set; }
public abstract void WydajDzwiek();
}
interface IKarmione
{
void Jedz();
}
interface ITrenowane
{
void Trenuj();   
}
class Lew : Zwierze, IKarmione
{
public override void WydajDzwiek()
{
Console.WriteLine("Lew: Roooar!");
}
public void Jedz()
{
Console.WriteLine("Lew je mięso.");
}
}
class Slon : Zwierze, IKarmione, ITrenowane
{
public override void WydajDzwiek()
{
Console.WriteLine("Słoń: Truuu!");
}
public void Jedz()
{
Console.WriteLine("Słoń je trawę.");
}
public void Trenuj()
{
Console.WriteLine("Słoń trenuje.");        
}
}
class Papuga : Zwierze, IKarmione
{
public override void WydajDzwiek()
{
Console.WriteLine("Papuga: Witaj!");
}
public void Jedz()
{
Console.WriteLine("Papuga je ziarno.");
}
}
class Tygrys : Zwierze, IKarmione, ITrenowane
{
public override void WydajDzwiek()
{
Console.WriteLine("Tygrys: Roooar!");
}
public void Jedz()
{
Console.WriteLine("Tygrys je mięso.");
}
public void Trenuj()
{
Console.WriteLine("Tygrys trenuje.");        
}    
}

class Program
{
static void Main()
{
List<Zwierze> zwierzeta = new List<Zwierze>
{
new Lew { Nazwa = "Simba" },
new Slon { Nazwa = "Dumbo" },
new Papuga { Nazwa = "Polly" },
new Tygrys { Nazwa = "Diego"}
};
foreach (Zwierze z in zwierzeta)
{
Console.WriteLine($"Zwierzę: {z.Nazwa}");
z.WydajDzwiek();
if (z is ITrenowane trenowane)
{
trenowane.Trenuj();                
}else if (z is IKarmione karmione)
{
karmione.Jedz();
}
Console.WriteLine();
}
}
}