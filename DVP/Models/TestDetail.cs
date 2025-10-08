using System.ComponentModel.DataAnnotations;

namespace DVP.Models
{
    public class TestDetail
    {
        [Key]
        public int Id { get; set; }

        public int DvpNumber { get; set; } // 🟢 Link to DvpFormEntry

        
        public string Customer { get; set; }

        
        public string TestName { get; set; }

        
        public string TDNo { get; set; }

        
        public string TestCondition { get; set; }

        
        public string AcceptanceCriteria { get; set; }

        public decimal? TestCostPlan { get; set; }

        public int? QtyPlan { get; set; }

        
        public string DVPlan { get; set; }

        public string PVPlan { get; set; }

        public string Remarks { get; set; }

        public decimal? TestCostActual { get; set; }

        public int? QtyActual { get; set; }

        public string DVActual { get; set; }

        public string PVActual { get; set; }

        public string BiTestName { get; set; }

        public string BiTestCode { get; set; }

        public string Responsibility { get; set; }

        public decimal? TestCostRs { get; set; }
    }
}