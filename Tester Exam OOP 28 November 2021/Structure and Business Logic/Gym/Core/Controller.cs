using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gym.Core.Contracts;
using Gym.Models.Athletes;
using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms;
using Gym.Models.Gyms.Contracts;
using Gym.Repositories;
using Gym.Utilities.Messages;

namespace Gym.Core
{
    public class Controller : IController
    {
        private EquipmentRepository _equipmentRepository = new EquipmentRepository();
        private ICollection<IGym> _gyms = new List<IGym>();

        public string AddGym(string gymType, string gymName)
        {
            IGym currentGym;
            switch (gymType)
            {
                case "BoxingGym":
                    currentGym = new BoxingGym(gymName);
                    break;
                case "WeightliftingGym":
                    currentGym = new WeightliftingGym(gymName);
                    break;
                default:
                    throw new InvalidOperationException(ExceptionMessages.InvalidGymType);
            }
            _gyms.Add(currentGym);
            return string.Format(OutputMessages.SuccessfullyAdded, gymType);
        }

        public string AddEquipment(string equipmentType)
        {
            IEquipment equipment;
            switch (equipmentType)
            {
                case "BoxingGloves":
                    equipment = new BoxingGloves();
                    break;
                case "Kettlebell":
                    equipment = new Kettlebell();
                    break;
                default:
                    throw new InvalidOperationException(ExceptionMessages.InvalidEquipmentType);
            }
            _equipmentRepository.Add(equipment);
            return string.Format(OutputMessages.SuccessfullyAdded, equipmentType);
        }

        public string InsertEquipment(string gymName, string equipmentType)
        {
            IGym gym = _gyms.FirstOrDefault(g => g.Name == gymName);
            IEquipment equipmentToAdd =
                _equipmentRepository.Models.FirstOrDefault(e => e.GetType().Name == equipmentType);
            if (equipmentToAdd == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InexistentEquipment, equipmentType));
            }
            gym.AddEquipment(equipmentToAdd);
            _equipmentRepository.Remove(equipmentToAdd);
            return string.Format(OutputMessages.EntityAddedToGym, equipmentType, gymName);
        }

        public string AddAthlete(string gymName, string athleteType, string athleteName, string motivation, int numberOfMedals)
        {
            IAthlete athlete;
            switch (athleteType)
            {
                case "Boxer":
                    athlete = new Boxer(athleteName, motivation, numberOfMedals);
                    break;
                case "Weightlifter":
                    athlete = new Weightlifter(athleteName, motivation, numberOfMedals);
                    break;
                default:
                    throw new InvalidOperationException(ExceptionMessages.InvalidAthleteType);
            }

            string gymType = _gyms.FirstOrDefault(g => g.Name == gymName).GetType().Name;
            IGym gym = _gyms.FirstOrDefault(g => g.Name == gymName);
            switch (gymType)
            {
                case "BoxingGym":
                    if (athleteType == "Boxer")
                    {
                        gym.AddAthlete(athlete);
                    }
                    else
                    {
                        return OutputMessages.InappropriateGym;
                    }

                    break;
                case "WeightliftingGym":
                    if (athleteType == "Weightlifter")
                    {
                        gym.AddAthlete(athlete);
                    }
                    else
                    {
                        return OutputMessages.InappropriateGym;
                    }
                    break;
                default:
                    return OutputMessages.InappropriateGym;
            }

            return string.Format(OutputMessages.EntityAddedToGym, athleteType, gymName);
        }

        public string TrainAthletes(string gymName)
        {
            IGym gym = _gyms.FirstOrDefault(g => g.Name == gymName);
            gym.Exercise();
            return string.Format(OutputMessages.AthleteExercise, gym.Athletes.Count);
        }

        public string EquipmentWeight(string gymName)
        {
            IGym gym = _gyms.FirstOrDefault(g => g.Name == gymName);
            return string.Format(OutputMessages.EquipmentTotalWeight, gymName, gym.EquipmentWeight);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var gym in _gyms)
            {
                sb.AppendLine(gym.GymInfo());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
