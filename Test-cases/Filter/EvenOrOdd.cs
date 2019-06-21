using ArrayManipulations.Interfaces;

namespace Test_cases.Filter
{
    /// <summary>
    /// Class EvenOrOdd with implementation of IFilter interface
    /// </summary>
    public class EvenOrOdd : IPredicate
    {
        /// <summary>
        /// Method determines if number is even or odd
        /// </summary>
        /// <param name="array">input number</param>
        /// <returns>true if number is even and false - if odd</returns>
        public bool IsPredicate(int number)
        {
            return number % 2 == 0;
        }
    }
}
