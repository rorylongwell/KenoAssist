using System;
using System.Collections.Generic;
using System.Text;

namespace Keno.Data
{
    public class Message
    {
        public long Id { get; set; }
        public long FromUserId { get; set; }
        public long ToUserId { get; set; }
        public string MessageContent { get; set; }
        public DateTime DateSent { get; set; }
        public DateTime DateRead { get; set; }
    }
}
