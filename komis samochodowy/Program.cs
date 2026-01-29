using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

class Pojazd
{
    public int Id { get; set; }
    public string Marka { get; set; }
    public string Model { get; set; }
    public int Rok { get; set; }
    public decimal Cena { get; set; }
}

class Komis
{
    private const string FileName = "pojazdy.json";
    private List<Pojazd> pojazdy;

    public Komis()
    {
        pojazdy = WczytajZPliku();
    }

    public void DodajPojazd()
    {
        Pojazd p = new Pojazd();
        p.Id = pojazdy.Count == 0 ? 1 : pojazdy[^1].Id + 1;

        Console.Write("Marka: ");
        p.Marka = Console.ReadLine();

        Console.Write("Model: ");
        p.Model = Console.ReadLine();

        Console.Write("Rok produkcji: ");
        p.Rok = int.Parse(Console.ReadLine());

        Console.Write("Cena: ");
        p.Cena = decimal.Parse(Console.ReadLine());

        pojazdy.Add(p);
        ZapiszDoPliku();
    }

    public void UsunPojazd()
    {
        Console.Write("Podaj ID pojazdu do usunięcia: ");
        int id = int.Parse(Console.ReadLine());

        pojazdy.RemoveAll(p => p.Id == id);
        ZapiszDoPliku();
    }

    public void ModyfikujPojazd()
    {
        Console.Write("Podaj ID pojazdu do modyfikacji: ");
        int id = int.Parse(Console.ReadLine());

        Pojazd p = pojazdy.Find(x => x.Id == id);
        if (p == null)
        {
            Console.WriteLine("Nie znaleziono pojazdu.");
            return;
        }

        Console.Write("Nowa marka: ");
        p.Marka = Console.ReadLine();

        Console.Write("Nowy model: ");
        p.Model = Console.ReadLine();

        Console.Write("Nowy rok: ");
        p.Rok = int.Parse(Console.ReadLine());

        Console.Write("Nowa cena: ");
        p.Cena = decimal.Parse(Console.ReadLine());

        ZapiszDoPliku();
    }

    public void WyswietlPojazdy()
    {
        if (pojazdy.Count == 0)
        {
            Console.WriteLine("Brak pojazdów w komisie.");
            return;
        }

        foreach (var p in pojazdy)
        {
            Console.WriteLine($"{p.Id}: {p.Marka} {p.Model}, {p.Rok}, {p.Cena} zł");
        }
    }

    private void ZapiszDoPliku()
    {
        string json = JsonSerializer.Serialize(pojazdy, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(FileName, json);
    }

    private List<Pojazd> WczytajZPliku()
    {
        if (!File.Exists(FileName))
            return new List<Pojazd>();

        string json = File.ReadAllText(FileName);
        return JsonSerializer.Deserialize<List<Pojazd>>(json);
    }
}

class Program
{
    static void Main()
    {
        Komis komis = new Komis();
        bool dziala = true;

        while (dziala)
        {
            Console.WriteLine("\n--- KOMIS SAMOCHODOWY ---");
            Console.WriteLine("1. Dodaj pojazd");
            Console.WriteLine("2. Usuń pojazd");
            Console.WriteLine("3. Modyfikuj pojazd");
            Console.WriteLine("4. Wyświetl pojazdy");
            Console.WriteLine("0. Wyjście");

            Console.Write("Wybór: ");
            string wybor = Console.ReadLine();

            switch (wybor)
            {
                case "1": komis.DodajPojazd(); break;
                case "2": komis.UsunPojazd(); break;
                case "3": komis.ModyfikujPojazd(); break;
                case "4": komis.WyswietlPojazdy(); break;
                case "0": dziala = false; break;
                default: Console.WriteLine("Nieprawidłowy wybór."); break;
            }
        }
    }
}