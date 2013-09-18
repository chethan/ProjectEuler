using System.Numerics;
using EulerProblem.Utils;

namespace EulerProblem.Domain
{
    public class Fraction
    {
        public BigInteger Numerator { get; private set; }
        public BigInteger Denominator { get; private set; }

        public Fraction(BigInteger numerator, BigInteger denominator)
        {
            BigInteger gcd = MathUtils.GCD(numerator,denominator);
            Numerator = numerator/gcd;
            Denominator = denominator/gcd;
        }

        public Fraction Add(int number)
        {
            return new Fraction(Numerator + Denominator*number,Denominator);
        }

        public Fraction Add(Fraction number)
        {
            return new Fraction(Numerator * number.Denominator + number.Numerator*Denominator,Denominator * number.Denominator);
        }

        public Fraction Reciprocal()
        {
            return new Fraction(Denominator,Numerator);
        }

        public bool Equals(Fraction other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return other.Numerator == Numerator && other.Denominator == Denominator;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (Fraction)) return false;
            return Equals((Fraction) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Numerator.GetHashCode()*397) ^ Denominator.GetHashCode();
            }
        }

        public override string ToString()
        {
            return string.Format("Numerator: {0}, Denominator: {1}", Numerator, Denominator);
        }
    }
}