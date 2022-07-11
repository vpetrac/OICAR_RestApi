using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OicarWebApi.Models
{
    public partial class Report
    {
        [Key]
        public int Idreport { get; set; }
        public int ReportingUserId { get; set; }
        public int ReportedUserId { get; set; }
        public int ReportReasonId { get; set; }

        [JsonIgnore]
        public virtual ReportReason ReportReason { get; set; } = null!;
        [JsonIgnore]
        public virtual AppUser ReportedUser { get; set; } = null!;
        [JsonIgnore]
        public virtual AppUser ReportingUser { get; set; } = null!;
    }
}
