using System;

namespace EnterNumbers
{
    class EnterNumbers
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());
            for (int i = 0; i < 10; i++)
            {
                try
                {
                    ReadNumber(start, end);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                    i--;
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                    i--;
                }
            }
        }
        private static void ReadNumber(int start, int end)
        {
            string n = Console.ReadLine();
            if (!int.TryParse(n, out int _))
            {
                throw new FormatException();
            }
            if (int.Parse(n) < start || int.Parse(n) > end)
            {
                throw new ArgumentException();
            }
        }
    }
}
