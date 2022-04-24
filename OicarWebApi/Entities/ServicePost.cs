using System.Text.Json.Serialization;


namespace OicarWebApi.Entities
{
    public partial class ServicePost
    {
       
        public int IdservicePost { get; set; }
        public int AppUserId { get; set; }
        public int CategoryId { get; set; }
        public bool Active { get; set; }
        public string Title { get; set; }
        public string Comment { get; set; }
        public string Place { get; set; }
        public DateTime DateOfCreation { get; set; }
        public bool Deleted { get; set; }

        public User User { get; set; } = null!;
        public Category Category { get; set; } = null!;
        public List<ServicePostImage> ServicePostImages { get; set; }
    }
}
