using System.Linq;

namespace ValidPerson
{
    public class Student
    {
        private string name;
        private string email;

        public Student(string name, string email)
        {
            Name = name;
            Email = email;
        }

        public string Name
        {
            get => name;
            set
            {
                if (value.Any(c => !char.IsLetter(c)))
                {
                    throw new InvalidPersonNameException("Name should contain only letters.");
                }
                name = value;
            }
        }

        public string Email { get; set; }

    }
}
