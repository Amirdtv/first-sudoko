using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace poe
{
    internal class Program
    {
            static void Main(string[] args)
            {
                int[,] puzel =
                    {
                { 3, 2, 1, 7, 0, 4, 0, 0, 0 },
                { 6, 4, 0, 0, 9, 0, 0, 0, 7 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 4, 5, 9, 0, 0 },
                { 0, 0, 5, 1, 8, 7, 4, 0, 0 },
                { 0, 0, 4, 9, 6, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 2, 0, 0, 0, 7, 0, 0, 1, 9 },
                { 0, 0, 0, 6, 0, 9, 5, 8, 2 }
                };
                if (solve(puzel, 0, 0))
                {
                    drow(puzel);
                }
                 else
                 {
                   Console.WriteLine(" jadval eshtebah");
                 }
                Console.ReadKey();
            }
            private static bool find(int[,] puzel, ref int x, ref int y)
            {
                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        if (puzel[i, j] == 0)
                        {
                            x = i;
                            y = j;
                            return true;
                        }
                    }
                }

                return false;
            }

            private static bool valid(int n, int x, int y, int[,] puzel)
            {
                for (int i = 0; i < 9; i++)
                {
                    if (puzel[x, i] == n || puzel[i, y] == n)
                    {
                        return false;
                    }
                }
                int row = (x / 3) * 3;
                int col = (y / 3) * 3;
                for (int i = row; i < row + 3; i++)
                {
                    for (int j = col; j < col + 3; j++)
                    {
                        if (puzel[i, j] == n)
                        {
                            return false;
                        }
                    }
                }

                return true;
            }
            private static bool solve(int[,] puzel, int x, int y)
            {
                if (!find(puzel, ref x, ref y))
                {
                    return true;
                }
                for (int i = 1; i <= 9; i++)
                {
                    if (valid(i, x, y, puzel))
                    {
                        puzel[x, y] = i;
                        if (solve(puzel, x, y))
                        {
                            return true;
                        }
                        puzel[x, y] = 0;
                    }
                }
                return false;
            }

            private static void drow(int[,] puzel)
            {
                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        Console.Write("|" + puzel[i, j]);
                    }
                    Console.WriteLine("|");
                }
            }
        }
    }
