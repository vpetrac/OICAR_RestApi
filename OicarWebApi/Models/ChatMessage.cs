using System;
using System.Collections.Generic;

namespace OicarWebApi.Models
{
    public partial class ChatMessage
    {
        public int IdchatMessage { get; set; }
        public int SendingUserId { get; set; }
        public int ReceivingUserId { get; set; }
        public DateTime SentDateTime { get; set; }
        public string Content { get; set; } = null!;

        public virtual AppUser ReceivingUser { get; set; } = null!;
        public virtual AppUser SendingUser { get; set; } = null!;
    }
}
