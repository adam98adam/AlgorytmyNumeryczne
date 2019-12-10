using System;
using System.Numerics;
using System.Collections.Generic;
using System.Text;

namespace Gauss
{
    class Absolute
    {

        public static float GetAbs(float num)
        {
            return Math.Abs(num);
        }

        public static double GetAbs(double num)
        {
            return Math.Abs(num);
        }

        public static Fraction GetAbs(Fraction num)
        {
            return new Fraction(BigInteger.Abs(num.Numerator), num.Denominator);
        }
    }
}
        