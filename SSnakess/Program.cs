using SSnakess;
using System;
using System.Threading;
using System.Xml.Linq;

class Program
{
    static void Main(string[] args)
    {


        // Define the dimensions of the game board
        int boardWidth = 80;
        int boardHeight = 30;

        // Create a new game board
        GameBoard gameBoard = new GameBoard(boardWidth, boardHeight);

        // Draw the walls
        gameBoard.DrawWalls();


        // --------------------------------------------------------------

        // Create a new square object
        Square square = new Square(30,15, 5); // starting position (0, 0) and size 5

        // Set initial movement direction
        int hori = 2; // initial horizontal movement (1 for right)
        int vert = 0; // initial vertical movement (0 for no movement)

        // Start a separate thread to continuously move the square
        Thread movementThread = new Thread(() =>
        {
            while (true)
            {
                // Move the square
                square.Move(hori, vert);

                // Sleep for a short time to control the speed of movement
                Thread.Sleep(200);

                if (gameBoard.CheckCollision(square))
                {
                    Console.WriteLine("Game Over - Collision with Wall!");
                    break;
                }

                // Update the position of the square based on user input
            }
        });
        movementThread.Start();

        // Main game loop for reading user input
        while (true)
        {
            // Get user input to control movement direction
            ConsoleKeyInfo keyInfo = Console.ReadKey();

            // Change movement direction based on user input
            switch (keyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                    vert = -1;
                    hori = 0;
                    break;
                case ConsoleKey.DownArrow:
                    vert = 1;
                    hori = 0;
                    break;
                case ConsoleKey.LeftArrow:
                    hori = -2;
                    vert = 0;
                    break;
                case ConsoleKey.RightArrow:
                    hori = 2;
                    vert = 0;
                    break;
            }
        }
    }
}

class Square
{
    public int X { get; private set; }
    public int Y { get; private set; }
    public int Size { get; private set; }

    public Square(int x, int y, int size)
    {
        X = x;
        Y = y;
        Size = size;
    }

    public void Move(int deltaX, int deltaY)
    {
        // Clear the previous position of the square
        Console.SetCursorPosition(X, Y);
        Console.Write("  ");

        // Update the position of the square
        X += deltaX;
        Y += deltaY;

        // Draw the square at its new position
        Console.SetCursorPosition(X, Y);
        Console.Write("██");
    }
    public void UpdatePosition(ConsoleKeyInfo key)
    {
        // Update the position of the square based on user input
        switch (key.Key)
        {
            case ConsoleKey.UpArrow:
                Y--;
                break;
            case ConsoleKey.DownArrow:
                Y++;
                break;
            case ConsoleKey.LeftArrow:
                X--;
                break;
            case ConsoleKey.RightArrow:
                X++;
                break;
        }
    }
}
