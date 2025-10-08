using System;
using System.ComponentModel.DataAnnotations;

namespace DVP.Models
{
    public class ApprovalSignatures
    {
        [Key]
        public int Id { get; set; }

        
        public int DvpNumber { get; set; }

      
        public string SignAse { get; set; }

        public DateTime? DateAse { get; set; }

        public string GroupAse { get; set; }

        public string SignGroupAse { get; set; }

       
        public string SignDesign { get; set; }

        public DateTime? DateDesign { get; set; }

        public string GroupDesign { get; set; }

        public string SignGroupDesign { get; set; }

        
        public string SignDyno { get; set; }

        public DateTime? DateDyno { get; set; }

        public string GroupDyno { get; set; }

        public string SignGroupDyno { get; set; }
    }
}
