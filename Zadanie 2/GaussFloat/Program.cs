using System;

namespace GaussFloat
{
    class Program
    {
        static void Main(string[] args)
        {
            Generate a = new Generate();
            a.generateA();
            a.generateX();
            CalculateB b = new CalculateB();
            b.calculate(a.numbersA, a.numbersX);
            PrintMatrix p = new PrintMatrix();
            //p.printA(a.numbersA);
            p.printXB(a.numbersX,true);
            //p.printXB(b.numbersB,false);
            GaussMath m = new GaussMath();
           // p.printAB(m.AB);
            m.gaussElimination(m.AB,m.X,a.numbersA,b.numbersB);
           // p.printAB(m.AB);
            p.printXB(m.X, true);
            m.gaussEliminationPartialPivot(m.AB, m.X, a.numbersA, b.numbersB);
            p.printXB(m.X, true);
            m.gaussEliminationFullPivot(m.AB, m.X, a.numbersA, b.numbersB);
            p.printXB(m.X, true);

        }
    }
}
