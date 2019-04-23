using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayManipulations.Sort
{
    /// <summary>
    /// SortingByLengthDescendingComparator with implementation of IComparator interface
    /// </summary>
    public class SortingByLengthDescendingComparator : IComparer
    {
        /// <summary>
        /// Method compares length two strings
        /// </summary>
        /// <param name="first">first string</param>
        /// <param name="second">second string</param>
        /// <returns>integer value</returns>
        public int Compare(string first, string second)
        {
            if (first.Length == second.Length)
            {
                return 0;
            }

            return first.Length > second.Length ? -1 : 1;
        }
    }
}
