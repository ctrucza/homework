using System.Collections.Generic;
using System.Linq;

namespace PrimeFactorsKata
{
    public class Number
    {
        private readonly int value;

        private const int FirstPrimeNumber = 2;

        public Number(int value)
        {
            this.value = value;
        }

        public IEnumerable<int> GetFactors()
        {
            Number dividend = new Number(value);
            Number divisor = new Number(FirstPrimeNumber);

            return PerformFactorization(dividend, divisor).Select(ToInteger);
        }

        private static IEnumerable<Number> PerformFactorization(Number dividend, Number divisor)
        {
            while (dividend.CanBeFactorized())
            {
                while (dividend.IsDivisibleWith(divisor))
                {
                    dividend = dividend.DivideBy(divisor);
                    yield return divisor;
                }

                divisor = divisor.Next();
            }
        } 

        private bool CanBeFactorized()
        {
            return value > 1;
        }

        private bool IsDivisibleWith(Number number)
        {
            return value % number.value == 0;
        }

        private Number DivideBy(Number divisor)
        {
            var result = value / divisor.value;
            return new Number(result);
        }

        private Number Next()
        {
            return new Number(value + 1);
        }

        private static int ToInteger(Number number)
        {
            return number.value;
        }
    }
}
