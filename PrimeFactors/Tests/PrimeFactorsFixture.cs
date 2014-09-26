using System.Linq;
using NUnit.Framework;

namespace PrimeFactorsKata
{
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
            var factors = PrimeFactors.Generate(number);
            Assert.AreEqual(number, factors.Single());
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
            var factors = PrimeFactors.Generate(number);
            CollectionAssert.AreEqual(expectedFactors, factors);
        }
    }
}
