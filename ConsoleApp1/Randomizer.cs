using System;
using System.Drawing;

namespace ConsoleApp1
{
    class Randomizer
    {
        private Random r;

        public Randomizer()
        {
            r = new Random();
        }

        public int GetRandomOffsetPositive(int maxval)
        {
            int genInteger = r.Next(0, maxval);

            return genInteger;
        }

        public int GetRandomOffsetRanged(int maxval)
        {
            int genInteger = r.Next(-1 * maxval, maxval);

            return genInteger;
        }

        public Color GetRandomColor()
        {
            int genR = r.Next(0, 255);
            int genG = r.Next(0, 255);
            int genB = r.Next(0, 255);
            Color col = Color.FromArgb(genR, genG, genB);

            return col;
        }
    }
}
