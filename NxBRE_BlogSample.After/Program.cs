using System;
using System.Collections.Generic;
using System.Linq;

namespace NxBRE_BlogSample.After
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            foreach (var customer in CustomerFactory.CreateSampleData().OrderBy(or => or.Age))
            {
                var sale = new Sale
                {
                    Customer = customer
                };
                var calculateDiscount = new CalculateDiscount(sale);
                calculateDiscount.Calcutale();
                Console.WriteLine(sale);
            }
            Console.ReadKey();
        }

        

    }
}
