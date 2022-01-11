using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeOOP
{
    class Walls
    {
        List<Figure> wallList;
        public Walls(int mapWidth, int mapHeight)
        {
            wallList = new List<Figure>();
            HorizontalLine top = new HorizontalLine(0, 80, 0, '#');
            VeticalLine left = new VeticalLine(0, 25, 0, '#');
            HorizontalLine bottom = new HorizontalLine(0, 80, 25, '%');
            VeticalLine right = new VeticalLine(0, 25, 80, '%');
            VeticalLine obstacle1 = new VeticalLine(9, 17, 55, '%');
            VeticalLine obstacle2 = new VeticalLine(9, 17, 20, '%');
            HorizontalLine horizontalObstacle1 = new HorizontalLine(25, 50, 18, '%');
            HorizontalLine horizontalObstacle2 = new HorizontalLine(25, 50, 8, '%');
            wallList.Add(top);
            wallList.Add(left);
            wallList.Add(bottom);
            wallList.Add(right);
            wallList.Add(obstacle1);
            wallList.Add(obstacle2);
            wallList.Add(horizontalObstacle1);
            wallList.Add(horizontalObstacle2);
        }
        public void Draw()
        {
            foreach(var wall in wallList)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                wall.Draw();
            }
        }
        public bool IsHit(Figure figure)
        {
            foreach(var wall in wallList)
            {
                if (wall.IsHit(figure))
                {
                    return true;
                }
            }
            return false;
        }

    }
}
