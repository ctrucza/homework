using System;
using System.Collections.Generic;

namespace PrimeFactors.Smelliest
{
    // Generic comment:
    // consider passing parameters instead of members.
    // In this particular case would help readability a lot.

    // REVIEW: name. -er classes are smelly. 
    // See also the only public method Factorize.
    // Factorizer.Factorize. 
    public class Factorizer
    {
        public IEnumerable<int> Factorize(int number)
        {
            inputNumber = number;
            factors = new List<int>();

            PerformFactorization();
            return factors;
        }

        private void PerformFactorization()
        {
            InitFactorization();

            while (ThereAreCandidateDivisors())
            {
                // Naming. Handle is not a verb.
                HandleCandidateDivisor();
                NextCandidateDivisor();
            }

            // Naming. Handle is not a verb.
            HandlePrimeNumber();
        }

        // how about a constructor?
        private void InitFactorization()
        {
            dividend = inputNumber;
            candidateDivisor = FirstPrimeNumber;
        }

        private bool ThereAreCandidateDivisors()
        {
            // Name: what is a dominant?
            return candidateDivisor <= GetDominantOfLargestProperDivisor();
        }

        private int GetDominantOfLargestProperDivisor()
        {
            // Ok, now your are getting annoying.
            return (int) GetSquareRootOfDividend();
        }

        private double GetSquareRootOfDividend()
        {
            return Math.Sqrt(dividend);
        }

        private void HandleCandidateDivisor()
        {
            while (IsCandidateDivisorAFactor())
            {
                // WTF???
                PerformDivision();
                SaveCandidateDivisorAsFactor();
            }
        }

        private bool IsCandidateDivisorAFactor()
        {
            return dividend % candidateDivisor == 0;
        }

        private void PerformDivision()
        {
            dividend = dividend / candidateDivisor;
        }

        private void SaveCandidateDivisorAsFactor()
        {
            // Man in the middle
            SaveFactor(candidateDivisor);
        }

        private void SaveFactor(int factor)
        {
            factors.Add(factor);
        }

        // man in the middle
        private void NextCandidateDivisor()
        {
            candidateDivisor++;
        }

        private void HandlePrimeNumber()
        {
            if (dividend > 1)
            {
                SaveFactor(dividend);
            }
        }

        // declare members as close to usage as possible
        // or at least on the top. helps reading the code.
        // (like when you first encounter candidateDivisor in a method
        // it's confusing: what is this? 
        private int inputNumber;

        private int dividend;

        private int candidateDivisor;

        private List<int> factors;

        private const int FirstPrimeNumber = 2;
    }
}
