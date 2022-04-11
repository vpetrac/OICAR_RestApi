using System;
using System.Collections.Generic;

namespace OicarWebApi.Models
{
    public partial class Suspension
    {
        public int Idsuspension { get; set; }
        public int AppUserId { get; set; }
        public int ReportReasonId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public virtual AppUser AppUser { get; set; } = null!;
        public virtual ReportReason ReportReason { get; set; } = null!;
    }
}
