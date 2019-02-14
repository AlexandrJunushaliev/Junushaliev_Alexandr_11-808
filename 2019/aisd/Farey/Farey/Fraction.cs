using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farey
{
    class Fraction
    {
        int numerator;
        int denominator;
        public Fraction(int numerator,int denominator)
        {
            this.numerator = numerator;
            this.denominator = denominator;
        }
        public int Numerator { get { return numerator; } }
        public int Denominator { get { return denominator; } }
        public override string ToString()
        {
            return (numerator+" / "+denominator);
        }

    }
}
