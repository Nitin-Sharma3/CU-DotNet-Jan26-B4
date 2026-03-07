namespace CSharpLearning
{
    internal class Day8Exercise
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Write the <UserName>|<LoginMessage> in same format: ");
            string command = Console.ReadLine();
            string temp = command;
            string[] spl = temp.Split('|');
            command = command.Trim();
            command = command.ToLower();
            Console.WriteLine($"USER: {spl[0]}");
            Console.WriteLine($"MESSAGE: {spl[1]}");
            if (!command.Contains("successful")) { Console.WriteLine("STATUS: LOGIN FAILED"); }
            else if (command.Equals(command)) { Console.WriteLine("STATUS: LOGIN SUCCESS"); }
            else { Console.WriteLine("STATUS: LOGIN SUCCESS(CUSTOM MESSAGE)"); }
        }
    }
}
