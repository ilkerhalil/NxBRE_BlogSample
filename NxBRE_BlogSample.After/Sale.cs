namespace NxBRE_BlogSample.After
{
    public class Sale
    {
        public Customer Customer { get; set; }

        public override string ToString()
        {
            return $"Customer: {Customer.Name} {Customer.SurName}, Discount: {Discount}";
        }

        public decimal Discount { get; set; }
    }
}