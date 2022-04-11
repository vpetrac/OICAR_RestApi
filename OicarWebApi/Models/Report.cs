using System;
using System.Collections.Generic;

namespace OicarWebApi.Models
{
    public partial class Report
    {
        public int Idreport { get; set; }
        public int ReportingUserId { get; set; }
        public int ReportedUserId { get; set; }
        public int ReportReasonId { get; set; }

        public virtual ReportReason ReportReason { get; set; } = null!;
        public virtual AppUser ReportedUser { get; set; } = null!;
        public virtual AppUser ReportingUser { get; set; } = null!;
    }
}
