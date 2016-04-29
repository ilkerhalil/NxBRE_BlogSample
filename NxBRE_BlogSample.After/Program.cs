using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleTables.Core;
using NxBRE_BlogSample.After.Factories;

namespace NxBRE_BlogSample.After
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var baskets = BasketFactory.CreateBaskets().ToList();
            var consoleTable = new ConsoleTable(typeof(Basket).GetProperties().Select(s => s.Name).ToArray());
            foreach (var basket in baskets)
            {
                var calculateDiscount = new CalculateDiscount(basket);
                calculateDiscount.Calcutale();
                var firstOrDefault = basket.Products.First();

                consoleTable.AddRow(basket.Customer.FullName, firstOrDefault.Name,"", basket.DiscountRate, basket.TotalDiscount, basket.SubTotal,basket.TotalPrice);
            }
            //ConsoleTable.From(baskets).Write(Format.MarkDown);


            consoleTable.Write();
            Console.ReadKey();
        }



    }
}
