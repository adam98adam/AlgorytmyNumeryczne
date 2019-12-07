using System;
using System.Collections.Generic;
using System.Text;

namespace GaussFloat
{
    class PrintMatrix
    {
        public static int N = 10;
        public void printA(float[,] numbersA)
        {
            Console.WriteLine("A Matrix : ");
            Console.WriteLine();
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    Console.Write(numbersA[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }


        public void printXB(float[] numbersXB,Boolean xb)
        {
            Console.WriteLine();
            if(xb == true)
                Console.WriteLine("X Matrix : ");
            else
                Console.WriteLine("B Matrix : ");
            Console.WriteLine();
            for (int i = 0; i < N; i++)
            {
                Console.WriteLine(numbersXB[i]);
            }

        }

        public void printAB(float[,] numbersAB)
        {
            Console.WriteLine();
            Console.WriteLine("AB Matrix : ");
            Console.WriteLine();
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N + 1; j++)
                {
                    if (j == N)
                    {
                        Console.WriteLine("|" + numbersAB[i, j] + "\t");
                    }
                    else
                        Console.Write(numbersAB[i, j] + "\t");

                }


            }
        }
    }
}

    
