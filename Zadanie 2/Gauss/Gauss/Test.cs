using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace Gauss
{

        public class Test<T> where T : new()
        {

            public Test() { }

            public void Execute(Choice choice, GaussMath<T> AB, GaussMath<T> X)
            {
                GaussMath<T> Matrix = AB;
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                Matrix.EliminateGaussian(choice);
                Matrix.BackwardsOperation();
                stopwatch.Stop();

                File.WriteAllText(
                    $@"C:\Programy\Algorytmy Numeryczne\Gauss\Matrices\Results\{typeof(T)}_{choice}_{Matrix.RowCount}x{Matrix.RowCount}.txt",

                    "\n" + stopwatch.Elapsed +
                             "\n" + X.Difference(Matrix)
                    );
                Console.WriteLine($"Finished executing test [{typeof(T)} | {choice}] " +
                                  $"Time: {stopwatch.Elapsed}\n" +
                                  $"Diff: \n{X.Difference(Matrix)}");
            }
        }
}
