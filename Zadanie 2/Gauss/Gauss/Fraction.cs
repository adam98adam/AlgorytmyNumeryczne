using System;
using System.Numerics;
using System.Collections.Generic;
using System.Text;

namespace Gauss
{
    [Serializable]
    class Fraction
    {
        public BigInteger Numerator { get; set; }
        public BigInteger Denominator { get; set; }

        public Fraction()
        {
            Numerator = new BigInteger(0);
            Denominator = new BigInteger(1);
        }

        public Fraction(BigInteger numerator, BigInteger denominator)
        {
            Numerator = numerator;
            Denominator = denominator;
            Simplify();
        }

        public Fraction(int numerator, int denominator)
        {
            Numerator = new BigInteger(numerator);
            Denominator = new BigInteger(denominator);
            Simplify();
        }

        private void Simplify()
        {
            if (Denominator.Sign < 0)
            {
                Numerator = -Numerator;
                Denominator = -Denominator;
            }
            BigInteger gcd = BigInteger.GreatestCommonDivisor(Numerator, Denominator);
            Numerator /= gcd;
            Denominator /= gcd;
        }
        
        public static Fraction operator *(Fraction left, Fraction right)
        {
            return new Fraction(
                left.Numerator * right.Numerator,
                left.Denominator * right.Denominator
                );
        }
            
        public static Fraction operator /(Fraction left, Fraction right)
        {
            return new Fraction(
                left.Numerator * right.Denominator,
                left.Denominator * right.Numerator
                );
        }
        
        public static Fraction operator +(Fraction left, Fraction right)
        {
            BigInteger gcd = BigInteger.GreatestCommonDivisor(left.Denominator, right.Denominator);
            BigInteger numerator =
                left.Numerator * (right.Denominator / gcd) + right.Numerator * (left.Denominator / gcd);
            BigInteger denominator =
                left.Denominator * (right.Denominator / gcd);
            return new Fraction(numerator, denominator);
        }

        public static explicit operator double(Fraction x)
        {
            return (double)x.Numerator / (double)x.Denominator;
        }
        


        public override string ToString()
        {
            return Numerator + "/" + Denominator;
        }
    }
}
