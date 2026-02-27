

namespace Day7projet
{
    internal class SolDay7
    {

        static bool validGateCode(string gateCode)
        {
            if (gateCode == null || gateCode.Length != 2) return false;
            if (!char.IsLetter(gateCode[0])) return false;
            if (!char.IsDigit(gateCode[1])) return false;
            return true;
        }
        static bool validInitial(char ini)
        {
            if (!char.IsUpper(ini)) return false;
            return true;
        }

        static bool validAccess(byte lvl)
        {
            if (lvl > 1 && lvl < 7) return true;
            return false;
        }

        static bool validAttempts(byte attempt)
        {
            if (attempt > 200) return false;
            return true;
        }

        static void Main(string[] args)
        {
            Console.WriteLine(" ENTER GateCode, UserInitial, AccessLevel, IsActive, Attempts>");
            string[] arr = Console.ReadLine().Split("|");
            string GateCode = arr[0];
            char UserInitial = char.Parse(arr[1]);
            byte AccessLevel = byte.Parse(arr[2]);
            bool IsActive = bool.Parse(arr[3]);
            byte Attempts = byte.Parse(arr[4]);

            if (!validGateCode(GateCode) || !validInitial(UserInitial) || !validAccess(AccessLevel) ||
                 !validAttempts(Attempts))
            {
                Console.WriteLine("•\tINVALID ACCESS LOG");
                return;
            }

            if (!IsActive) Console.WriteLine("•\tACCESS DENIED – INACTIVE USER");
            else if (Attempts > 100) Console.WriteLine("•\tACCESS DENIED – TOO MANY ATTEMPTS");
            else if (AccessLevel >= 5) Console.WriteLine("•\tACCESS GRANTED – HIGH SECURITY");
            else Console.WriteLine("•\tACCESS GRANTED");



        }
    }
}
