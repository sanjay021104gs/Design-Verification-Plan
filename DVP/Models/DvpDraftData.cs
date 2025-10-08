using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DVP.Models
{
    public class DvpDraftData
    {
        [Key]
        public int Id { get; set; }
        public string Customer { get; set; }
        public string EarnJrnNo { get; set; }
        public string ProjectName { get; set; }
        public string DvpNumber { get; set; }
        public string BrakeSize { get; set; }
        public string Category { get; set; }
        public string Remarks { get; set; }
        public string RevisionNo { get; set; }
        public string FrontRear { get; set; }
        public string DvpDate { get; set; }
        public string FrictionGrade { get; set; }
        public string DvpRDate { get; set; }
        public string Reason { get; set; }
   
    }
}