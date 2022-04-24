using System.Text.Json.Serialization;


namespace OicarWebApi.Entities
{
    public partial class ServicePostImage
    {
        public int IdservicePostImage { get; set; }
        public int ServicePostId { get; set; }
        public string FilePath { get; set; } = null!;

        public virtual ServicePost ServicePost { get; set; } = null!;
    }
}
