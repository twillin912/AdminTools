using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminTools.Data.Models
{
    public class Change
    {
        public int Id { get; set; }
        public string Synopsis { get; set; }
        public string Description { get; set; }
        public DateTime ScheduledDate { get; set; }
        public string BackoutPlan { get; set; }
        public RiskLevel Risk { get; set; }
    }

    public class RiskLevel
    {
        public int Id { get; set; }
        public string Risk { get; set; }
    }
}
