using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public class DruidCreator : HeroCreator
    {
        private string _name;

        public DruidCreator(string name)
        {
            _name = name;
        }

        public override BaseHero GetHero()
            => new Druid(_name);
    }
}
