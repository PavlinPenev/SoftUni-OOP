using System;
using System.Collections.Generic;
using System.Text;
using Gym.Utilities.Messages;

namespace Gym.Models.Athletes
{
    public class Weightlifter : Athlete
    {
        //can train only in weightlifting gym
        private const int DefaultWeightlifterStamina = 50;
        public Weightlifter(string fullName, string motivation, int numberOfMedals) 
            : base(fullName, motivation, numberOfMedals)
        {
            Stamina = DefaultWeightlifterStamina;
        }

        public override void Exercise()
        {
            Stamina += 10;
            if (Stamina >= 100)
            {
                Stamina = 100;
                throw new ArgumentException(ExceptionMessages.InvalidStamina);
            }
        }
    }
}
