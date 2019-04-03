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
        public int[] PalindromeTest(int[] array)
            => array.Filter(new Palindrome());

        [TestCase((object)new string[] { "none", "word", "words", "testcase", "cod", "common", "access", "clock" },
            ExpectedResult = new string[] { "cod", "none", "word", "words", "clock", "common", "access", "testcase" })]
        [TestCase((object)new string[] { "class", "cl", "c", "", "clas", "clas", "none", "cla" },
            ExpectedResult = new string[] { "", "c", "cl", "cla", "clas", "clas", "none", "class" })]
        [TestCase((object)new string[] { "", "-", "651", "09875", "-0,986", "io09", "-0ig54", "", " " },
            ExpectedResult = new string[] { "", "", "-", " ", "651", "io09", "09875", "-0,986", "-0ig54" })]
        public string[] SortingByLengthComparatorTest(string[] array)
          => array.Sort(new SortingByLengthComparator());

        [TestCase((object)new string[] { "none", "word", "words", "testcase", "cod", "common", "access", "clock" }, ExpectedResult = new string[] { "testcase", "common", "access", "words", "clock", "none", "word", "cod" })]
        [TestCase((object)new string[] { "class", "cl", "c", "", "clas", "clas", "none", "cla" }, ExpectedResult = new string[] { "class", "clas", "clas", "none", "cla", "cl", "c", "" })]
        [TestCase((object)new string[] { "", "-", "651", "09875", "-0,986", "io09", "-0ig54", "", " " }, ExpectedResult = new string[] { "-0,986", "-0ig54", "09875", "io09", "651", "-", " ", "", "" })]
        public string[] SortingByLengthDescendingComparatorTest(string[] array)
          => array.Sort(new SortingByLengthDescendingComparator());

        [TestCase(new string[] { "none", "word", "words", "testcase", "cod", "common", "access", "clock" }, 'o', ExpectedResult = new string[] { "testcase", "access", "none", "word", "words", "cod", "clock", "common" })]
        [TestCase(new string[] { "class", "cl", "c", "", "clas", "clas", "none", "cla" }, 'a', ExpectedResult = new string[] { "cl", "c", "", "none", "class", "clas", "clas", "cla" })]
        [TestCase(new string[] { "", "-", "651", "09875", "-0,986", "io09", "-0ig54", "", " " }, 'j', ExpectedResult = new string[] { "", "-", "651", "09875", "-0,986", "io09", "-0ig54", "", " " })]
        [TestCase(new string[] { "comb", "coom", "combination", "cooombinate", "/-,t", "combine", "cmb" }, 'o', ExpectedResult = new string[] { "/-,t", "cmb", "comb", "combine", "coom", "combination", "cooombinate" })]
        public string[] SortingByOccurranceComparatorTest(string[] array, char key)
            => array.Sort(new SortingByOccurrenceComparator(key));

        [TestCase(new string[] { "none", "word", "words", "testcase", "cod", "common", "access", "clock" }, 'o', ExpectedResult = new string[] { "common", "none", "word", "words", "cod", "clock", "testcase", "access" })]
        [TestCase(new string[] { "class", "cl", "c", "", "clas", "clas", "none", "cla" }, 'a', ExpectedResult = new string[] { "class", "clas", "clas", "cla", "cl", "c", "", "none" })]
        [TestCase(new string[] { "", "-", "651", "09875", "-0,986", "io09", "-0ig54", "", " " }, 'j', ExpectedResult = new string[] { "", "-", "651", "09875", "-0,986", "io09", "-0ig54", "", " " })]
        [TestCase(new string[] { "comb", "coom", "combination", "cooombinate", "/-,t", "combine", "cmb" }, 'o', ExpectedResult = new string[] { "cooombinate", "coom", "combination", "comb", "combine", "/-,t", "cmb" })]
        public string[] SortingByOccurranceDescendingComparatorTest(string[] array, char key)
            => array.Sort(new SortingByOccurrenceDescendingComparator(key));

        [Test]
        public void Sort_EmptyArray_ThrowArgumentException()
        {
            string[] array = new string[] { };
            Assert.Throws<ArgumentException>(() => array.Sort(new SortingByOccurrenceDescendingComparator('u')));
        }

        [Test]
        public void Sort_ArrayIsNull_ThrowArgumentNullException()
        {
            string[] array = null;
            Assert.Throws<ArgumentNullException>(() => array.Sort(new SortingByOccurrenceDescendingComparator('u')));
        }

        [TestCase(new double[] { 0, -9, -8.87, 6 }, ExpectedResult = new string[] { "zero", "minus nine", "minus eight point eight seven", "six" })]
        [TestCase(new double[] { double.NaN, double.NegativeInfinity, 8.8 }, ExpectedResult = new string[] { "not a number", "negative infinity", "eight point eight"})]
        [TestCase(new double[] { 3.006, 328, 5, 90, double.PositiveInfinity }, ExpectedResult = new string[] { "three point zero zero six", "three two eight", "five", "nine zero", "positive infinity" })]
        public string[] TransformatorEngTest(double[] array)
            => array.Transform(new TransformatorEng());

        [TestCase(new double[] { 0, -9, -8.87, 6 }, ExpectedResult = new string[] { "ноль", "минус девять", "минус восемь точка восемь семь", "шесть" })]
        [TestCase(new double[] { double.NaN, double.NegativeInfinity, 8.8 }, ExpectedResult = new string[] { "не число", "минус бесконечность", "восемь точка восемь" })]
        [TestCase(new double[] { 3.006, 328, 5, 90, double.PositiveInfinity }, ExpectedResult = new string[] { "три точка ноль ноль шесть", "три два восемь", "пять", "девять ноль", "плюс бесконечность" })]
        public string[] TransformatorRuTest(double[] array)
            => array.Transform(new TransformatorRu());
    }
}