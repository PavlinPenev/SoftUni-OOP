using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public class Paladin : BaseHero
    {
        private const int DefaultPaladinPower = 100;
        public Paladin(string name)
            : base(name, DefaultPaladinPower)
        {
        }
        public override string CastAbility()
            => base.CastAbility() + $"healed for {Power}";
    }
}
