namespace GreetingSolution
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Write your name : ");
            string s = null;
            s= Console.ReadLine();
            Console.WriteLine(GreetingLibrary.GreetingHelper.GetGreeting(s));
        }
    }
}
