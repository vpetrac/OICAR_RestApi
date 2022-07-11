using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OicarWebApi.Models
{
    public partial class UserLevel
    {
        public UserLevel()
        {
            AppUsers = new HashSet<AppUser>();
        }

        [Key]
        public int IduserLevel { get; set; }
        public string Title { get; set; } = null!;

        [JsonIgnore]
        public virtual ICollection<AppUser> AppUsers { get; set; }
    }
}
