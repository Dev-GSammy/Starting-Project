using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartingProjectDemo.Models
{
    public class Programs
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string? Summary { get; set; }
        public string programDescription { get; set; }
        public List<Skills>? Skills { get; set; }
        public string? Benefits { get; set; }
        public string? applicationCriteria { get; set; }
        public string programType { get; set; }
        public DateTime? programStartDate { get; set; }
        public DateTime applicationOpenDate { get; set; }
        public DateTime applicationCloseDate { get; set; }
        public string? Duration { get; set; }
        public string programLocation { get; set; }
        public string minQualification { get; set; }
        public int? maxApplications { get; set; }



    }
}
