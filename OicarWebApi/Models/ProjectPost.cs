using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OicarWebApi.Models
{
    public partial class ProjectPost
    {
        [Key]
        public int IdprojectPost { get; set; }
        public int AppUserId { get; set; }
        public int CategoryId { get; set; }
        public bool? Active { get; set; }
        public string Title { get; set; } = null!;
        public string Comment { get; set; } = null!;
        public string? Place { get; set; }
        public DateTime DateOfCreation { get; set; }
        public int DurationInMonths { get; set; }
        public int NumberOfTeammates { get; set; }
        public bool Deleted { get; set; }

        [JsonIgnore]
        public virtual AppUser AppUser { get; set; } = null!;
        [JsonIgnore]
        public virtual Category Category { get; set; } = null!;
    }
}
