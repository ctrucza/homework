using System.Collections.Generic;
using System.Linq;

namespace PrimeFactors.Simplest
{
    public class PrimeFactors3
    {
        public static List<int> Generate(int number)
        {
            // Is this a valid case of "middle-man"?
            return PerformGenerate(number).ToList();
        }

        static IEnumerable<int> PerformGenerate(int number)
        {
            int divisor = 2;

            while (number > 1)
            {
                while (number % divisor == 0)
                {
                    number /= divisor;
                    yield return divisor;
                }

                divisor++;
            }
        }
    }
}