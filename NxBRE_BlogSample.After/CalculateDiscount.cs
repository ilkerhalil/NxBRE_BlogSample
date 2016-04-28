using System;
using System.Collections;
using System.Diagnostics;
using NxBRE.FlowEngine;
using NxBRE.FlowEngine.Factories;
using NxBRE.FlowEngine.IO;
using NxBRE.Util;

namespace NxBRE_BlogSample.After
{
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
            _flowEngine.RuleContext.SetFactory("AddRule", new BRERuleFactory(AddRule));

        }

        public object AddRule(IBRERuleContext aBrc, IDictionary aMap, object aStep)
        {
            var sale = aBrc.GetObject("currentSale") as Sale;
            var ruleName = (string)Reflection.CastValue(aMap["ruleName"], typeof(string));
            if (!string.IsNullOrEmpty(ruleName)) sale.DiscountList.Add(ruleName);
            return sale;
        }


        public void Calcutale()
        {
            if (!_flowEngine.Process("Age_60_Rule")) throw new Exception();
            if (!_flowEngine.Process("Veteran_Rule")) throw new Exception();
            if (!_flowEngine.Process("Casualty_Kin_Rule")) throw new Exception();
            if (!_flowEngine.Process("Total_Income_Greater_10000_Rule")) throw new Exception();
            if (!_flowEngine.Process("Total_Income_Greater_50000_Rule")) throw new Exception();
            if (!_flowEngine.Process("Total_Income_Greater_100000_Rule")) throw new Exception();
        }
    }
}