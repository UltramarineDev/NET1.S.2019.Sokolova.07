using System;
using System.Collections.Generic;

namespace ArrayManipulations
{
    /// <summary>
    /// Interface represent method FilterByCondition
    /// </summary>
    public interface IFilter
    {
        int[] FilterByCondition(int[] array);
    }

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
        public static int[] Filter(this int[] array, IFilter filter)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array), "Source array can not be null.");
            }

            if (array.Length == 0)
            {
                throw new ArgumentException("Source array can not be empty.", nameof(array));
            }

            return filter.FilterByCondition(array);
        }
    }

    /// <summary>
    /// Class FilterArrayByKey with implementation of IFilter interface
    /// </summary>
    public class FilterArrayByKey : IFilter
    {
        /// <summary>
        /// Initializes a new instance of the FilterArrayByKey class
        /// </summary>
        /// <exception cref="ArgumentException">Thrown if key value in invalid</exception>     
        public FilterArrayByKey(int key)
        {
            if (key > 9 || key < 0)
            {
                throw new ArgumentException(" Input number is not a digit.", nameof(key));
            }

            this.Key = key;
        }

        /// <summary>
        /// Gets or sets the value of key
        /// </summary>
        public int Key { get; set; }

        /// <summary>
        /// Method creates new array with numbers that contain key 
        /// </summary>
        /// <param name="array">input array if integers</param>
        /// <returns>array of integers</returns>
        public int[] FilterByCondition(int[] array)
        {
            List<int> resultValuesList = new List<int>();

            for (int i = 0; i < array.Length; i++)
            {
                if (this.IsDigitInNumber(array[i], this.Key) == true)
                {
                    resultValuesList.Add(array[i]);
                }
            }

            return resultValuesList.ToArray();
        }

        private bool IsDigitInNumber(int number, int key)
        {
            while (number != 0)
            {
                if (Math.Abs(number % 10) == key)
                {
                    return true;
                }

                number = number / 10;
            }

            return false;
        }
    }

    /// <summary>
    /// Class EvenOrOdd with implementation of IFilter interface
    /// </summary>
    public class EvenOrOdd : IFilter
    {
        /// <summary>
        /// Method creates new array with even numbers
        /// </summary>
        /// <param name="array">input array of integers</param>
        /// <returns>array of integers</returns>
        public int[] FilterByCondition(int[] array)
        {
            List<int> resultValuesList = new List<int>();

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 == 0)
                {
                    resultValuesList.Add(array[i]);
                }
            }

            return resultValuesList.ToArray();
        }
    }

    /// <summary>
    /// Class Palindrome with implementation of IFilter interface
    /// </summary>
    public class Palindrome : IFilter
    {
        /// <summary>
        /// Method creates new array with palindromes
        /// </summary>
        /// <param name="array">input array of itegers</param>
        /// <returns>array of integers</returns>
        public int[] FilterByCondition(int[] array)
        {
            List<int> resultValuesList = new List<int>();

            for (int i = 0; i < array.Length; i++)
            {
                if (this.IsPalindrome(array[i]) == true)
                {
                    resultValuesList.Add(array[i]);
                }
            }

            return resultValuesList.ToArray();
        }

        private bool IsPalindrome(int number)
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
