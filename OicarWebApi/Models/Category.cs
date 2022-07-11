using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OicarWebApi.Models
{
    public partial class Category
    {
        public Category()
        {
            ProjectPosts = new HashSet<ProjectPost>();
            ServicePosts = new HashSet<ServicePost>();
        }
        [Key]
        public int Idcategory { get; set; }
        public string Title { get; set; } = null!;

        [JsonIgnore]
        public virtual ICollection<ProjectPost> ProjectPosts { get; set; }
        [JsonIgnore]
        public virtual ICollection<ServicePost> ServicePosts { get; set; }
    }
}
