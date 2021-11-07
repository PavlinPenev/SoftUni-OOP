using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public class RogueCreator : HeroCreator
    {
        private string _name;

        public RogueCreator(string name)
        {
            _name = name;
        }

        public override BaseHero GetHero()
            => new Rogue(_name);
    }
}
