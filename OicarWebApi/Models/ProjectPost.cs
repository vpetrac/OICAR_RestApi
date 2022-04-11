using System;
using System.Collections.Generic;

namespace OicarWebApi.Models
{
    public partial class ProjectPost
    {
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

        public virtual AppUser AppUser { get; set; } = null!;
        public virtual Category Category { get; set; } = null!;
    }
}
