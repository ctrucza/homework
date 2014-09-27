
namespace PrimeFactors.PrettyDecent
{
	public class Number
	{
		readonly int value;

		public Number (int value)
		{
			this.value = value;
		}

		public bool CanBeFactorized ()
		{
			return value > 1;
		}

		public bool IsDivisibleWith (Number number)
		{
			return value % number.value == 0;
		}

		public Number DivideBy (Number divisor)
		{
			var result = value / divisor.value;
			return new Number (result);
		}

		public Number Increment ()
		{
			return new Number (value + 1);
		}

		public static int ToInteger (Number number)
		{
			return number.value;
		}
	}
}
