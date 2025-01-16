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
    }
    public class RegularConcert
    {
        public string Name { get; set; }
        
        public JSType.Date Date { get; set; }
        
        public string Location { get; set; }
        
        public int AvailableSeats { get; set; }
        
        public decimal Price { get; set; }
    }

    public class Ticket
    {
        public string Concert { get; set; }
        public decimal Price { get; set; }
        public int SeatNumber { get; set; }
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