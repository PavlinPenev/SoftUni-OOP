using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Models.Equipment
{
    public class Kettlebell : Equipment
    {
        private const double DefaultKettleBellWeight = 10000;
        private const decimal DefaultKettleBellPrice = 80;
        public Kettlebell() 
            : base(DefaultKettleBellWeight, DefaultKettleBellPrice)
        {
        }
    }
}
