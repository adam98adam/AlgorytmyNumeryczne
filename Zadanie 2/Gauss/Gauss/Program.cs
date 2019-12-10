using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Gauss
{

        class Program
        {

        //Testing simple operations on matrices :)
        private static void TestGauss()
            {
                Fraction[,] numbersA = {
            {new Fraction(1, 1),
                new Fraction(1,1),
                    new Fraction(1,1)},
            {new Fraction(2, 1),
                new Fraction(-3, 1),
                    new Fraction(4,1)},
            {new Fraction(3,1),
                new Fraction(4,1),
                new Fraction(5, 1)}
        };

                Fraction[,] numbersX = {
            {new Fraction(1, 1)},
            {new Fraction(3, 1)},
            {new Fraction(5, 1)}
        };

                const int testSize = 3;
                GaussMath<Fraction> testMatrixA = new GaussMath<Fraction>(testSize);
                testMatrixA.Fill(numbersA);
                Console.WriteLine(testMatrixA);

                const int testColumnCount = 1;
                GaussMath<Fraction> testVectorX = new GaussMath<Fraction>(testSize, testColumnCount);
                testVectorX.Fill(numbersX);
                Console.WriteLine(testVectorX);

                GaussMath<Fraction> testVectorB = testMatrixA * testVectorX;
                Console.WriteLine("Multiplied matrix:\n" + testVectorB);

                GaussMath<Fraction> testMatrixAB = GaussMath<Fraction>.Concatenate(testMatrixA, testVectorB);
                Console.WriteLine(testMatrixAB);

                testMatrixAB.EliminateGaussian(Choice.Full);
                testMatrixAB.BackwardsOperation();
                Console.WriteLine("\nEliminated matrix:\n" + testMatrixAB);

                testMatrixAB.ShowVector();
            }

            public static void Main(string[] args)
            {

                //TestGauss();

                ///*
                const int size = 20;

                //Fraction
                var A_MatrixFraction = new GaussMath<Fraction>(size);
                A_MatrixFraction.Fill();
                var X_VectorFraction = new GaussMath<Fraction>(size, 1);
                X_VectorFraction.Fill();

                //Fraction operations
                var B_VectorFraction = A_MatrixFraction * X_VectorFraction;
                var AB_MatrixFraction = GaussMath<Fraction>.Concatenate(A_MatrixFraction, B_VectorFraction);

                //float
                var A_MatrixFloat = new GaussMath<float>(size);
                var X_VectorFloat = new GaussMath<float>(size, 1);

                //double
                var A_MatrixDouble = new GaussMath<double>(size);
                var X_VectorDouble = new GaussMath<double>(size, 1);

                //Fill A
                for (int i = 0; i < A_MatrixFraction.RowCount; i++)
                {
                    for (int j = 0; j < A_MatrixFraction.ColumnCount; j++)
                    {
                        A_MatrixFloat.Data[i, j] = (float)A_MatrixFraction.Data[i, j];
                        A_MatrixDouble.Data[i, j] = (double)A_MatrixFraction.Data[i, j];
                    }
                }
                //Fill X
                for (int i = 0; i < X_VectorFraction.RowCount; i++)
                {
                    for (int j = 0; j < X_VectorFraction.ColumnCount; j++)
                    {
                        X_VectorFloat.Data[i, j] = (float)X_VectorFraction.Data[i, j];
                        X_VectorDouble.Data[i, j] = (double)X_VectorFraction.Data[i, j];
                    }
                }

                //float operations
                var B_VectorFloat = A_MatrixFloat * X_VectorFloat;
                var AB_MatrixFloat = GaussMath<float>.Concatenate(A_MatrixFloat, B_VectorFloat);

                //double operations
                var B_VectorDouble = A_MatrixDouble * X_VectorDouble;
                var AB_MatrixDouble = GaussMath<double>.Concatenate(A_MatrixDouble, B_VectorDouble);

                Test<float> testFloat = new Test<float>();
                Test<double> testDouble = new Test<double>();
                Test<Fraction> testFraction = new Test<Fraction>();

                Parallel.Invoke(

                    () => testFloat.Execute(Choice.None, AB_MatrixFloat, X_VectorFloat),
                    () => testFloat.Execute(Choice.Partial, AB_MatrixFloat, X_VectorFloat),
                    () => testFloat.Execute(Choice.Full, AB_MatrixFloat, X_VectorFloat),

                    () => testDouble.Execute(Choice.None, AB_MatrixDouble, X_VectorDouble),
                    () => testDouble.Execute(Choice.Partial, AB_MatrixDouble, X_VectorDouble),
                    () => testDouble.Execute(Choice.Full, AB_MatrixDouble, X_VectorDouble),

                    () => testFraction.Execute(Choice.None, AB_MatrixFraction, X_VectorFraction),
                    () => testFraction.Execute(Choice.Partial, AB_MatrixFraction, X_VectorFraction),
                    () => testFraction.Execute(Choice.Full, AB_MatrixFraction, X_VectorFraction)
                    );
                //*/
            }
        }
}
