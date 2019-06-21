namespace Test_cases.Sort
{
    /// <summary>
    /// SortingByOccurranceDescendingComparator class with implementation of IComparator interface and NumberOfOccurrences class
    /// </summary>
    public class SortingByOccurrenceDescendingComparator : NumberOfOccurrances, IComparer
    {
        /// <summary>
        /// Gets or sets the value of symbol
        /// </summary>
        public char Symbol { get; set; }

        /// <summary>
        /// Initializes a new instance of the SortingByOccurranceComparator class
        /// </summary>
        /// <param name="symbol">input symbol</param>
        public SortingByOccurrenceDescendingComparator(char symbol)
        {
            this.Symbol = symbol;
        }

        /// <summary>
        /// Method compares numbers of occurrences of two strings
        /// </summary>
        /// <param name="first">first string</param>
        /// <param name="second">second string</param>
        /// <returns>integer value</returns>
        public int Compare(string first, string second)
        {
            if (this.FindNumberOfOccurrences(first, this.Symbol) == this.FindNumberOfOccurrences(second, this.Symbol))
            {
                return 0;
            }

            return this.FindNumberOfOccurrences(first, this.Symbol) > this.FindNumberOfOccurrences(second, this.Symbol) ? -1 : 1;
        }
    }
}
