using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Circle : Shape
    {
        public Circle(double radius)
        {
            Radius = radius;
        }

        public double Radius { get; protected set; } 

        public override double CalculatePerimeter()
            => 2 * Radius * Math.PI;

        public override double CalculateArea()
            =>Math.Pow(Radius, 2) * Math.PI;

        public override string Draw()
            => base.Draw() + GetType().Name;
    }
}
