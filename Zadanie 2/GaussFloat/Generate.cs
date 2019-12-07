using System;
using System.Text;
using System.Numerics;

namespace GaussFloat
{
    class Generate
    {
        public static int N = 10;
        public float[,] numbersA = new float[N, N];
        public float[] numbersX = new float[N];
        int minRandom = (int)(Math.Pow(2, 16) * -1);
        int maxRandom = (int)(Math.Pow(2, 16) - 1);
        int divaider = (int)(Math.Pow(2, 16));

        public void generateA()
        {

            Random rnd = new Random();
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    numbersA[i, j] = (float)rnd.Next(minRandom, maxRandom) / (float)divaider;

                }
            }
        }

        public void generateX()
        {

            Random rnd = new Random();
            for (int i = 0; i < N; i++)
            {
                numbersX[i] = (float)rnd.Next(minRandom, maxRandom) / (float)divaider;

            }

        }
    }
}






