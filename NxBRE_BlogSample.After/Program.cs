using System;
using System.Collections.Generic;
using System.Linq;
using NxBRE_BlogSample.After.Factories;

namespace NxBRE_BlogSample.After
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var baskets = BasketFactory.CreateBaskets().ToList();
            foreach (var basket in baskets)
            {
                var calculateDiscount = new CalculateDiscount(basket);
                calculateDiscount.Calcutale();
                Console.WriteLine(basket);
            }

            Console.ReadKey();
        }



    }
}
