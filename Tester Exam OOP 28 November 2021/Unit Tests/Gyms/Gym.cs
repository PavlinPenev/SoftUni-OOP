namespace Gyms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Gym
    {
        private string name;
        private int capacity;
        private List<Athlete> athletes;

        public Gym(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.athletes = new List<Athlete>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(nameof(value), "Invalid gym name.");
                }

                this.name = value;
            }
        }

        public int Capacity
        {
            get
            {
                return this.capacity;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Invalid gym capacity.");
                }

                this.capacity = value;
            }
        }

        public int Count => this.athletes.Count;

        public void AddAthlete(Athlete athlete)
        {
            if (this.athletes.Count == this.capacity)
            {
                throw new InvalidOperationException("The gym is full.");
            }

            this.athletes.Add(athlete);
        }

        public void RemoveAthlete(string fullName)
        {
            Athlete athleteToRemove = this.athletes.FirstOrDefault(x => x.FullName == fullName);

            if (athleteToRemove == null)
            {
                throw new InvalidOperationException($"The athlete {fullName} doesn't exist.");
            }

            this.athletes.Remove(athleteToRemove);
        }

        public Athlete InjureAthlete(string fullName)
        {
            Athlete requestedAthlete = this.athletes.FirstOrDefault(x => x.FullName == fullName);

            if (requestedAthlete == null)
            {
                throw new InvalidOperationException($"The athlete {fullName} doesn't exist.");
            }

            requestedAthlete.IsInjured = true;

            return requestedAthlete;
        }

        public string Report()
        {
            string athleteNames = string.Join(", ", this.athletes.Where(x => !x.IsInjured).Select(f => f.FullName));
            string report = $"Active athletes at {this.Name}: {athleteNames}";

            return report;
        }
    }
}
