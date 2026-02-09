namespace ConsoleApp1
{
    interface ITimer
    {
        public void SetTimer(int time);

    }
    interface ISmart
    {
        public abstract bool Ismart();

    }
    abstract class KitchenElectricAppliances:ISmart
    {
        public int ElectricVoltage { get; set; }
        public string ModelName { get; set; }
        public int Price { get; set; }
        public abstract void Cook();

        public virtual bool Ismart()
        {
            return true;
        }
    }
    class Microwave : KitchenElectricAppliances, ITimer
    {
        public override void Cook()
        {
            Console.WriteLine("Cooking in Microwave");
        }

        public override bool Ismart()
        {
            return false;
        }
        public void SetTimer(int time)
        {

            for (int i = 0; i < time; i++)
            {
                Console.WriteLine("Waiting...");
            }
            Console.WriteLine("================= Time is Up! ===================");
        }
    }
    class ElectricOven : KitchenElectricAppliances, ITimer
    {
        public override void Cook()
        {
            Console.WriteLine("Cooking in Electric Oven");
        }

        public override bool Ismart()
        {
            return true;
        }

        public void SetTimer(int time)
        {
            Console.WriteLine($"Timer is set to :{time} seconds ");
        }
    }
    class AirFryer : KitchenElectricAppliances, ITimer
    {
        public override void Cook()
        {
            Console.WriteLine("Cooking in AirFryer");
        }

        public override bool Ismart()
        {
            return false;
        }

        public void SetTimer(int time)
        {
            Console.WriteLine("Timer is set for " + time + " seconds");
        }
    }

        internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello, World!");
            List<KitchenElectricAppliances> L = new List<KitchenElectricAppliances>()
            {
                new ElectricOven(),
                new AirFryer(),
                new Microwave()
            };

            foreach (var l in L)
            {
                l.Cook();
                Console.WriteLine( l.Ismart());
                

            }
        }
    }
}
