using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public class WarriorCreator : HeroCreator
    {
        private string _name;

        public WarriorCreator(string name)
        {
            _name = name;
        }

        public override BaseHero GetHero()
            => new Warrior(_name);
    }
}
