using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace MyLinq.Logic.UnitTest
{
    [TestClass]
    public class IEnumerableExtensionsUnitTest
    {
        [TestMethod]
        public void ValidateFilter_ListOfNumbersFromMinus10To10_ExpectedEvenNumbers()
        {
            var source = new[] { -10, -9, -8, -7, -6, -5, -4, -3, -2, -1, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var expected = new[] { -10, -8, -6, -4, -2, 0, 2, 4, 6, 8, 10 };
            var actual = source.Filter(x => x % 2 == 0);
            CollectionAssert.AreEqual(expected, actual.ToArray(), "Filter sollte alle geraden Zahlen von -10 bis 10 beinhalten!");
        }
        [TestMethod]
        public void ValidateFilter_ListofNumbersFromMinus10To10_ExpectedUnevenNumbers()
        {
            var source = new[] { -10, -9, -8, -7, -6, -5, -4, -3, -2, -1, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var expected = new[] { -9, -7, -5, -3, -1, 1, 3, 5, 7, 9 };
            var actual = source.Filter(x => x % 2 != 0);
            CollectionAssert.AreEqual(expected, actual.ToArray(), "Filter sollte alle ungeraden Zahlen von -10 bis 10 beinhalten!");
        }
        [TestMethod]
        public void ValidateFilter_ListofNumbersFromMinus10To10_ExpectedDivisiveBy3Numbers()
        {
            var source = new[] { -10, -9, -8, -7, -6, -5, -4, -3, -2, -1, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var expected = new[] { -9, -6, -3, 0, 3, 6, 9 };
            var actual = source.Filter(x => x % 3 == 0);
            CollectionAssert.AreEqual(expected, actual.ToArray(), "Filter sollte alle durch 3 teilbahren Zahlen von -10 bis 10 beinhalten.");
        }
        [TestMethod]
        public void ValidateFilter_ListOfStrings_ExpectedStringsContainingA()
        {
            string[] names = { "Helge", "Hofer", "Eva", "Mary", "Thomas", "Anton", "Dieter", "Rolf", "Horst" };
            string[] expected = { "Helge", "Hofer", "Dieter" };
            var actual = names.Filter(x => x.Contains("e"));
            CollectionAssert.AreEqual(expected, actual.ToArray(), "Filter ist falsch!");
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ValidateFilter_NullReference_ExpectedArgumentNullException()
        {
            int[] source = null;
            source.Filter(x => x % 2 == 0);
        }
        [TestMethod]
        public void ValidateMap_ListOfIntNumbersFromMinus10To10_ExpectedListOfDoubleNumbers()
        {
            int[] source = new[] { -10, -9, -8, -7, -6, -5, -4, -3, -2, -1, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            double[] expected = new[] { -10.0, -9.0, -8.0, -7.0, -6.0, -5.0, -4.0, -3.0, -2.0, -1.0,
                                        0.0, 1.0, 2.0, 3.0, 4.0, 5.0, 6.0, 7.0, 8.0, 9.0, 10.0 };
            var actual = source.Map(x => x * 1.0);
            CollectionAssert.AreEqual(expected, actual.ToArray(), "Erwartetes Ergebnis nicht erfüllt!");
        }
        [TestMethod]
        public void ValidateMap_ListOfStringsFromMinus10To10_ExpectedListofIntNumbers()
        {
            string[] source = { "-10", "-9", "-8", "-7", "-6", "-5", "-4", "-3", "-2", "-1", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" };
            int[] expected = { -10, -9, -8, -7, -6, -5, -4, -3, -2, -1, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var actual = source.Map(x => Convert.ToInt32(x));
            CollectionAssert.AreEqual(expected, actual.ToArray(), "Erwartetes Ergebnis nicht erfüllt!");
        }
        [TestMethod]
        public void ValidateToArray_ListofNameStrings_ExpectedArrayOfNameStrings()
        {
            string[] names = { "Helge", "Hofer", "Eva", "Mary", "Thomas", "Anton", "Dieter", "Rolf", "Horst" };
            List<string> source = new List<string>();
            source.AddRange(names);
            string[] expected = { "Helge", "Hofer", "Eva", "Mary", "Thomas", "Anton", "Dieter", "Rolf", "Horst" };
            var actual = source.ToArray();
            CollectionAssert.AreEqual(expected, actual, "Erwartetes Ergebnis nicht erfüllt!");
        }
        [TestMethod]
        public void ValidateToArray_HashSetOfIntNumbersFromMinus10To10_ExpectedArrayOfIntNumbersFromMinus10To10()
        {
            HashSet<int> source = new HashSet<int>();
            for (int i = -10; i < 11; i++)
            {
                source.Add(i);
            }
            int[] expected = new[] { -10, -9, -8, -7, -6, -5, -4, -3, -2, -1, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int[] actual = source.ToArray();
            CollectionAssert.AreEqual(expected, actual, "Erwartetes Ergebnis nicht erfüllt!");
        }
        [TestMethod]
        public void ValidateToList_ArrayOfNameString_ExpectedListOfNameStrings()
        {
            string[] source = { "Helge", "Hofer", "Eva", "Mary", "Thomas", "Anton", "Dieter", "Rolf", "Horst" };
            List<string> expected = new List<string>();
            foreach (var item in source)
            {
                expected.Add(item);
            }
            List<string> actual = source.ToList();
            CollectionAssert.AreEqual(expected, actual, "Erwartetes Ergebnis nicht erfüllt!");
        }
        [TestMethod]
        public void ValidateToList_HashSetOfIntNumbersFromMinus10To10_ExpectedListOfIntNumbersFromMinus10To10()
        {
            HashSet<int> source = new HashSet<int>();
            List<int> expected = new List<int>();
            for (int i = -10; i < 11; i++)
            {
                source.Add(i);
                expected.Add(i);
            }
            int[] actual = source.ToArray();
            CollectionAssert.AreEqual(expected, actual, "Erwartetes Ergebnis nicht erfüllt!");
        }
        [TestMethod]
        public void ValidateSum_ArrayOfDoubleNumbers_ExpectedSumOfArrayOfDoubleNumbers()
        {
            double[] source = new[] { -10, -9.1, -8.7, -7.0, -6.1, -5.0, -4.9, -3.1, -2.0, -1.0,
                                        0.2, 1.7, 2, 3.8, 4.1, 5.1, 6.0, 7.7, 8.9, 9.8, 10 };
            double expected = 0;
            foreach (var item in source)
            {
                expected += item;
            }
            double actual = source.Sum(x => x * 1.0);
            Assert.AreEqual(expected, actual, "Erwartetes Ergebnis nicht erfüllt!");
        }
        [TestMethod]
        public void ValidateSum_ArrayOfStrings_ExpectedSumOfStringArraysLength()
        {
            string[] source = { "Helge", "Hofer", "Eva", "Mary", "Thomas", "Anton", "Dieter", "Rolf", "Horst" };
            double expected = 43;

            double actual = source.Sum(x => x.Length);
            Assert.AreEqual(expected, actual, "Erwartetes Ergebnis nicht erfüllt!");
        }
        [TestMethod]
        public void ValidateMin_IntArray_ExpectedLowestValueOfIntArray()
        {
            int[] source = { 6, 1, 7, 3, 9, 3, 8, 2, 7, 43, 0, 3, 2, -134, 4734, 32, -5151, 8908 };
            double expected = -5151.0;
            double? actual = source.Min(x => x * 1.0);
            Assert.AreEqual(expected, actual, "Erwartetes Ergebnis nicht erfüllt!");
        }
        [TestMethod]
        public void ValidateMin_EmptyArray_ExpectedNull()
        {
            int[] source = new int[0];
            double? expected = null;
            double? actual = source.Min(x => x * 1.0);
            Assert.AreEqual(expected, actual, "Erwartetes Ergebnis nicht erfüllt!");
        }
        [TestMethod]
        public void ValidateMax_IntArray_ExpectedHighestValueOfIntArray()
        {
            int[] source = { 6, 1, 7, 3, 9, 3, 8, 2, 7, 43, 0, 3, 2, -134, 4734, 32, -5151, 8908 };
            double expected = 8908.0;
            double? actual = source.Max(x => x * 1.0);
            Assert.AreEqual(expected, actual, "Erwartetes Ergebnis nicht erfüllt!");
        }
        [TestMethod]
        public void ValidateMax_StringArray_ExpectedLengthOfLongestString()
        {
            string[] source = { "a", "abc", "ab", "abcde", "abcdefg", "", string.Empty, "abc"};
            double expected = 7.0;
            double? actual = source.Max(x => x.Length);
            Assert.AreEqual(expected, actual, "Erwartetes Ergebnis nicht erfüllt!");
        }
        [TestMethod]
        public void ValidateAverage_IntArray_ExpectedAverageValueOfIntArray()
        {
            int[] source = { 6, 1, 7, 3, 9, 3, 8, 2, 7, 43, 0, 3, 2, -134, 4734, 32, -5151, 8908 };
            double expected = 0;
            int count = 0;
            foreach (var item in source)
            {
                expected += item;
                count++;
            }
            expected = count > 0 ? expected / count : expected;
            double? actual = source.Average(x => x * 1.0);
            Assert.AreEqual(expected, actual, "Erwartetes Ergebnis nicht erfüllt!");
        }
        [TestMethod]
        public void ValidateAverage_EmptyArray_ExpectedZero()
        {
            int[] source = new int[0];
            double? expected = 0;
            double? actual = source.Average(x => x * 1.0);
            Assert.AreEqual(expected, actual, "Erwartetes Ergebnis nicht erfüllt!");
        }
        //[TestMethod]
        //public void ValidateForEach
        //wie testet man Console.WriteLine? Nix gutes gefunden.

        //[TestMethod]
        //public void ValidateForEachWithTKey_StringArrayNames_ExpectedStringArraySortedByName()
        //{
        //    string[] source = { "Helge", "Hofer", "Eva", "Mary", "Thomas", "Anton", "Dieter", "Rolf", "Horst" };
        //    string[] expected = { "Anton", "Eva", "Dieter", "Helge", "Hofer", "Horst", "Mary", "Rolf", "Thomas" };
        //    string[] actual = source.ForEach() ?????
        //}

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ValidateForEach_NullReference_ExpectedArgumentNullException()
        {
            int[] source = null;
            source.ForEach(x => x++);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ValidateSortBy_NullReference_ExpectedArgumentNullException()
        {
            int[] source = null;
            source.SortBy(x => x++);
        }
        [TestMethod]
        public void ValidateDistinct_IntArrayWithRepeatingValues_ExpectedIEnumerableWithoutRepeatingValues()
        {
            int[] source = { 1, 234, 7, 3, 4, 1, 7, 3, 2, 6, 1, 5, 2 };
            int[] expected = { 1, 234, 7, 3, 4, 2, 6, 5 };
            var actual = source.Distinct();
            CollectionAssert.AreEqual(expected, actual.ToArray(), "Erwartetes Ergebnis nicht erfüllt!");
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ValidateDistinct_NullReference_ExpectedArgumentNullException()
        {
            int[] source = null;
            source.SortBy(x => x++);
        }
    }
}
