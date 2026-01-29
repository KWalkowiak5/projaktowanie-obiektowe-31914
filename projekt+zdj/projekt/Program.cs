using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

#region ENUM
enum RoomStatus
{
    Available,
    Occupied
}
#endregion

#region CLASSES

abstract class Room
{
    //hermetyzacja
    public int RoomNumber { get; private set; }
    public decimal PricePerNight { get; protected set; }
    public RoomStatus Status { get; private set; }

    protected Room(int number, decimal price)
    {
        RoomNumber = number;
        PricePerNight = price;
        Status = RoomStatus.Available;
    }

    public void Occupy() => Status = RoomStatus.Occupied;
    public void Free() => Status = RoomStatus.Available;
    //polimorfizm
    public abstract string GetDescription();
}

class SingleRoom : Room
{
    //dziedziczenie
    public SingleRoom(int number, decimal price) : base(number, price) { }
    //polimorfizm
    public override string GetDescription()
    {
        return $"Pokój jednoosobowy {RoomNumber} | {PricePerNight} PLN/noc | {Status}";
    }
}

class SuiteRoom : Room
{
    //dziedziczenie
    public SuiteRoom(int number, decimal price) : base(number, price) { }
    //polimorfizm
    public override string GetDescription()
    {
        return $"Apartament {RoomNumber} | {PricePerNight} PLN/noc | {Status}";
    }
}

class Client
{
    public string Name { get; private set; }

    public Client(string name)
    {
        Name = name;
    }

    public override string ToString() => Name;
}

class Reservation
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public Client Client { get; set; }
    public Room Room { get; set; }
    public DateTime From { get; set; }
    public DateTime To { get; set; }
    public decimal TotalPrice { get; private set; }

    public Reservation(Client client, Room room, DateTime from, DateTime to)
    {
        Client = client;
        Room = room;
        From = from;
        To = to;

        int days = (To - From).Days;
        TotalPrice = days * room.PricePerNight;

        room.Occupy();
    }

    public override string ToString()
    {
        return $"ID: {Id}\nKlient: {Client}\nPokój: {Room.RoomNumber}\nTermin: {From:d} - {To:d}\nCena: {TotalPrice} PLN\n";
    }
}

class Hotel
{
    //kolekcje generyczne
    public List<Room> Rooms { get; set; } = new();
    public List<Reservation> Reservations { get; set; } = new();

    public Hotel()
    {
        Rooms.Add(new SingleRoom(101, 200));
        Rooms.Add(new SingleRoom(102, 220));
        Rooms.Add(new SuiteRoom(201, 450));
    }

    public void ShowRooms()
    {
        foreach (var room in Rooms)
            Console.WriteLine(room.GetDescription());
    }

    public void AddReservation()
    {
        Console.Write("Imię klienta: ");
        string name = Console.ReadLine();

        Console.Write("Numer pokoju: ");
        int roomNumber = int.Parse(Console.ReadLine());

        Room room = Rooms.FirstOrDefault(r => r.RoomNumber == roomNumber);
        if (room == null)
        {
            Console.WriteLine("Pokój nie istnieje.");
            return;
        }

        if (room.Status == RoomStatus.Occupied)
        {
            Console.WriteLine("Pokój jest aktualnie zajęty.");
            return;
        }

        Console.Write("Data od (yyyy-mm-dd): ");
        DateTime from = DateTime.Parse(Console.ReadLine());

        Console.Write("Data do (yyyy-mm-dd): ");
        DateTime to = DateTime.Parse(Console.ReadLine());

        Reservation reservation = new Reservation(
            new Client(name), room, from, to);

        Reservations.Add(reservation);

        Console.WriteLine("Rezerwacja dodana!");
        Console.WriteLine($"Cena całkowita: {reservation.TotalPrice} PLN");
    }

    public void ShowReservations()
    {
        if (Reservations.Count == 0)
        {
            Console.WriteLine("Brak rezerwacji.");
            return;
        }

        foreach (var r in Reservations)
            Console.WriteLine(r);
    }

    public void CancelReservation()
    {
        Console.Write("Podaj ID rezerwacji: ");
        Guid id = Guid.Parse(Console.ReadLine());

        Reservation reservation = Reservations.FirstOrDefault(r => r.Id == id);
        if (reservation == null)
        {
            Console.WriteLine("Nie znaleziono rezerwacji.");
            return;
        }

        reservation.Room.Free();
        Reservations.Remove(reservation);

        Console.WriteLine("Rezerwacja została anulowana.");
    }
}

static class DataManager
{
    private const string FileName = "data.json";

    public static void Save(Hotel hotel)
    {
        var json = JsonSerializer.Serialize(hotel, new JsonSerializerOptions
        {
            WriteIndented = true
        });

        File.WriteAllText(FileName, json);
    }

    public static Hotel Load()
    {
        if (!File.Exists(FileName))
            return new Hotel();

        string json = File.ReadAllText(FileName);
        return JsonSerializer.Deserialize<Hotel>(json) ?? new Hotel();
    }
}

#endregion

class Program
{
    static void Main()
    {
        Hotel hotel = DataManager.Load();
        bool running = true;

        while (running)
        {
            Console.Clear();
            Console.WriteLine("=== SYSTEM REZERWACJI HOTELU ===");
            Console.WriteLine("1. Pokaż pokoje");
            Console.WriteLine("2. Dodaj rezerwację");
            Console.WriteLine("3. Pokaż rezerwacje");
            Console.WriteLine("4. Anuluj rezerwację");
            Console.WriteLine("5. Zapisz i wyjdź");
            Console.Write("Wybierz opcję: ");

            switch (Console.ReadLine())
            {
                case "1":
                    hotel.ShowRooms();
                    break;
                case "2":
                    hotel.AddReservation();
                    break;
                case "3":
                    hotel.ShowReservations();
                    break;
                case "4":
                    hotel.CancelReservation();
                    break;
                case "5":
                    DataManager.Save(hotel);
                    running = false;
                    break;
                default:
                    Console.WriteLine("Nieprawidłowy wybór.");
                    break;
            }

            Console.WriteLine("\nENTER aby kontynuować...");
            Console.ReadLine();
        }
    }
}