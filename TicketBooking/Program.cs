// See https://aka.ms/new-console-template for more information

using System.Runtime.InteropServices.JavaScript;
using static System.Console;

internal class Program
{
    public class Concert
    {
        public string Name { get; set; }
        
        public JSType.Date Date { get; set; }
        
        public string Location { get; set; }
        
        public int AvailableSeats { get; set; }
    }

    public class Ticket
    {
        public string Concert { get; set; }
        public int Price { get; set; }
        public int SeatNumber { get; set; }
    }
}