// See https://aka.ms/new-console-template for more information

using System.Runtime.InteropServices.JavaScript;
using static System.Console;

internal class Program
{

    public interface Concert
    {
        string Name { get; }
        DateTime Date { get; }
        string Location { get; }
        int AvailableSeats { get; }
        decimal Price { get; }
        void ReserveSeat();
    }
    public class RegularConcert : Concert
    {
        public string Name { get; set; }
        
        public DateTime Date { get; set; }
        
        public string Location { get; set; }
        
        public int AvailableSeats { get; set; }
        
        public decimal Price { get; set; }

        public RegularConcert(string name, DateTime date, string location, int availableSeats, decimal price)
        {
            Name = name;
            Date = date;
            Location = location;
            AvailableSeats = availableSeats;
            Price = price;
        }

        public void ReserveSeat()
        {
            if (AvailableSeats > 0)
            {
                Console.WriteLine($"Zarezerwowano miejsce na koncert {Name}");
                AvailableSeats--;
            }
            else
            {
                Console.WriteLine("Bilety zostały wyprzedane");
            }
        }
    }
    
    public class VIPConcert : Concert
    {
        public string Name { get; set; }
        
        public DateTime Date { get; set; }
        
        public string Location { get; set; }
        
        public int AvailableSeats { get; set; }
        
        public decimal Price { get; set; }

        public VIPConcert(string name, DateTime date, string location, int availableSeats, decimal price)
        {
            Name = name;
            Date = date;
            Location = location;
            AvailableSeats = availableSeats;
            Price = price;
        }

        public void ReserveSeat()
        {
            if (AvailableSeats > 0)
            {
                Console.WriteLine($"Zarezerwowano miejsce na koncert VIP {Name}");
                AvailableSeats--;
            }
            else
            {
                Console.WriteLine("Bilety zostały wyprzedane");
            }
        }
    }
    
    public class OnlineConcert : Concert
    {
        public string Name { get; set; }
        
        public DateTime Date { get; set; }
        
        public string Location { get; set; }
        
        public int AvailableSeats { get; set; }
        
        public decimal Price { get; set; }

        public OnlineConcert(string name, DateTime date, int availableSeats, decimal price)
        {
            Name = name;
            Date = date;
            Location = null;
            AvailableSeats = availableSeats;
            Price = price;
        }

        public void ReserveSeat()
        {
            if (AvailableSeats > 0)
            {
                Console.WriteLine($"Zarezerwowano miejsce na koncert online {Name}");
                AvailableSeats--;
            }
            else
            {
                Console.WriteLine("Bilety zostały wyprzedane");
            }
        }
    }

    public class Ticket
    {
        public Concert Concert { get; set; }
        public decimal Price { get; set; }
        public int SeatNumber { get; set; }

        public Ticket(Concert concert, decimal price, int seatNumber)
        {
            Concert = concert;
            Price = price;
            SeatNumber = seatNumber;
        }
    }

    public class BookingSystem
    {
        private List<Concert> concerts = new List<Concert>();
        private List<Ticket> tickets = new List<Ticket>();

        public void AddConcert(Concert concert)
        {
            concerts.Add(concert);
            Console.WriteLine($"Dodano nowy koncert: {concert.Name}, odbędzie się on {concert.Date}");
        }
    }
}