﻿using System;
using System.Collections.Generic;

namespace OicarWebApi.Models
{
    public partial class Review
    {
        public int Idreview { get; set; }
        public int ReviewingUserId { get; set; }
        public int ReviewedUserId { get; set; }
        public DateTime DateOfCreation { get; set; }
        public string Comment { get; set; } = null!;

        public virtual User ReviewedUser { get; set; } = null!;
        public virtual User ReviewingUser { get; set; } = null!;
    }
}
