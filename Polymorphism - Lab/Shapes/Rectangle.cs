using System.Text;

namespace Shapes
{
    public class Rectangle : Shape
    {
        public Rectangle(double height, double width)
        {
            Height = height;
            Width = width;
        }

        public double Height { get; protected set; }
        public double Width { get; protected set; }

        public override double CalculatePerimeter()
            => (Height + Width) * 2;

        public override double CalculateArea()
            => Height * Width;

        public override string Draw()
            => base.Draw() + GetType().Name;
    }
}
