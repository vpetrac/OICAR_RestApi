using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OicarWebApi.Models
{
    public partial class Review
    {
        [Key]
        public int Idreview { get; set; }
        public int ReviewingUserId { get; set; }
        public int ReviewedUserId { get; set; }
        public DateTime DateOfCreation { get; set; }
        public string Comment { get; set; } = null!;
        [JsonIgnore]
        public virtual AppUser ReviewedUser { get; set; } = null!;
        [JsonIgnore]
        public virtual AppUser ReviewingUser { get; set; } = null!;
    }
}
