using System;
namespace Shapes
{
    public class Rectangle : IDrawable
    {
        private int width;
        private int height;

        public Rectangle(int width, int height)
        {
            this.width = width;
            this.height = height;
        }

        public void Draw()
        {
            DrawLine('*', '*');
            for (int i = 0; i < height - 2; i++)
            {
                DrawLine('*', ' ');
            }
            DrawLine('*', '*');
        }

        private void DrawLine(char outer, char inner)
        {
            Console.Write(outer);
            for (int i = 0; i < width - 2; i++)
            {
                Console.Write(inner);
            }

            Console.Write(outer);
            Console.WriteLine();
        }
    }
}
