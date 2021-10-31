using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Circle : IDrawable
    {
        private int radius;

        public Circle(int radius)
        {
            this.radius = radius;
        }
        public void Draw()
        {
            double @in = radius - 0.4;
            double @out = radius + 0.4;
            for (double i = radius; i >= -radius; --i)
            {
                for (double j = -radius; j < @out; j += 0.5)
                {
                    double value = j * j + i * i;
                    if (value >= @in * @in && value <= @out * @out)
                    {
                        Console.Write('*');
                    }
                    else
                    {
                        Console.Write(' ');
                    }
                }

                Console.WriteLine();
            }
        }
    }
}
