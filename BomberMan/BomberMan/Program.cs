using System;

namespace BomberMan
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 4;
            string[] grid = new string[] { "...", 
                                           ".O.", 
                                           "..." };

            string[] grid2 = new string[] {".......",
                                          "...O...",
                                          "....O..",
                                          ".......",
                                          "OO.....",
                                          "OO....."};

            GetFinalState(grid, n);
            GetFinalState(grid2, n);
        }

        static void GetFinalState(string[] grid,int n)
        {
            int i;
            Console.WriteLine("\nInput:" );
            DisplayGrid(grid);
            int timer = 1;
            string[] currentGrid = grid;
            string[] initialGrid = grid;
            string[] tempgrid = new string[grid.Length];

            int counter = 1;
            for(timer = 1; timer<= n;timer++)
            {
                if (counter == 2)
                {
                    Array.Copy(initialGrid, tempgrid,initialGrid.Length);
                    currentGrid = AddAllBomb(initialGrid);
                    counter++;
                }
                else if (counter == 3)
                {
                    currentGrid = ExplodeBombs(tempgrid);
                    initialGrid = currentGrid;
                    counter = 1;
                }
                else
                {
                    counter++;
                }
            }
            Console.WriteLine("\nOutput:");
            DisplayGrid(currentGrid);
            
        }

        static string[] ExplodeBombs(string[] grid)
        {
            int i, j;
            string[] tempgrid = new string[grid.Length];
            Array.Copy(grid, tempgrid, grid.Length);
            AddAllBomb(tempgrid);
            for (i = 0; i < grid.Length; i++)
            {
                for (j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] == 'O')
                    {
                        ExplodeBomb(i, j, tempgrid);
                    } 
                }
            }
            return tempgrid;
        }

        static string[] AddAllBomb(string[] grid)
        {
            int i;
            for (i = 0; i < grid.Length; i++)
            {
                grid[i] = grid[i].Replace(".", "O");
            }
            return grid;
        }

        static void DisplayGrid(string[] grid)
        {
            int i;
            for (i = 0; i < grid.Length; i++)
            {
                Console.WriteLine(grid[i]);
            }
        }

        static void ExplodeBomb(int i, int j,string[] grid)
        {
           
            grid[i] = ReplaceAt(j, grid[i]);

            if (i > 0)
            {
                grid[i - 1] = ReplaceAt(j, grid[i - 1]);
            }
            if (i < (grid.Length - 1))
            {
                grid[i + 1] = ReplaceAt(j, grid[i + 1]);
            }
            if (j > 0)
            {
                grid[i] = ReplaceAt(j - 1, grid[i]);
            }
            if (j < (grid[i].Length - 1))
            {
                grid[i] = ReplaceAt(j + 1, grid[i]);

            }
        }

        static string ReplaceAt(int i, string str)
        {
            char[] chars = str.ToCharArray();
            chars[i] = '.';
            str = new string(chars);
            return str;
        }
    }
}
