using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public class PaladinCreator : HeroCreator
    {
        private string _name;

        public PaladinCreator(string name)
        {
            _name = name;
        }

        public override BaseHero GetHero()
            => new Paladin(_name);
    }
}
