using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
            CollectionAssert.AreEqual(expected, actual.ToArray(), "Filter sollte alle ungeraden zahlen von -10 bis 10 beinhalten!");
        }
        [TestMethod]
        public void ValidateFilter_ListofNumbersFromMinus10To10_ExpectedDivisiveBy3Numbers()
        {
            var source = new[] { -10, -9, -8, -7, -6, -5, -4, -3, -2, -1, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var expected = new[] { -9, -6, -3, 0, 3, 6, 9 };
            var actual = source.Filter(x => x % 3 == 0);
            CollectionAssert.AreEqual(expected, actual.ToArray(), "Filter sollte ");
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
        public void  ValidateMap_ListOfIntNumbersFromMinus10To10_ExpectedListOfDoubleNumbers()
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
            CollectionAssert.AreEqual(expected, actual.ToArray(), "Erwartetes Ergebnis nicht erfüllt!");
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
            CollectionAssert.AreEqual(expected, actual.ToArray(), "Erwartetes Ergebnis nicht erfüllt!");
        }
    }
}
