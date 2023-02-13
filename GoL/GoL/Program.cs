using System;

namespace GameOfLife
{
    static class Program
    {
        const int Rows = 25;
        const int Columns = 50;

        public static void Main()
        {
            int[,] arr = new int[Rows, Columns];
            initArr(arr);

            while (true)
            {
                arr = checker(arr);
                Thread.Sleep(500);
            }
        }

        private static int[,] checker(int[,] ar)
        {
            int[,] copy = new int[ar.GetLength(0),ar.GetLength(1)];

            for (int i = 0; i < ar.GetLength(0); i++)
            {
                for (int j = 0; j < ar.GetLength(1); j++)
                {
                    int dead = 0;
                    int alive = 0;

                    for (int x = i-1; x < i+2; x++)
                    {
                        for (int y = j-1; y < j+2; y++)
                        {
                            if (x >= 0 && y >= 0 && x < ar.GetLength(0) && y < ar.GetLength(1))
                            {
                                if (ar[x, y] == 1)
                                {
                                    alive++;
                                }
                                else
                                {
                                    dead++;
                                }
                            }
                        }
                    }
                    if (ar[i,j] == 1)
                    {
                        alive--;
                    }
                    else
                    {
                        dead--;
                    }

                    if (ar[i,j] == 1 && (alive == 2 || alive == 3))
                    {
                        copy[i, j] = 1;
                    }
                    else if (ar[i,j] == 0 && alive == 3)
                    {
                        copy[i, j] = 1;
                    }
                    else
                    {
                        copy[i, j] = 0;
                    }
                }
            }
            print(copy);
            Console.WriteLine("--------------------------------------------------");
            return copy;
        }

        private static void copyArray(int[,] arr1, int[,] arr2)
        {
            for (int i = 0; i < arr1.GetLength(0); i++)
            {
                for (int j = 0; j < arr1.GetLength(1); j++)
                {
                    if (arr1[i, j] == 0)
                        arr2[i, j] = 0;
                    else
                        arr2[i, j] = 1;
                }
            }
        }

        private static void print(int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, j] == 0)
                        Console.Write(".");
                    else
                        Console.Write("*");
                }
                Console.WriteLine();
            }
        }


        private static void initArr(int[,] arrayy)
        {
            Random rnd = new Random();

            for (int i = 0; i < arrayy.GetLength(0); i++)
            {
                for (int j = 0; j < arrayy.GetLength(1); j++)
                {
                    arrayy[i, j] = rnd.Next(0, 2);
                }
            }
            print(arrayy);
        }
    }
}


