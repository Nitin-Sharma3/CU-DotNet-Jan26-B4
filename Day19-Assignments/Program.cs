using System.Threading.Channels;

namespace Assignment
{
    abstract class Vehicle
    {
        public string ModelName { get; set; }
        public abstract void Move();
        public virtual string GetFuelStatus()
        {
            return new string("Fuel Level is stable!");
        }
        public Vehicle(string model)
        {
            ModelName = model;
        }
    }
    class ElectricCar : Vehicle
    {
        public ElectricCar(string model):base(model)
        {
            ModelName = model;
        }
        public override void Move()
        {
            Console.WriteLine($"{ModelName} is gliding silently on battery power.");
        }
        public override string GetFuelStatus()
        {
            return new string($"{ModelName} battery is at 80%");
        }
    }
    class HeavyTruck : Vehicle
    {
        public HeavyTruck(string model) : base(model)
        {
            ModelName = model;
        }
        public override void Move()
        {
            Console.WriteLine($"{ModelName} is hauling cargo with high-torque" +
                $"diesel power.");
        }
    }
    class CargoPlane : Vehicle
    {
        public CargoPlane(string model) : base(model)
        {
            ModelName = model;
        }
        public override void Move()
        {
            Console.WriteLine($"{ModelName} is ascending at 30,000 feet.");
        }
        public override string GetFuelStatus()
        {
            return base.GetFuelStatus()+"| Checking jet Fuel reserves...";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Vehicle[] vehicles = new Vehicle[] {
                new CargoPlane("Sukhoi 57"),
                new HeavyTruck("AshokTrucks"),
                new CargoPlane("SR71 Blackbird"),
                new ElectricCar("Mahindra SUV"),
            };
            foreach (var vehicle in vehicles)
            {
                Console.WriteLine(vehicle.GetFuelStatus());
                vehicle.Move();
            }
        }
    }
}
