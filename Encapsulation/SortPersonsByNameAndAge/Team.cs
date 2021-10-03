using System.Collections.Generic;
using System.Linq;

namespace PersonsInfo
{
    public class Team // Task 04. First And Reserve Team
    {
        private string name;
        private List<Person> firstTeam;
        private List<Person> reserveTeam;

        public Team(string name)
        {
            Name = name;
            reserveTeam = new List<Person>();
            firstTeam = new List<Person>();
        }

        public IReadOnlyList<Person> ReserveTeam
        {
            get { return reserveTeam.AsReadOnly(); }
        }


        public IReadOnlyList<Person> FirstTeam
        {
            get { return firstTeam.AsReadOnly(); }
        }


        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public void AddPlayer(Person person)
        {
            if (person.Age <= 40)
            {
                firstTeam.Add(person);
            }
            else
            {
                reserveTeam.Add(person);
            }
        }
    }
}
