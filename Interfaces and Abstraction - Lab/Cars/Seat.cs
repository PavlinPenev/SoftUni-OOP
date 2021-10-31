using System.Text;

namespace Cars
{
    public class Seat : ICar
    {
        public Seat(string model, string color)
        {
            Model = model;
            Color = color;
        }

        public string Model { get; private set; }
        public string Color { get; private set; }
        public string Start()
            => "Engine start";

        public string Stop()
            => "Breaaak!";
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{Color} Seat {Model}");
            sb.AppendLine($"{Start()}");
            sb.Append($"{Stop()}");
            return sb.ToString();
        }
    }
}
