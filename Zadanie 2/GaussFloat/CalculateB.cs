using System;
using System.Text;

namespace GaussFloat
{
    class CalculateB
    {
        public static int N = 10;
        public float[] numbersB = new float[N];
        float sum=0;
        float a = 0;
        float b = 0;


        public void calculate(float[,] numbersA, float[] numbersX)
        {
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    a = numbersA[i, j];
                    b = numbersX[j];
                    sum += a * b;

                }
                numbersB[i] = sum;
                sum = 0;
            }
        }
    }
}


