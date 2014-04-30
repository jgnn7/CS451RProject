using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KpiMetricsSystem.Models
{
    public class KPI
    {
        public string ID { get; set; }
        public string KPIName { get; set; }
        public virtual ICollection<ApplicationUser> Users { get; set; }
    }
}