using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public class Rogue : BaseHero
    {
        private const int DefaultRoguePower = 80;

        public Rogue(string name) 
            : base(name, DefaultRoguePower)
        {
        }

        public override string CastAbility()
            => base.CastAbility() + $"hit for {Power} damage";
    }
}
