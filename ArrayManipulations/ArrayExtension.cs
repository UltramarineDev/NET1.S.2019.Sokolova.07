using ArrayManipulations.Interfaces;
using System;
using System.Collections.Generic;

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

            bool swapped = true;
            while (swapped)
            {
                swapped = false;

                int i = 0;
                while (i < array.Length - 1)
                {
                    if (comparator.Compare(array[i], array[i + 1]) > 0)
                    {
                        string temp = array[i];
                        array[i] = array[i + 1];
                        array[i + 1] = temp;
                        swapped = true;
                    }

                    i++;
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

        /// <summary>
        /// Method sort jagged array
        /// </summary>
        /// <param name="array">input array</param>
        /// <param name="comparer">parameter of type IIntComparer</param>
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
}
