using System.Text.Json.Serialization;


namespace OicarWebApi.Entities
{
    public partial class Suspension
    {
        public int Idsuspension { get; set; }
        public int AppUserId { get; set; }
        public int ReportReasonId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public User User { get; set; } = null!;
        public ReportReason ReportReason { get; set; } = null!;
    }
}
