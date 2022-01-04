using System;
using System.Collections.Generic;
using System.Threading;

namespace SnakeOOP
{
    class Program
    {
        static void Main(string[] args)
        {
            Point p1 = new Point(10, 10, '*');           
            Point p2 = new Point(11, 10, '*');
            HorizontalLine hLine = new HorizontalLine(10, 15, 5, '*');
           //hLine.Draw();
            VeticalLine vLine = new VeticalLine(6, 16, 10, '@');
           //vLine.Draw();
            HorizontalLine top = new HorizontalLine(0, 80, 0, '#');
            top.Draw();
            VeticalLine left = new VeticalLine(0, 25, 0, '#');
            left.Draw();
            HorizontalLine bottom = new HorizontalLine(0, 80, 25, '$');
            bottom.Draw();
            VeticalLine right = new VeticalLine(0, 25, 80, '$');
            right.Draw();
            Point snakeTail = new Point(15, 15, 's');
            Snake snake = new Snake(snakeTail, 5, Direction.RIGHT);
            snake.Draw();
            snake.Move();
            FoodGenerator foodGenerator = new FoodGenerator(80, 25, '$');
            Point food = foodGenerator.GenerateFood();
            food.Draw();
            while (true)
            {
                if (snake.Eat(food))
                {
                    food = foodGenerator.GenerateFood();
                    food.Draw();
                }
                else
                {
                    snake.Move();
                }
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    snake.HandleKeys(key.Key);
                }
                Thread.Sleep(300);
                //snake.Move();
            }
 
            Console.Read();
        }       
    }
}
