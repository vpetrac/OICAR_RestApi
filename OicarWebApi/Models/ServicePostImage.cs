using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OicarWebApi.Models
{
    public partial class ServicePostImage
    {
        [Key]
        public int IdservicePostImage { get; set; }
        public int ServicePostId { get; set; }
        public byte[] Picture { get; set; } = null!;

        [JsonIgnore]
        public virtual ServicePost ServicePost { get; set; } = null!;
    }
}
