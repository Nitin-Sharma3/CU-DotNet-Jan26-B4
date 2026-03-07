using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    class Flight:IComparable<Flight>
    {
        public string FlightNumber { get; set; }
        public decimal Price { get; set; }
        public TimeSpan Duration { get; set; }
        public DateTime DepartureTime { get; set; }

        public int CompareTo(Flight? other)
        {
            return this.Price.CompareTo(other?.Price);
        }
        public override string ToString()
        {
            return $"Flight Number : {FlightNumber}||" +
                $"Price : {Price}||" +
                $"Duration : {Duration}||" +
                $"Departure Time : {DepartureTime}";
        }
    }
    class DurationComparer : IComparer<Flight>
    {
        public int Compare(Flight? x, Flight? y)
        {
            return x.Duration.CompareTo(y?.Duration);
        }
    }
    class DepartureComparer : IComparer<Flight>
    {
        public int Compare(Flight? x, Flight? y)
        {
            return x.DepartureTime.CompareTo(y?.DepartureTime);
        }
    }
    internal class Day20_assignment
    {
        public static void Fdisplay(List<Flight> Flights)
        {
            foreach (Flight flight in Flights)
            {
                Console.WriteLine(flight);
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            List<Flight> flights = new List<Flight>()
            {
                new Flight() { FlightNumber = "20", DepartureTime = new DateTime(2026, 8, 20), Price = 5999, Duration = new TimeSpan(5, 30, 0) },
                new Flight() { FlightNumber = "21", DepartureTime = new DateTime(2026 , 7 ,18), Price = 6999, Duration = new TimeSpan(6, 30, 0) },
                new Flight() { FlightNumber = "22", DepartureTime = new DateTime(2026 , 9 , 17), Price = 8999, Duration = new TimeSpan(2, 30, 0) },
                new Flight() { FlightNumber = "23", DepartureTime = new DateTime(2026 , 8 , 2), Price = 8999, Duration = new TimeSpan(7, 30, 0) },
                new Flight() { FlightNumber = "24", DepartureTime = new DateTime(2026, 2 , 22), Price = 3999, Duration = new TimeSpan(4, 30, 0) }
            };
            Console.WriteLine("Economy View for the Flight(Cheap Price):");
            flights.Sort();
            Fdisplay(flights);
            Console.WriteLine("============================================");
            Console.WriteLine("Business Runner View for the Flight(Shortest time):");
            flights.Sort(new DurationComparer());
            Fdisplay(flights);
            Console.WriteLine("============================================");
            Console.WriteLine("Early Bird View for the Flight(earliest departing):");
            flights.Sort(new DepartureComparer());
            Fdisplay(flights);


        }
    }
}
