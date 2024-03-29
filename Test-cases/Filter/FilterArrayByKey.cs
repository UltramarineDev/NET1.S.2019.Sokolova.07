﻿using ArrayManipulations.Interfaces;
using System;

namespace Test_cases.Filter
{
    /// <summary>
    /// Class FilterArrayByKey with implementation of IFilter interface
    /// </summary>
    public class FilterArrayByKey : IPredicate
    {
       private byte key;

        /// <summary>
        /// Initializes a new instance of the FilterArrayByKey class
        /// </summary>
        /// <exception cref="ArgumentException">Thrown if key value in invalid</exception>     
        public FilterArrayByKey(byte key)
        {
            Key = key;
        }

        /// <summary>
        /// Gets or sets the value of key
        /// </summary>
        public byte Key
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
}
