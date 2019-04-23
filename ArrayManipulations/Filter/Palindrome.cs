using ArrayManipulations.Interfaces;

namespace ArrayManipulations.Filter
{
    /// <summary>
    /// Class Palindrome with implementation of IFilter interface
    /// </summary>
    public class Palindrome : IPredicate
    {
        /// <summary>
        /// Method determines is number palindrome or not
        /// </summary>
        /// <param name="number">input number</param>
        /// <returns>true if number is palindrome, false - if not</returns>
        public bool IsPredicate(int number)
        {
            string numberInString = number.ToString();
            for (int i = 0, j = numberInString.Length - 1; i < numberInString.Length; i++, j--)
            {
                if (numberInString[i] != numberInString[j])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
