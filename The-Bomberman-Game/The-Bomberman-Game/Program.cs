using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Bomberman_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 3;
            List<string> grid = new List<string> {  ".......",
                                                    "...O...",
                                                    "....O..",
                                                    ".......",
                                                    "OO.....",
                                                    "OO....."};
            var timeDetonationGrid = ConvertToTimeDetonationGrid(grid, n);
            PrintGrid(timeDetonationGrid);
        }
        public static List<string> ConvertToTimeDetonationGrid(List<string> grid, int n)
        {
            List<string> timeDetonationGrid = grid;
            var bombLocations = new List<Tuple<int, int>>();
            for (int h = 1; h <= n; h++)
            {
                bombLocations.Clear();
                if (h % 2 == 0)
                {
                    for (int i = 0; i < timeDetonationGrid.Count; i++)
                    {
                        string tempString = "";
                        foreach (char c in timeDetonationGrid[i])
                        {
                            if (c == '.')
                            {
                                tempString += "0";
                            }
                            else
                            {
                                tempString += c;
                            }
                        }
                        timeDetonationGrid[i] = tempString;
                    }
                }
                for (int j = 0; j < timeDetonationGrid.Count; j++)
                {
                    int i = 0;
                    string tempString = "";
                    foreach (char c in timeDetonationGrid[j])
                    {
                        if (c == '2')
                        {
                            tempString += '.';
                            bombLocations.Add(Tuple.Create(i, j));
                        }
                        else if (c == '1')
                        {
                            tempString += '2';
                        }
                        else if (c == '0' || c == 'O')
                        {
                            tempString += '1';
                        }
                        else
                        {
                            tempString += c;
                        }
                        i++;
                    }
                    timeDetonationGrid[j] = tempString;
                }
                foreach (var bomb in bombLocations)
                {
                    StringBuilder sb = new StringBuilder(timeDetonationGrid[bomb.Item2]);
                    sb[bomb.Item1] = '.';
                    timeDetonationGrid[bomb.Item2] = sb.ToString();

                    if (bomb.Item1 < timeDetonationGrid[bomb.Item2].Count() - 1)//Explode right
                    {
                        sb = new StringBuilder(timeDetonationGrid[bomb.Item2]);
                        sb[bomb.Item1 + 1] = '.';
                        timeDetonationGrid[bomb.Item2] = sb.ToString();
                    }
                    if (bomb.Item2 < timeDetonationGrid.Count() - 1)//Explode bottom
                    {
                        sb = new StringBuilder(timeDetonationGrid[bomb.Item2 + 1]);
                        sb[bomb.Item1] = '.';
                        timeDetonationGrid[bomb.Item2 + 1] = sb.ToString();
                    }
                    if (bomb.Item1 > 0)
                    {
                        sb = new StringBuilder(timeDetonationGrid[bomb.Item2]);//Explode left
                        sb[bomb.Item1 - 1] = '.';
                        timeDetonationGrid[bomb.Item2] = sb.ToString();
                    }
                    if (bomb.Item2 > 0)
                    {
                        sb = new StringBuilder(timeDetonationGrid[bomb.Item2 - 1]);//Explode top
                        sb[bomb.Item1] = '.';
                        timeDetonationGrid[bomb.Item2 - 1] = sb.ToString();
                    }
                }

            }
            return timeDetonationGrid;
        }
        public static void PrintGrid(List<string> grid)
        {
            for (int j = 0; j < grid.Count; j++)
            {
                int i = 0;
                foreach (char c in grid[j])
                {

                    if (c != '.')
                    {
                        Console.Write("O");
                    }
                    else
                    {
                        Console.Write(".");
                    }
                    i++;
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }


    }
}
