using System.Collections.Generic;
using System.Linq;

namespace NxBRE_BlogSample.After.Factories
{
    public static class BasketFactory
    {
        public static IEnumerable<Basket> CreateBaskets()
        {
            var customers = CustomerFactory.CreateSampleData().OrderBy(or => or.Age);
            var products = FakeProductFactory.CreateProducts();
            var numberOfObjectsPerPage = 5;
            var pageNumber = 1;
            foreach (var customer in customers)
            {
                var childProducts = products.Skip(numberOfObjectsPerPage * pageNumber).Take(numberOfObjectsPerPage);
                pageNumber++;
                var basket = new Basket { Customer = customer };
                basket.Products.AddRange(childProducts);
                yield return basket;
            }
        }
    }
}
