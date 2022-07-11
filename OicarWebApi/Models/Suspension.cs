using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OicarWebApi.Models
{
    public partial class Suspension
    {
        [Key]
        public int Idsuspension { get; set; }
        public int AppUserId { get; set; }
        public int ReportReasonId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        [JsonIgnore]
        public virtual AppUser AppUser { get; set; } = null!;
        [JsonIgnore]
        public virtual ReportReason ReportReason { get; set; } = null!;
    }
}
