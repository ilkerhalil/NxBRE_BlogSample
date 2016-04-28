using System.Collections.Generic;
using System.Linq;

namespace NxBRE_BlogSample.After
{
    public class Basket
    {
        public Customer Customer { get; set; }

        const string Empty = "Empty";

        public Basket()
        {
            DiscountList = new List<string>();
            Products = new List<Product>();
        }

        public List<Product> Products { get; }

        public IList<string> DiscountList { get; }

        public decimal DiscountRate { get; set; }

        public decimal TotalDiscount
        {
            get { return Products.Any() ? (TotalPrice * DiscountRate)/100 : 0m; }
        }


        public decimal TotalPrice
        {
            get
            {
                return Products.Any() ? Products.Sum(s => s.Price) : 0m;
            }
        }

        public override string ToString()
        {
            return DiscountList.Any() ? $"Customer: {Customer} Discount: {DiscountRate} \t\nDiscountList: { string.Join(";", DiscountList)}" : $"Customer: {Customer.FullName} Discount: {DiscountRate} DiscountList: { Empty}";
        }


    }
}