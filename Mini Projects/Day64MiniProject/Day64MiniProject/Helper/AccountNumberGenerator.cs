namespace Day64MiniProject.Helper
{
    public class AccountNumberGenerator
    {
        public static string GenerateAccNo(int id)
        {
            int c = 0;
            int temp = id;
            while (temp > 0)
            {
                temp /= 10;
                c++;
            }
            int zeroes = 6 - c;
            string holder = string.Empty;
            for (int i = 0; i < zeroes; i++)
            {
                holder += "0";
            }
            return $"SB-2026-{holder}{id}";
        }
    }
}
