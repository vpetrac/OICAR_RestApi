using System.Text.Json.Serialization;


namespace OicarWebApi.Entities
{

    public class User
    {
        public int IdUser { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Guid Salt { get; set; }
        public bool Deleted { get; set; }

        [JsonIgnore]
        public string PasswordHash { get; set; }


    }
}