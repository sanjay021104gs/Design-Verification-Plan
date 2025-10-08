using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DVP.Models
{
    public class TestRecord
    {
        [Key]
        public int Id { get; set; }

        public int DvpNumber { get; set; } 

        public string Customer { get; set; }

        public string Test_Name { get; set; }

        public string TDNo { get; set; }

        public string BiTestName { get; set; }

        public string TestCondition { get; set; }

        public string AcceptanceCriteria { get; set; }

        public string BiTestCode { get; set; }

        public decimal? TestCost { get; set; }

        
    }
}