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
            Location = "Online";
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

        public void ReserveTicket(Concert concert, int amount)
        {
            if (concert.AvailableSeats >= amount)
            {
                concert.ReserveSeat();
                for (int i = 0; i < amount; i++)
                {
                    Ticket ticket = new Ticket(concert, concert.Price, i + 1);
                    tickets.Add(ticket);
                    Console.WriteLine($"Zarezerwowano bilet na koncert {concert.Name}, numer miejsca: {i+1}");
                }
            }
            else
            {
                Console.WriteLine($"Brak wystarczającej liczby dostępnych miejsc. Dostępne miejsca: {concert.AvailableSeats}");
            }
        }
    }

    static void Main(string[] args)
    {
        Concert zenek = new RegularConcert("Zenek", DateTime.Now.AddDays(7), "Warszawa", 100, 150.00m);
        Concert vipGolec = new VIPConcert("Bracia Golec", DateTime.Now.AddDays(10), "Kraków", 20, 500.00m);
        Concert onlineMaryla = new OnlineConcert("Maryla Rodowicz", DateTime.Now.AddDays(14), 200, 80.00m);
        
        BookingSystem bookingSystem = new BookingSystem();
        bookingSystem.AddConcert(zenek);
        bookingSystem.AddConcert(vipGolec);
        bookingSystem.AddConcert(onlineMaryla);
        
        bookingSystem.ReserveTicket(zenek, 5);
    }
}

