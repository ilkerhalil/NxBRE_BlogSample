using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;

namespace NxBRE_BlogSample.After
{
    public class Sale
    {
        public Customer Customer { get; set; }

        const string Empty = "Empty";

        public Sale()
        {
            DiscountList = new List<string>();
        }

        public Product Item { get; set; }

        public override string ToString()
        {
            return DiscountList.Any() ? $"Customer: {Customer} Discount: {Discount} \nDiscountList: { string.Join(";", DiscountList)}" : $"Customer: {Customer.FullName} Discount: {Discount} DiscountList: { Empty}";
        }

        public decimal Discount { get; set; }

        public IList<string> DiscountList { get; private set; }


    }
}