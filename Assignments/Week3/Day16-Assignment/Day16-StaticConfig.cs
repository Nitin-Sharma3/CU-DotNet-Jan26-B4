using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopsDemo
{
    class ApplicationConfig
    {
        public static string ApplicationName { get; set; }
        public static string Environment { get; set; }
        public static int AccessCount{ get; set; }
        public static bool IsInitialized { get; set; }
        static ApplicationConfig()
        {
            ApplicationName = "MyApp";
            Environment = "Development";
            AccessCount = 0;
            IsInitialized = false;
            Console.WriteLine("Static Constructor Executed!");
        }
        public static void Initialized(string appname,string environment)
        {
            ApplicationName= appname;
            Environment = environment;
            IsInitialized= true;
            AccessCount++;
        }
        public static string GetConfigurationSummary()
        {
            AccessCount++;
            return $"Application Name: {ApplicationName}\t" +
                $"Environment: {Environment}\t" +
                $"Access Count: {AccessCount}\t" +
                $"Initialization Status: {IsInitialized}";
        }
        public static void ResetConfiguration()
        {
            ApplicationName = "MyApp";
            Environment = "Development";
            IsInitialized = false;
            AccessCount=0;
            Console.WriteLine("=======config is reset =========");
        }
    }
    internal class Day16_StaticConfig
    {
        static void Main(string[] args)
        {
            //ApplicationConfig config = new ApplicationConfig();
            ApplicationConfig.Initialized("Nitin's app", "Debugging");
            Console.WriteLine(ApplicationConfig.GetConfigurationSummary()); ;
            ApplicationConfig.ResetConfiguration();
            Console.WriteLine(ApplicationConfig.GetConfigurationSummary()); ;



        }
    }
}
