using System;

namespace ValidPerson
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Person validPerson = new Person("Pavlin", "Penev", 30);
            try
            {
                Person personWithoutFirstName = new Person(string.Empty, "Djebir", 21);
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.Message);
            }
            try
            {
                Person personWithoutLastName = new Person("Veronica", string.Empty, 23);
            }
            catch (ArgumentNullException e) 
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                Person personWithNegativeAge = new Person("Baba", "Vuna", -100);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                Person personWithAgeOver120 = new Person("Iwanka", "Mitowska", 121);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                Student randomStudent = new Student("P3sho", "softuni.klasicheskiprimer@asiktir.com");
            }
            catch (InvalidPersonNameException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
