using System;
using System.Collections.Generic;

namespace OicarWebApi.Models
{
    public partial class Category
    {
        public Category()
        {
            ProjectPosts = new HashSet<ProjectPost>();
            ServicePosts = new HashSet<ServicePost>();
        }

        public int Idcategory { get; set; }
        public string Title { get; set; } = null!;

        public virtual ICollection<ProjectPost> ProjectPosts { get; set; }
        public virtual ICollection<ServicePost> ServicePosts { get; set; }
    }
}
