using System;
using System.Collections.Generic;

namespace OicarWebApi.Models
{
    public partial class ServicePostImage
    {
        public int IdservicePostImage { get; set; }
        public int ServicePostId { get; set; }
        public string FilePath { get; set; } = null!;

        public virtual ServicePost ServicePost { get; set; } = null!;
    }
}
