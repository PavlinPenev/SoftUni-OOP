using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms.Contracts;
using Gym.Utilities.Messages;

namespace Gym.Models.Gyms
{
    public abstract class Gym : IGym
    {
        private string _name;
        private int _size;
        private List<IEquipment> _equipment = new List<IEquipment>();
        private List<IAthlete> _athletes = new List<IAthlete>();

        public Gym(string name, int size)
        {
            Name = name;
            Size = size;
        }
        public string Name
        {
            get => _name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidGymName);
                }
                _name = value;
            }
        }

        public int Size
        {
            get => _size;
            private set
            {
                _size = value;
            }
        }
        public double EquipmentWeight => _equipment.Sum(e => e.Weight);
        public ICollection<IEquipment> Equipment
        {
            get => _equipment;
        }

        public ICollection<IAthlete> Athletes
        {
            get => _athletes;
        }
        public void AddAthlete(IAthlete athlete)
        {
            if (_athletes.Count >= Size)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughSize);
            }
            _athletes.Add(athlete);
        }

        public bool RemoveAthlete(IAthlete athlete)
            =>_athletes.Remove(athlete);

        public void AddEquipment(IEquipment equipment)
        {
            Equipment.Add(equipment);
        }

        public void Exercise()
        {
            foreach (IAthlete athlete in Athletes)
            {
                athlete.Exercise();
            }
        }

        public string GymInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{Name} is a {GetType().Name}:");
            sb.AppendLine($"Athletes: {(_athletes.Count <= 0 ? "No athletes" : string.Join(", ", _athletes.Select(a => a.FullName)))}");
            sb.AppendLine($"Equipment: {_equipment.Count}");
            sb.Append($"Equipment total weight: {EquipmentWeight:f2} grams");
            return sb.ToString().TrimEnd();
        }
    }
}
