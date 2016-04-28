using System;

namespace NxBRE_BlogSample.After
{
    public class Customer
    {
        public string Name { get; set; }
        public string SurName { get; set; }

        public string FullName
        {
            get { return $"{Name} {SurName}"; }
        }



        public decimal TotalSale { get; set; }

        public bool IsVeteran { get; set; }

        public bool IsCasualtyKin { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime BirthDate { get; set; }



        
        public int Age {
            get { return DateTime.Now.Year- BirthDate.Year; }
        }

        public override string ToString()
        {
            return $"FullName {FullName}, TotalSale: {TotalSale}, IsVeteran: {IsVeteran}, IsCasualtyKin: {IsCasualtyKin},{Age}, CreatedDate: {CreatedDate.ToShortDateString()}";
        }
    }
}