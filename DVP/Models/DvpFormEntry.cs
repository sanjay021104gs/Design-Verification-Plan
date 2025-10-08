using System;
using System.ComponentModel.DataAnnotations;


// Models/DvpFormEntry.cs
namespace DVP.Models
{
    public class DvpFormEntry
    {
        [Key]
        public int Id { get; set; }
        public string Customer { get; set; }
        public int EarnJrn { get; set; }
        public string ProjectName { get; set; }
        public int DvpNumber { get; set; }
        public string BrakeSize { get; set; }
        public string Category { get; set; }
        public string Remarks { get; set; }
        public int RevisionNo { get; set; }
        public string FrontRear { get; set; }
        public DateTime DvpDate { get; set; }
        public string FrictionGrade { get; set; }
        public DateTime DvpRDate { get; set; }
        public string Reason { get; set; }
    }


}