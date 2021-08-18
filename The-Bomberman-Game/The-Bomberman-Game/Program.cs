using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace The_Bomberman_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            int seconds = 3;
            string[][] grid = new string[][]
            {
                new string[] { ".", ".", ".", ".", ".", ".", "." },
                new string[] { ".", ".", ".", "0", ".", ".", "." },
                new string[] { ".", ".", ".", ".", "0", ".", "." },
                new string[] { ".", ".", ".", ".", ".", ".", "." },
                new string[] { "0", "0", ".", ".", ".", ".", "." },
                new string[] { "0", "0", ".", ".", ".", ".", "." },
            };


            //print the grid
            Console.WriteLine("Original Grid");
            printGrid(grid);

            bomberman(grid, seconds);

            static string[][] bomberman(string[][] grid, int seconds)
            {

                var bombsPositions = new List<bombPosition>();

                var xLenght = grid.Length;
                var yLenght = grid[0].Length;
                //second count to know in which step are we
                var count = 1;

                for (int i = 1; i <= seconds; i++)
                {
                    if(count == 1)
                    {
                        //first it finds all the coordinates for all the bombs
                        bombsPositions = findBombsCoordinates(grid);
                        count++;
                    }

                    else if (count == 2)
                    {                        
                        grid = fillTheGrid(grid);
                        count++;
                    }

                    else if (count == 3)
                    {

                        //Bomb Explotion Kaboom!!!
                        foreach(var bomb in bombsPositions)
                        {                            
                            grid[bomb.x][bomb.y] = ".";
                            if (bomb.x - 1 >= 0)
                            {
                                grid[bomb.x - 1][bomb.y] = ".";
                            }

                            if (bomb.x + 1 < xLenght)
                            {
                                grid[bomb.x + 1][bomb.y] = ".";
                            }

                            if (bomb.y - 1 >= 0)
                            {
                                grid[bomb.x][bomb.y - 1] = ".";
                            }

                            if (bomb.y + 1 < yLenght)
                            {
                                grid[bomb.x][bomb.y + 1] = ".";
                            }
                        }

                        Console.WriteLine("Grid After the Explotion");
                        printGrid(grid);
                        //reset the second count to step 1
                        count = 1;
                        
                    }                    
                }
                return grid;
            }
        }

        public static void printGrid(string[][] grid)
        {
            foreach (var x in grid)
            {
                foreach (var y in x)
                {
                    Console.Write(string.Format("{0} ", y));
                }
                Console.WriteLine(" ");
            }
            Console.WriteLine(" ");
        }

            public static List<bombPosition> findBombsCoordinates(string[][] grid)
        {
            var bombsPositions = new List<bombPosition>();

            var x = 0;
            var y = 0;

            foreach (var xAxys in grid)
            {
                y = 0;
                foreach (var yAxis in xAxys)
                {
                    if (yAxis == "0")
                    {
                        bombsPositions.Add(new bombPosition() { x = x, y = y });
                    }
                    y++;
                }
                x++;
            }
            return bombsPositions;
        }

        public static string[][] fillTheGrid(string[][] grid)
        {
            var bombsPositions = new List<bombPosition>();

            var x = 0;
            var y = 0;

            foreach (var xAxys in grid)
            {
                y = 0;
                foreach (var yAxis in xAxys)
                {
                    if (yAxis == ".")
                    {
                        grid[x][y] = "0";
                    }
                    y++;
                }
                x++;
            }
            return grid;
        }
    }

    public class bombPosition
    {
        public int x { get; set; }
        public int y { get; set; }
    }

    
}
