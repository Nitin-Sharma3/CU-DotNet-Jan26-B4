using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace OopsDemo
{
    class Height
    {
        public int Feet { get; set; }
        private int inch;

        public int Inch
        {
            get { return inch; }
            set {
                if (value > 12)
                {
                    int add = value / 12;
                    inch = value % 12;
                    Feet = Feet + add;
                }
                else
                    inch = value;
            }
        }
        public Height()
        {
            Feet = 0;
            Inch = 0;
        }
        public Height(int feet, int inch)
        {
            this.Feet = feet;
            this.Inch = inch;
        }
        public Height(int inch)
        {
            int add = inch / 12;
            inch = inch % 12;
            Feet = Feet + add;
        }
        public override string ToString()
        {
            return $"Height: {Feet}' and {Inch}\"";
        }
        public Height DisplayAddedHeights(Height h1)
        {
            Height h = new Height();
            h.Feet += h1.Feet+Feet;
            h.Inch += h1.Inch+Inch;
            if (h.Inch > 12)
            {
                int add = h.Inch / 12;
                h.Inch = h.Inch % 12;
                h.Feet += add;
            }
            return h;
        }

    }
    internal class Day15assignment
    {
        static void Main(string[] args)
        {
            Height h1 = new Height(5, 29);
            Height h2 = new Height(4, 11);
            Height h3 = new Height(60);
            Console.WriteLine(h1);
            Console.WriteLine(h2);
            Console.WriteLine(h3);
            Height added= h1.DisplayAddedHeights(h2);
            Console.WriteLine(added);

        }
    }
}
