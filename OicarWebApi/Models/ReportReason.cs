using System;
using System.Collections.Generic;

namespace OicarWebApi.Models
{
    public partial class ReportReason
    {
        public ReportReason()
        {
            Reports = new HashSet<Report>();
            Suspensions = new HashSet<Suspension>();
        }

        public int IdreportReason { get; set; }
        public string Title { get; set; } = null!;

        public virtual ICollection<Report> Reports { get; set; }
        public virtual ICollection<Suspension> Suspensions { get; set; }
    }
}
