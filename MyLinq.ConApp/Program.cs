using System;
using System.Collections.Generic;
using MyLinq.Logic;

namespace MyLinq.ConApp
{
    class Program
    {
        static int[] intArray = new[] { 7, 8, 3, 9, 5, 1, 16, 64, 53, 76, 8, 11, 7 };
        static void Main(string[] args)
        {
            Console.WriteLine("MyLinq-Demo");
            //var even = intArray.Filter(x => x % 2 == 0);
            //foreach (var item in even)
            //{
            //    Console.WriteLine(item);
            //}

            //Wir haben die Method Extensions "ForEach" geschrieben:
            var even = intArray.Filter(x => x % 2 == 0)
                               .ForEach(x => Console.WriteLine(x));
            Console.WriteLine();
            //mapping test
            var doubleArray = intArray.Map(x => x * 1.0) //Ergebnis ist double. 
                                      .ForEach(x => Console.WriteLine(x)); //double-Werte werden ausgegeben
            Console.WriteLine();
            string[] strArray = new string[] { "hallo", "maxi" };
            

            double[] doubleArray2 = new[] { 7.1, 8.4, 3.0, 9, 5.1, 1.9, 16, 64, 53, 76, 11 };
            double? minimum = doubleArray2.Min(x => x * 1.0);
            Console.WriteLine(minimum);
            Console.WriteLine();

            
            
        }
    }
}
