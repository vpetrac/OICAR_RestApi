using System.Text.Json.Serialization;


namespace OicarWebApi.Entities
{
    public partial class Report
    {
        public int Idreport { get; set; }
        public int ReportingUserId { get; set; }
        public int ReportedUserId { get; set; }
        public int ReportReasonId { get; set; }

        public ReportReason ReportReason { get; set; }
        public User ReportedUser { get; set; }
        public User ReportingUser { get; set; }
    }
}
