namespace Test_cases.JaggedSort
{
    /// <summary>
    /// Abstract class NumberOfOccurrances
    /// </summary>
    public abstract class NumberOfOccurrances
    {
        /// <summary>
        /// Method calculate the number of occurrences
        /// </summary>
        /// <param name="item">input string</param>
        /// <param name="symbol">char symbol</param>
        /// <returns>integer number of occurrences</returns>
        protected int FindNumberOfOccurrences(string item, char symbol)
        {
            int occurranceNumber = 0;

            for (int i = 0; i < item.Length; i++)
            {
                if (item[i] == symbol)
                {
                    occurranceNumber += 1;
                }
            }

            return occurranceNumber;
        }
    }
}
