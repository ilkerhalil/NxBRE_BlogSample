using System;
using System.Collections.Generic;

namespace NxBRE_BlogSample
{
    internal static class Program
    {
        //Yıllık bilet satışı 10000 TL'ın üzerindeyse %5
        //Yıllık bilet satışı 50000 TL'ın üzerindeyse %7
        //Yıllık bilet satışı 100000 TL'ın üzerindeyse %10
        //5 Yıllık müşterilere %2
        //10 Yıllık müşterilere %3
        //60 yaşından büyük müşterilere %12
        //Doğum günü bugün olanlara %1
        //Gazilere %5
        //Şehit yakınlarına %7


        private static void Main(string[] args)
        {
            var sampleData = CreateSampleData();
            foreach (var customer in sampleData)
            {
                var discount = CalculateDiscount(customer);
                Console.WriteLine($"({customer.Name}  {customer.SurName}  {customer.Age}  {customer.CreatedDate.ToShortDateString()}) => Discount : {discount}");
            }
            Console.ReadKey();
        }

        private static decimal CalculateDiscount(Customer customer)
        {
            var discount = 0m;
            if (customer.TotalSale > 10000) discount = 0.05M;
            if (customer.TotalSale > 50000) discount += 0.07M;
            if (customer.TotalSale > 100000) discount += 0.1M;
            if ((DateTime.Now.Year - customer.CreatedDate.Year) >= 5 && (DateTime.Now.Year - customer.CreatedDate.Year) < 10) discount += 0.02M;
            if (DateTime.Now.Year - customer.CreatedDate.Year >= 10) discount += 0.03M;
            if (DateTime.Now.Month == customer.BirthDate.Month && DateTime.Now.Day == customer.BirthDate.Day) discount += 0.01M;
            if (DateTime.Now.Year - customer.BirthDate.Year > 60) discount += 0.12M;
            if (customer.IsVeteran) discount += 0.05m;
            if (customer.IsCasualtyKin) discount += 0.07m;
            return discount;
        }

        private static IEnumerable<Customer> CreateSampleData()
        {
            return new List<Customer>
            {
                new Customer
                {
                    CreatedDate = new DateTime(2015,3,1)
                    ,IsCasualtyKin = false
                    ,IsVeteran = false
                    ,Name = "Veli"
                    ,SurName = "Küçükölmez"
                    ,TotalSale = 100000m
                    ,BirthDate = new DateTime(1960,8,15)

                },
            new Customer
            {
                CreatedDate = new DateTime(2014, 6, 7)
                , IsCasualtyKin = false
                , IsVeteran = false
                , Name = "Mehmet"
                , SurName = "Aydoğan"
                , TotalSale = 500000m
                ,BirthDate = new DateTime(1965,6,02)
            },
            new Customer
            {
                CreatedDate = DateTime.Now
                , IsCasualtyKin = false
                , IsVeteran = false
                , Name = "Murat"
                , SurName = "Güler"
                , TotalSale = 0m
                ,BirthDate = new DateTime(1980,4,22)
            },
            new Customer
            {
                CreatedDate = new DateTime(2010,4,19)
                , IsCasualtyKin = false
                , IsVeteran = true
                , Name = "İlker Halil"
                , SurName = "Türer"
                , TotalSale = 500m
                ,BirthDate = new DateTime(1979,9,16)
            },
            new Customer
            {
                CreatedDate = new DateTime(2010,4,19)
                , IsCasualtyKin = true
                , IsVeteran = false
                , Name = "Hayriye"
                , SurName = "Gürel"
                , TotalSale = 300m
                ,BirthDate = new DateTime(1980,4,25)
            },
            new Customer
            {
                CreatedDate = new DateTime(2009,2,01)
                , IsCasualtyKin = false
                , IsVeteran = false
                , Name = "Ali"
                , SurName = "Sarısoy"
                , TotalSale = 10000m
                ,BirthDate = new DateTime(1973,2,12)
            },
            new Customer
            {
                CreatedDate = new DateTime(2004,9,16)
                , IsCasualtyKin = false
                , IsVeteran = false
                , Name = "Remzi"
                , SurName = "Çınar"
                , TotalSale = 10000m
                ,BirthDate = new DateTime(1952,7,9)
            },
            new Customer
            {
                CreatedDate = new DateTime(1997,4,3)
                , IsCasualtyKin = false
                , IsVeteran = true
                , Name = "Fehim"
                , SurName = "Bayrak"
                , TotalSale = 10000m
                ,BirthDate = new DateTime(1941,3,28)
            }};
        }
    }


}
