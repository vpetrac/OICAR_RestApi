using System.Text.Json.Serialization;


namespace OicarWebApi.Entities
{
    public partial class Review
    {
        public int Idreview { get; set; }
        public int ReviewingUserId { get; set; }
        public int ReviewedUserId { get; set; }
        public DateTime DateOfCreation { get; set; }
        public string Comment { get; set; } = null!;

        public User ReviewedUser { get; set; } = null!;
        public User ReviewingUser { get; set; } = null!;
    }
}
