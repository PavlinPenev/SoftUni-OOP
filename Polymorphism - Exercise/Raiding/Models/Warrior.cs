using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public class Warrior : BaseHero
    {
        private const int DefaultWarriorPower = 100;

        public Warrior(string name) 
            : base(name, DefaultWarriorPower)
        {
        }

        public override string CastAbility()
            => base.CastAbility() + $"hit for {Power} damage";
    }
}
