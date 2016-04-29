using System;

namespace NxBRE_BlogSample.After
{
    public class Product
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public decimal Price { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Price: {Price}";
        }
    }
}