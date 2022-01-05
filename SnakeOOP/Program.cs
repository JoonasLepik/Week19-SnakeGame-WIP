using System;
using System.Collections.Generic;
using System.Threading;

namespace SnakeOOP
{
    class Program
    {
        static void Main(string[] args)
        {
            int score = 0;
            Walls walls = new Walls(80, 25);
            walls.Draw();
            Point snakeTail = new Point(10, 5, 's' );
            Snake snake = new Snake(snakeTail, 3, Direction.DOWN);
            snake.Draw();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            snake.Move();
            FoodGenerator foodGenerator = new FoodGenerator(80, 25, '$');
            Point food = foodGenerator.GenerateFood();
            food.Draw();            
            while (true)
            {
                if (walls.IsHit(snake) || snake.IsHitTail())
                {
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    break;
                }
                if (snake.Eat(food))
                {
                    food = foodGenerator.GenerateFood();
                    food.Draw();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    score++;
                }
                else
                {
                    snake.Move();
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                }
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    snake.HandleKeys(key.Key);
                }
                Thread.Sleep(200);

            }
            string str_score = Convert.ToString(score);
            WriteScore(str_score);
            WriteGameOver(str_score);
            Console.Read();
        }

            

        public static void WriteGameOver(string score) 
        {
            int xOffset = 25;
            int yOffset = 8;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.SetCursorPosition(xOffset, yOffset++);
            WriteText("============================", xOffset, yOffset++);
            WriteText("         GAME OVER      ", xOffset+1, yOffset++);
            yOffset++;
            WriteText($"You scored {score} points", xOffset + 2, yOffset++);
            WriteText("", xOffset+1, yOffset++);
            WriteText("============================", xOffset, yOffset++);
        }

        public static void WriteText(String text, int xOffset, int yOffset)
        {
            Console.SetCursorPosition(xOffset, yOffset);
            Console.WriteLine(text);
        }
        public static void WriteScore(string score)
        {
            int xOffset = 85;
            int yOffset = 0;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(xOffset, yOffset++);
            Console.WriteLine($"Score: {score}", xOffset, yOffset);            
        }
    }
}
