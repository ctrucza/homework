using System.Collections.Generic;

namespace PrimeFactors.Simplest
{
	public class PrimeFactors1
	{
		public static List<int> Generate (int number)
		{
			var factors = new List<int> ();

			for (int divisor = 2; divisor <= number; divisor++) {
				while (number % divisor == 0) {
					number = number / divisor;
					factors.Add (divisor);
				}
			}

			return factors;
		}
	}
}
