using NUnit.Framework;
using System;

namespace ArrayManipulations.Tests
{
    public class ArrayExtensionTests
    {
        [TestCase(new int[] { 7, 1, 2, 3, 4, 5, 6, 7, 68, 69, 70, 15, 17 }, 7, ExpectedResult = new int[] { 7, 7, 70, 17 })]
        [TestCase(new int[] { -678, 7, 3, 9, 1, 9, -56 }, 0, ExpectedResult = new int[] { })]
        [TestCase(new int[] { 3, 315, 9, 0, 45, 0, 32, -98, -535 }, 3, ExpectedResult = new int[] { 3, 315, 32, -535 })]
        [TestCase(new int[] { 14, 64, 98, 0, -3, 87, 43, 64, 99, 52, 87 }, 4, ExpectedResult = new int[] { 14, 64, 43, 64 })]
        [TestCase(new int[] { 6, 76, 87, 09, -546, 6, 76, 0, 0, 3 }, 1, ExpectedResult = new int[] { })]
        public int[] FilterArrayByKeyTest(int[] array, int key)
        => array.Filter(new FilterArrayByKey(key));

        [Test]
        public void FilterArrayByKey_InvalidKey_ThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new FilterArrayByKey(15));
            Assert.Throws<ArgumentException>(() => new FilterArrayByKey(-15));
        }

        [Test]
        public void FilterArrayByKey_EmptyArray_ThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => ArrayExtension.Filter(new int[] { }, new FilterArrayByKey(8)));
        }

        [Test]
        public void FilterArrayByKey_ArrayIsNull_ThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => ArrayExtension.Filter(null, new FilterArrayByKey(8)));
        }

        [TestCase(new int[] { 7, 1, 2, 3, 4, 5, 6, 7, 68, 69, 70, 15, 17 }, ExpectedResult = new int[] { 2, 4, 6, 68, 70 })]
        [TestCase(new int[] { -678, 7, 3, 9, 1, 9, -56 }, ExpectedResult = new int[] { -678, -56 })]
        [TestCase(new int[] { 3, 315, 9, 0, 45, 0, 32, -98, -535 }, ExpectedResult = new int[] { 0, 0, 32, -98 })]
        [TestCase(new int[] { 14, 64, 98, 0, -3, 87, 43, 64, 99, 52, 87 }, ExpectedResult = new int[] { 14, 64, 98, 0, 64, 52 })]
        [TestCase(new int[] { 13, 97, -9853, -7, 9, 5, 55, 321 }, ExpectedResult = new int[] { })]
        public int[] EvenOrOddTest(int[] array)
            => array.Filter(new EvenOrOdd());

        [TestCase(new int[] { 0, -98, 989, 4334, -98, 1331, 5543, -876, 1353 }, ExpectedResult = new int[] { 0, 989, 4334, 1331 })]
        [TestCase(new int[] { 7666, 525, 87, 2222, 1212, 22222222, 3 }, ExpectedResult = new int[] { 525, 2222, 22222222, 3 })]
        [TestCase(new int[] { 76, -98, 355, 551, 654, 7611, 75611, -8765, 789 }, ExpectedResult = new int[] { })]
        [TestCase(new int[] { 3103013, 3013103, 103030301 }, ExpectedResult = new int[] { 3103013, 3013103, 103030301 })]
        [TestCase(new int[] { 60, 80, 990, 1177711 }, ExpectedResult = new int[] { 1177711 })]
        public int[] Palindrome(int[] array)
            => array.Filter(new Palindrome());
    }
}
