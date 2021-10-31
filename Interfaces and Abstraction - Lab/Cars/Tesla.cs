using System.Text;

namespace Cars
{
    public class Tesla : IElectricCar
    {
        public Tesla(string model, string color, int battery)
        {
            Model = model;
            Color = color;
            Battery = battery;
        }

        public string Model { get; private set; }
        public string Color { get; private set; }

        public string Start()
            => "Engine start";

        public string Stop()
            => "Breaaak!";

        public int Battery { get; private set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{Color} Tesla {Model} with {Battery} Batteries");
            sb.AppendLine($"{Start()}");
            sb.Append($"{Stop()}");
            return sb.ToString();
        }
    }
}
