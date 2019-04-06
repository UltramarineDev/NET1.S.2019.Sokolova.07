using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace ArrayManipulations
{
    /// <summary>
    /// Interface represent method FilterByCondition
    /// </summary>
    public interface IPredicate
    {
        bool IsPredicate(int number);
    }

    /// <summary>
    /// Interface tepresent method Compare
    /// </summary>
    public interface IComparer
    {
        int Compare(string first, string second);
    }

    public interface ITransformer
    {
       string TransformDouble(double number);
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

        public static void JaggedSort(this int[][] array, )
        {

        }
    }

    /// <summary>
    /// Class FilterArrayByKey with implementation of IFilter interface
    /// </summary>
    public class FilterArrayByKey : IPredicate
    {
        /// <summary>
        /// Initializes a new instance of the FilterArrayByKey class
        /// </summary>
        /// <exception cref="ArgumentException">Thrown if key value in invalid</exception>     
        public FilterArrayByKey(int key)
        {
            Key = key;
        }

        private int key;
        /// <summary>
        /// Gets or sets the value of key
        /// </summary>
        public int Key
        {
            get
            {
                return key;
            }

            set
            {
                if (value > 9 || value < 0)
                {
                    throw new ArgumentException(" Input number is not a digit.", nameof(Key));
                }

                key = value;
            }
        }

        /// <summary>
        /// Method determines if number contains key value or not
        /// </summary>
        /// <param name="number">input number</param>
        /// <returns>true if number contains key, false - if not</returns>
        public bool IsPredicate(int number)
        {
            while (number != 0)
            {
                if (Math.Abs(number % 10) == Key)
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

    /// <summary>
    /// Class SortingByLengthComparator with implementation of IComparator interface
    /// </summary>
    public class SortingByLengthComparator : IComparer
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

            return first.Length > second.Length ? 1 : -1;
        }
    }

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

    /// <summary>
    /// SortingByOccurrenceComparator class with implementation of IComparator interface and NumberOfOccurrences class
    /// </summary>
    public class SortingByOccurrenceComparator : NumberOfOccurrances, IComparer
    {
        /// <summary>
        /// Initializes a new instance of the SortingByOccurrenceComparator class
        /// </summary>
        /// <param name="symbol">input symbol</param>
        public SortingByOccurrenceComparator(char symbol)
        {
            this.Symbol = symbol;
        }

        /// <summary>
        /// Gets or sets the value of symbol
        /// </summary>
        public char Symbol { get; set; }

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

            return this.FindNumberOfOccurrences(first, this.Symbol) > this.FindNumberOfOccurrences(second, this.Symbol) ? 1 : -1;
        }
    }

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

    /// <summary>
    /// abstract class Transformer
    /// </summary>
    public abstract class Transformer : ITransformer
    {
        /// <summary>
        /// Method of Transforming double
        /// </summary>
        /// <param name="number">input double</param>
        /// <returns>string representation</returns>
        public string TransformDouble(double number)
        {
            Dictionary<double, string> specialCases = GetSpecialDoubles();

            if (specialCases.TryGetValue(number, out string result))
            {
                return result;
            }

            Dictionary<char, string> words = GetWords();

            return GetWordRepresentation(number, words);
        }

        protected abstract Dictionary<char, string> GetWords();

        protected abstract Dictionary<double, string> GetSpecialDoubles();

        private static string GetWordRepresentation(double number, Dictionary<char, string> dictionary)
        {
            string stringRepresentation = number.ToString(CultureInfo.InvariantCulture);
            var verbalPresentation = new StringBuilder();

            foreach (var s in stringRepresentation)
            {
                verbalPresentation.Append($"{dictionary[s]} ");
            }

            return verbalPresentation.ToString().TrimEnd();
        }
    }

    /// <summary>
    /// Class TransformatorEng
    /// </summary>
    public class TransformatorEng : Transformer
    {
        protected override Dictionary<char, string> GetWords() => new Dictionary<char, string>
        {
            ['0'] = "zero",
            ['1'] = "one",
            ['2'] = "two",
            ['3'] = "three",
            ['4'] = "four",
            ['5'] = "five",
            ['6'] = "six",
            ['7'] = "seven",
            ['8'] = "eight",
            ['9'] = "nine",
            ['-'] = "minus",
            ['+'] = "plus",
            ['.'] = "point",
            [','] = "comma",
            ['E'] = "exponent",
            ['e'] = "exponent"
        };

        protected override Dictionary<double, string> GetSpecialDoubles() => new Dictionary<double, string>
        {
            [double.NaN] = "not a number",
            [double.NegativeInfinity] = "negative infinity",
            [double.PositiveInfinity] = "positive infinity"
        };
    }

    /// <summary>
    /// Class TransformatorRu
    /// </summary>
    public class TransformatorRu : Transformer
    {
        protected override Dictionary<char, string> GetWords() => new Dictionary<char, string>
        {
            ['0'] = "ноль",
            ['1'] = "один",
            ['2'] = "два",
            ['3'] = "три",
            ['4'] = "четыре",
            ['5'] = "пять",
            ['6'] = "шесть",
            ['7'] = "семь",
            ['8'] = "восемь",
            ['9'] = "девять",
            ['-'] = "минус",
            ['+'] = "плюс",
            ['.'] = "точка",
            [','] = "запятая",
            ['E'] = "экспонента",
            ['e'] = "экспонента"
        };

        protected override Dictionary<double, string> GetSpecialDoubles() => new Dictionary<double, string>
        {
            [double.NaN] = "не число",
            [double.NegativeInfinity] = "минус бесконечность",
            [double.PositiveInfinity] = "плюс бесконечность"
        };
    }

    //public class TransformToBits

}
