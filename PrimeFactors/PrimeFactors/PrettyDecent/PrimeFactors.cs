using System.Collections.Generic;
using System.Linq;

namespace PrimeFactors.PrettyDecent
{
    public class PrimeFactors
    {
        public static List<int> Generate(int number)
        {
            return PerformGenerate(number).Select(Number.ToInteger).ToList();
        }

        const int FirstPrimeNumber = 2;

        static IEnumerable<Number> PerformGenerate(int number) {
            Number dividend = new Number (number);
            Number divisor = new Number (FirstPrimeNumber);
            
            while (dividend.CanBeFactorized()) {
                while (dividend.IsDivisibleWith(divisor)) {
                    dividend = dividend.DivideBy (divisor);
                    yield return divisor;
                }
                
                divisor = divisor.Increment ();
            }
        }
    }
}

