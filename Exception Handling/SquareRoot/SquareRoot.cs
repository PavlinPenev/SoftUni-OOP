using System;

namespace SquareRoot
{
    class SquareRoot
    {
        static void Main(string[] args)
        {
            try
            {
                string n = Console.ReadLine();
                NumberValidator.Validate(n);
                Console.WriteLine(Math.Sqrt(int.Parse(n)));
            }
            catch (InvalidNumberException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Goodbye");
            }

        }

        class InvalidNumberException : OverflowException
        {
            public InvalidNumberException(string? message) 
                : base(message)
            {
            }
        }

        static class NumberValidator
        {
            public static void Validate(string n)
            {
                if (!int.TryParse(n, out int _))
                {
                    throw new InvalidNumberException("Invalid number");
                }

                if (int.Parse(n) < 0)
                {
                    throw new InvalidNumberException("Invalid number");
                }
            }
        }
    }
}
