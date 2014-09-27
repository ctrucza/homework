using System.Linq;
using NUnit.Framework;

namespace PrimeFactors
{
	/// <summary>
	/// Note that these are not actual unit tests - each test case runs against different units.
	/// Different units -> different implementations of the factorization algorithm.
	/// </summary>
    [TestFixture]
    public class PrimeFactorsFixture
    {  
        [Test]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(11)]
        [TestCase(41)]
        [TestCase(83)]
        public void CanGenerateForPrimeNumbers(int number)
        {
			Assert.AreEqual(number, Simplest.PrimeFactors1.Generate(number).Single());
			Assert.AreEqual(number, Simplest.PrimeFactors2.Generate(number).Single());
			Assert.AreEqual(number, Simplest.PrimeFactors3.Generate(number).Single());
			Assert.AreEqual(number, Smelliest.PrimeFactors.Generate(number).Single());
            Assert.AreEqual(number, PrettyDecent.PrimeFactors.Generate(number).Single());
        }

        [Test]
        [TestCase(4, new[] {2, 2})]
        [TestCase(6, new[] {2, 3})]
        [TestCase(10, new[] {2, 5})]
        [TestCase(64, new[] { 2, 2, 2, 2, 2, 2 })]
        [TestCase(100, new[] {2, 2, 5, 5})]
        [TestCase(1001, new[] {7, 11, 13})]
        public void CanGeneratePrimeFactors(int number, int[] expectedFactors)
        {
			CollectionAssert.AreEqual(expectedFactors, Simplest.PrimeFactors1.Generate(number));
			CollectionAssert.AreEqual(expectedFactors, Simplest.PrimeFactors2.Generate(number));
			CollectionAssert.AreEqual(expectedFactors, Simplest.PrimeFactors3.Generate(number));
			CollectionAssert.AreEqual(expectedFactors, Smelliest.PrimeFactors.Generate(number));
            CollectionAssert.AreEqual(expectedFactors, PrettyDecent.PrimeFactors.Generate(number));
        }
    }
}
