using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using NxBRE.FlowEngine;
using NxBRE.FlowEngine.Factories;
using NxBRE.FlowEngine.IO;
using NxBRE.Util;

namespace NxBRE_BlogSample.After
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            List<Sale> sales = new List<Sale>();
            foreach (var customer in CreateSampleData().OrderBy(or => or.Age))
            {

                var sale = new Sale
                {
                    Customer = customer
                };
                var calculateDiscount = new CalculateDiscount(sale);
                calculateDiscount.Calcutale();
                Console.WriteLine(sale);
                //Console.WriteLine($"Customer => Full Name: {customer.FullName} , Age: {customer.Age}  Discount =>  {sale.Discount} ");
            }
            Console.ReadKey();
        }

        static IEnumerable<Customer> CreateSampleData()
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
                ,BirthDate = new DateTime(1976,4,28)
            },
            new Customer
            {
                CreatedDate = DateTime.Now
                , IsCasualtyKin = false
                , IsVeteran = false
                , Name = "Şakir"
                , SurName = "AltınMakas"
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

    public class CalculateDiscount
    {
        private readonly IFlowEngine _flowEngine;
        private const string AXmlFile = "Discount.xbre";

        public CalculateDiscount(Sale sale)
        {
            _flowEngine = new BREFactoryConsole(SourceLevels.Error, SourceLevels.All).NewBRE(new XBusinessRulesFileDriver(AXmlFile));
            if (_flowEngine == null) throw new Exception("BRE Not Properly Initialized!");
            _flowEngine.RuleContext.SetObject("currentSale", sale);
            _flowEngine.RuleContext.SetObject("currentCustomer", sale.Customer);
            _flowEngine.RuleContext.SetFactory("AddRule",new BRERuleFactory(AddRule));




        }
        public object AddRule(IBRERuleContext aBrc, IDictionary aMap, object aStep)
        {
            //string ruleName
            var sale = aBrc.GetObject("currentSale") as Sale;
            var ruleName = (string)Reflection.CastValue(aMap["ruleName"], typeof(string));
            if(!string.IsNullOrEmpty(ruleName)) sale.DiscountList.Add(ruleName);
            return sale;
        }


        private static void _flowEngine_ResultHandlers(object sender, IBRERuleResult ruleResult)
        {
            Console.WriteLine($"Rule Set ");
        }

        public void Calcutale()
        {
            if (!_flowEngine.Process("Age_60_Rule")) throw new Exception();
            if (!_flowEngine.Process("Veteran_Rule")) throw new Exception();
            if (!_flowEngine.Process("Casualty_Kin_Rule")) throw new Exception();
            if (!_flowEngine.Process("Total_Income_Greater_10000_Rule")) throw new Exception();
            if (!_flowEngine.Process("Total_Income_Greater_50000_Rule")) throw new Exception();
            if (!_flowEngine.Process("Total_Income_Greater_100000_Rule")) throw new Exception();
            //Console.WriteLine(sale);
        }
    }
}
