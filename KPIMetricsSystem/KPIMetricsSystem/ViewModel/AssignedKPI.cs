using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KpiMetricsSystem.ViewModel

{
    public class AssignedKPI
    {
        public string KpiId { get; set; }
        public string KpiName { get; set; }
        public bool assigned { get; set; }
    }
}