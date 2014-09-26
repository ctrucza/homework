using System.Collections.Generic;
using System.Linq;

namespace PrimeFactorsKata
{
    public class PrimeFactors
    {
        public static List<int> Generate(int number)
        {
            // code smell: man in the middle.
            // You could implement the whole shebang in this very class.
            return new Factorizer().Factorize(number).ToList();
        }
    }
}
