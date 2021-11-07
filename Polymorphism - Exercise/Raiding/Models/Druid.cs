namespace Raiding
{
    public class Druid : BaseHero
    {
        private const int DefaultDruidPower = 80;

        public Druid(string name)
            : base(name, DefaultDruidPower)
        {
        }

        public override string CastAbility()
            => base.CastAbility() + $"healed for {Power}";
    }
}
