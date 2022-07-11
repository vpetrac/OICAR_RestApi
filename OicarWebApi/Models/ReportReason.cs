using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OicarWebApi.Models
{
    public partial class ReportReason
    {
        public ReportReason()
        {
            Reports = new HashSet<Report>();
            Suspensions = new HashSet<Suspension>();
        }

        [Key]
        public int IdreportReason { get; set; }
        public string Title { get; set; } = null!;

        [JsonIgnore]
        public virtual ICollection<Report> Reports { get; set; }
        [JsonIgnore]
        public virtual ICollection<Suspension> Suspensions { get; set; }
    }
}
