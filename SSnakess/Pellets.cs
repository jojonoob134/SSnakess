using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSnakess
{
    internal class Pellets
    {
        public int X { get; }
        public int Y { get; }

        public void Draw()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write('*');
        }
    }
}
