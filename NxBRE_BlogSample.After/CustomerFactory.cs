using System;
using System.Collections.Generic;

namespace NxBRE_BlogSample.After
{
    internal static class CustomerFactory
    {
        public static IEnumerable<Customer> CreateSampleData()
        {
            return new List<Customer>
            {
                new Customer
                {
                    CreatedDate = new DateTime(2015,3,1)
                    ,IsCasualtyKin = false
                    ,IsVeteran = false
                    ,Name = "Burcu"
                    ,SurName = "Türer"
                    ,TotalSale = 5000
                    ,BirthDate = new DateTime(1995,8,15)

                },
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
                    , SurName = "Aydoðan"
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
                    ,BirthDate = new DateTime(1976,4,28)
                },
                new Customer
                {
                    CreatedDate = DateTime.Now
                    , IsCasualtyKin = false
                    , IsVeteran = false
                    , Name = "Þakir"
                    , SurName = "AltýnMakas"
                    , TotalSale = 0m
                    ,BirthDate = new DateTime(1980,4,22)
                },
                new Customer
                {
                    CreatedDate = new DateTime(2010,4,19)
                    , IsCasualtyKin = false
                    , IsVeteran = true
                    , Name = "Ýlker Halil"
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
                    , SurName = "Sarýsoy"
                    , TotalSale = 10000m
                    ,BirthDate = new DateTime(1973,2,12)
                },
                new Customer
                {
                    CreatedDate = new DateTime(2004,9,16)
                    , IsCasualtyKin = false
                    , IsVeteran = false
                    , Name = "Remzi"
                    , SurName = "Çýnar"
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