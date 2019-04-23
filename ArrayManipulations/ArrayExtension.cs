using ArrayManipulations.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace ArrayManipulations
{
    /// <summary>
    /// ArrayExtension class
    /// </summary>
    public static class ArrayExtension
    {
        /// <summary>
        /// Method filters array using condition
        /// </summary>
        /// <param name="array">input array</param>
        /// <param name="filter">instance of IFilter interface</param>
        /// <returns>array with numbers satisfying condition</returns>
        /// <exception cref="System.ArgumentException">Thrown when array is empty</exception>
        /// <exception cref="System.ArgumentNullException">Thrown when array is null</exception>
        public static int[] Filter(this int[] array, IPredicate filter)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array), "Source array can not be null.");
            }

            if (array.Length == 0)
            {
                throw new ArgumentException("Source array can not be empty.", nameof(array));
            }

            List<int> resultList = new List<int>();
            for (int i = 0; i < array.Length; i++)
            {
                if (filter.IsPredicate(array[i]))
                {
                    resultList.Add(array[i]);
                }
            }

            return resultList.ToArray();
        }

        /// <summary>
        /// Method sorts array of strings using condition
        /// </summary>
        /// <param name="array">input array of strings</param>
        /// <param name="comparator">instance of IComparator</param>
        /// <returns>sorted array</returns>
        /// <exception cref="System.ArgumentException">Thrown when array is empty</exception>
        /// <exception cref="System.ArgumentNullException">Thrown when array is null</exception>
        public static string[] Sort(this string[] array, IComparer comparator)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array), "Source array can not be null.");
            }

            if (array.Length == 0)
            {
                throw new ArgumentException("Source array can not be empty.", nameof(array));
            }

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    if (comparator.Compare(array[j], array[j + 1]) > 0)
                    {
                        string temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }

            return array;
        }

        /// <summary>
        /// Method transform double numbers to written equivalent
        /// </summary>
        /// <param name="array">array of doubles</param>
        /// <param name="transformer">parameter of type Transformer</param>
        /// <returns>array of strings</returns>
        public static string[] Transform(this double[] array, ITransformer transformer)
        {
            var resultStringArray = new string[array.Length];

            for (int i = 0; i < array.Length; i++)
            {
                resultStringArray[i] = transformer.TransformDouble(array[i]);
            }

            return resultStringArray;
        }

        public static void JaggedSort(this int[][] array, IIntComparer comparer)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (comparer.Compare(array[i], array[i + 1]) > 0)
                {
                    var temp = array[i];
                    array[i] = array[i];
                    array[i] = temp;
                }
            }
        }
    }

    public abstract class SumOfElements
    {
        protected double Sum(int[] array)
        {
            double sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }

            return sum;
        }
    }

    public class AscendingBySumSorter : SumOfElements, IIntComparer
    {
        public int Compare(int[] first, int[] second)
        {
            if (Sum(first) == Sum(second))
            {
                return 0;
            }

            return Sum(first) > Sum(second) ? 1 : -1;
        }
    }

    public class DescendingBySumSorter : SumOfElements, IIntComparer
    {
        public int Compare(int[] first, int[] second)
        {
            if (Sum(first) == Sum(second))
            {
                return 0;
            }

            return Sum(first) > Sum(second) ? -1 : 1;
        }
    }

    public abstract class MaxMinElement
    {
        public int FindMax(int[] array)
        {
            int max = array[0];
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > max)
                {
                    max = array[i];
                }
            }

            return max;
        }

        public int FindMin(int[] array)
        {
            int min = array[0];
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < min)
                {
                    min = array[i];
                }
            }

            return min;
        }
    }

    public class AscendingByMaxSorter : MaxMinElement, IIntComparer
    {
        public int Compare(int[] first, int[] second)
        {
            if (FindMax(first) == FindMax(second))
            {
                return 0;
            }

            return FindMax(first) > FindMax(second) ? 1 : -1;
        }
    }

    public class DescendingByMaxSorter : MaxMinElement, IIntComparer
    {
        public int Compare(int[] first, int[] second)
        {
            if (FindMax(first) == FindMax(second))
            {
                return 0;
            }

            return FindMax(first) > FindMax(second) ? -1 : 1;
        }
    }

    public class AscendingByMinSorter : MaxMinElement, IIntComparer
    {
        public int Compare(int[] first, int[] second)
        {
            if (FindMin(first) == FindMin(second))
            {
                return 0;
            }

            return FindMin(first) > FindMin(second) ? 1 : -1;
        }
    }

    public class DescendingByMinSorter : MaxMinElement, IIntComparer
    {
        public int Compare(int[] first, int[] second)
        {
            if (FindMin(first) == FindMin(second))
            {
                return 0;
            }

            return FindMin(first) > FindMin(second) ? -1 : 1;
        }
    }

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
