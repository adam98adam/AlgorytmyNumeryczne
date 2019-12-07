using System;
using System.Collections.Generic;
using System.Text;

namespace GaussFloat
{
    class GaussMath
    {
        public static int N = 10;
        public float[,] AB = new float[N, N + 1];
        public float[] X = new float[N];

        public static void fillAB(float[,] numbersA, float[] numbersB,float[,] AB)
        {
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N + 1; j++)
                {
                    if (j == N)
                        AB[i, j] = numbersB[i];
                    else
                        AB[i, j] = numbersA[i, j];

                }
            }

        }

        public void gaussElimination(float[,] AB, float[] X, float[,] numbersA, float[] numbersB)
        {
            fillAB(numbersA, numbersB,AB);
            for (int i = 0; i < N - 1; i++)
            {
                for (int j = i + 1; j < N; j++)
                {
                    float m = AB[j, i] / AB[i, i];
                    for (int k = i; k <= N; k++)
                    {
                        AB[j, k] -= (m * AB[i, k]);


                    }
                }
            }
            backSubstitution(AB, X);
        }

        public void gaussEliminationPartialPivot(float[,] AB, float[] X, float[,] numbersA, float[] numbersB)
        {
            fillAB(numbersA, numbersB, AB);
            for (int i = 0; i < N - 1; i++)
            {
                int row = i;
                float e = (float)Math.Abs(AB[i, i]);
                for (int j = i + 1; j < N; j++)
                    if ((float)Math.Abs(AB[j, i]) > e)
                    {
                        e = (float)Math.Abs(AB[j, i]);
                        row = j;
                    }
                if (row != i)
                    swapRows(row, i, AB);

                for (int j = i + 1; j < N; j++)
                {
                    float m = AB[j, i] / AB[i, i];
                    for (int k = i; k <= N; k++)
                    {
                        AB[j, k] -= (m * AB[i, k]);

                    }
                }
            }
            backSubstitution(AB, X);
        }

        public void gaussEliminationFullPivot(float[,] AB, float[] X, float[,] numbersA, float[] numbersB)
        {
            int[] Q = new int[N];
            for (int i = 0; i < N; i++)
                Q[i] = i + 1;

            fillAB(numbersA, numbersB, AB);
            for (int i = 0; i < N - 1; i++)
            {
                int row = i;
                int col = i;
                float e = (float)Math.Abs(AB[i, i]);
                for (int k = i; k < N; k++)
                {
                    for (int j = i; j < N; j++)
                    {
                        if ((float)Math.Abs(AB[k, j]) > e)
                        {
                            e = (float)Math.Abs(AB[k, j]);
                            row = k;
                            col = j;
                        }
                    }
                }
                    
                if(row != i && col != i)
                {
                    swapRows(row, i, AB);
                    swapColumns(col, i, AB);
                    swapE(col, i, Q);
                    
                }

                if(row != i && col == i)
                    swapRows(row, i, AB);

                if (col != i && row == i)
                {
                    swapColumns(col, i, AB);
                    swapE(col, i, Q);
                }

                for (int j = i + 1; j < N; j++)
                {
                    float m = AB[j, i] / AB[i, i];
                    for (int k = i; k <= N; k++)
                    {
                        AB[j, k] -= (m * AB[i, k]);

                    }
                }
            }
            backSubstitution(AB, X);

            var myList = new List<KeyValuePair<int, float>>();
            for(int a = 0; a < N; a++)
            {
                myList.Add(new KeyValuePair<int, float>(Q[a], X[a]));
            }

            myList.Sort((x, y) => (x.Key.CompareTo(y.Key)));
            int b = 0;
            foreach (var val in myList)
            {
                X[b] = val.Value;
                b++;
            }

        }





        // wyliczanie niewiadomych
        public static void backSubstitution(float[,] AB,float[] X) { 
                for (int i = N - 1; i >= 0; i--)
                {
                    float s = AB[i,N];
                    for (int j = N - 1; j >= i + 1; j--)
                        s -= AB[i,j] * X[j];
                    X[i] = s / AB[i,i];
                }
            }
            
        public static void swapRows(int row,int i,float[,] AB)
        {
            for (int k = 0; k <= N; k++)
            {
                float temp = AB[i, k];
                AB[i, k] = AB[row, k];
                AB[row, k] = temp;
            }
        }

        public static void swapColumns(int col,int i,float[,] AB)
        {
            for(int k = 0; k < N; k++)
            {
                float temp = AB[k, i];
                AB[k, i] = AB[k, col];
                AB[k, col] = temp;
            }
        }

        public static void swapE(int col,int i,int[] Q)
        {
            int a = Q[i];
            Q[i] = Q[col];
            Q[col] = a;

        }



    }

}
    


        
        
    





