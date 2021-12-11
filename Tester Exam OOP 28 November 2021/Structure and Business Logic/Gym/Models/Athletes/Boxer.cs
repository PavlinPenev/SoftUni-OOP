using System;
using System.Collections.Generic;
using System.Text;
using Gym.Utilities.Messages;

namespace Gym.Models.Athletes
{
    public class Boxer : Athlete
    {
        // can train only in boxing gym
        private const int DefaultStaminaBoxer = 60;
        public Boxer(string fullName, string motivation, int numberOfMedals) 
            : base(fullName, motivation, numberOfMedals)
        {
            Stamina = DefaultStaminaBoxer;
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
