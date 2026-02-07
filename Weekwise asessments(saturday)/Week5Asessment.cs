using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    class RestrictedDestinationException : Exception
    {
        public RestrictedDestinationException(string message):base(message) {
            Console.WriteLine("The Shipment destination is restricted and cannot be processed");
        }
    }
    class InsecurePackagingException :Exception{
        public InsecurePackagingException(string message):base(message) {
            Console.WriteLine("The packagin is insecure.");
        }
    }
    interface ILoggable
    {
        public void SaveLog(string message);
    }
    abstract class Shipment
    {
        public string TrackingId { get; set; }
        public double Weight { get; set; }
        public string Destination { get; set; }
        public bool HeavyLift { get; set; }
        public bool enableFragilePacking { get; set; }
        public bool Reinforced { get; set; }
        public abstract void ProcessShipment();
    }
    class ExpressShipment : Shipment
    {


        public override void ProcessShipment()
        {
            if(Weight>250)enableFragilePacking = true;
        }

        public override string ToString()
        {
            return $"Tracking ID: {TrackingId} |Weight: {Weight} |Destination: " +
                $"{Destination} |FragilePackaging: {enableFragilePacking}";
        }
    }
    class HeavyFreight : Shipment
    {


        public override void ProcessShipment()
        {
            if (Weight > 1000) { HeavyLift = true; }

        }
        public override string ToString()
        {
            return $"Tracking ID: {TrackingId} |Weight: {Weight} |Destination: " +
             $"{Destination}| HeavyLift Permit: {HeavyLift}";
        }
    }
    class LogManager : ILoggable
    {
        public void SaveLog(string message)
        {
            try
            {
                using StreamWriter s1 = new StreamWriter(@"..\..\..\shipment_audit.log", true);
                s1.WriteLine(message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in file access");
            }

        }
    }
    internal class Week5Asessment
    {
        static void Main(string[] args)
        {
            List<Shipment> L = new List<Shipment>()
            {
                new ExpressShipment(){Destination="India", TrackingId="1", Weight=260},
                new HeavyFreight(){Destination="Canada", TrackingId="2B", Weight=1500},
                new ExpressShipment(){ Destination="Epstein Island", TrackingId="3B2", Weight=490, Reinforced=true}
            };
            string[] RestPlaces = { "North Pole", "South Pole", "Antarctica", "Epstein Island" }; 
            LogManager logger = new LogManager();

            foreach (Shipment shipment in L)
            {
                try
                {
                    shipment.ProcessShipment();
                    if (shipment is ExpressShipment && shipment.Reinforced==false) throw new InsecurePackagingException("Package is Insecure!");
                    if (RestPlaces.Contains(shipment.Destination)) throw new RestrictedDestinationException("Restricted Destination Entered!");
                    if (shipment.Weight <= 0) throw new ArgumentOutOfRangeException($"Weight: {shipment.Weight} is not Valid.");
                    logger.SaveLog(shipment.ToString());
                }
                catch (Exception ex)
                {
                    logger.SaveLog($"ERROR | {shipment.TrackingId} | {ex.Message}");
                }
                finally
                {
                    Console.WriteLine("Processing Finished for ID: " +shipment.TrackingId);
                }
            }
        }

    }
}

