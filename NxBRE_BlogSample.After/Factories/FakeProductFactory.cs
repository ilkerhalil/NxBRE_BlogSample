using System;
using System.Collections.Generic;
using System.Linq;

namespace NxBRE_BlogSample.After.Factories
{
    public static class FakeProductFactory
    {
        private static readonly Random Random = new Random();
        public static IEnumerable<Product> CreateProducts()
        {
            var fakeProductNames = new[]
            {
                "Biowarm","Alpha Hotron","Topdom","Tran - Tax",
                "Saois","Doublewarm","Stringing","Vento Cof",
                "Ron Com","San Donbam","Lexilax","Ventoquoflex",
                "Konplus","Airron","Coftone","Vaia Lux","White - Home",
                "Ransolofind","Donglax","Lexi Zap","Quote Tough",
                "Fun Soncore","Newtam","Tough - Phase","An - Core",
                "Sail Ron","U - plus","Medis","Toughity","Zamsanlax",
                "Meddonex","Groovenimair","Anlux","Med Canstring",
                "Solotam","Latstring","Donsonbam","Quobam","Joyron",
                "Dandonlex","Ontofresh","Inchit","Indigocof","K - Totex",
                "Santone","Tres Lotit","Sanplus","Math Com","Kinron",
                "Quo Dom","Lamin","Med - Lux","Strongcore","Lotflex",
                "Doublesantough","Stocktough","Quodom","Air Siltough",
                "Zerfresh","Medtip","Jayis","Scot Tip","Goldensunhold",
                "Goldenlux","Stattech","Lightremtrax","Ecoex","Mat - Tex",
                "Re Dintip","Sub Totom","Greencof","Blacktex","Ding - Sing",
                "Concom","Lamair","Y - tough","Joblam"
            };
            return fakeProductNames.Select(s => new Product { Id = Guid.NewGuid(), Name = s, Price = Math.Round(RandomNumberBetween(100, 50000), 2) });
        }

        private static decimal RandomNumberBetween(double minValue, double maxValue)
        {
            var next = Random.NextDouble();

            return Convert.ToDecimal(minValue + next * (maxValue - minValue));
        }
    }

}