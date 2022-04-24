using System.Text.Json.Serialization;


namespace OicarWebApi.Entities
{
    public partial class ReportReason
    {

        public int IdreportReason { get; set; }
        public string Title { get; set; } = null!;

        public List<Report> Reports { get; set; }
        public List<Suspension> Suspensions { get; set; }
    }
}
