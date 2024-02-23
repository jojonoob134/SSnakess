using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSnakess
{
    internal class GameBoard
    {
        
        private int width;
        private int height;

        public GameBoard(int width, int height)
        {
            this.width = width;
            this.height = height;
        }

        public void DrawWalls()
        {
            // Draw top wall
            DrawHorizontalWall(0);

            // Draw bottom wall
            DrawHorizontalWall(height - 1);

            // Draw left wall
            DrawVerticalWall(0);

            // Draw right wall
            DrawVerticalWall(width - 1);
        }

        private void DrawHorizontalWall(int y)
            {
            Console.SetCursorPosition(0, y);
            Console.Write(new string('#', width));
        }

        private void DrawVerticalWall(int x)
        {
            for (int y = 0; y < height; y++)
            {
                Console.SetCursorPosition(x, y);
                Console.Write('#');
            }
        }

        public bool CheckCollision(Square square)
        {
            // Check collision with top and bottom walls
            if (square.Y <= 0 || square.Y + square.Size - 1 >= height - 1)
                return true;

            // Check collision with left and right walls
            if (square.X <= 0 || square.X + square.Size - 1 >= width - 1)
                return true;

            return false;
        }
    }
}
