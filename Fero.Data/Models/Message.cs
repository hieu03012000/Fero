using System;
using System.Collections.Generic;

namespace Fero.Data.Models
{
    public partial class Message
    {
        //333333
        public int Id { get; set; }
        public string MsgContent { get; set; }
        public DateTime Date { get; set; }
        public bool Status { get; set; }
        public string SenderId { get; set; }
        public string ReceiverId { get; set; }
    }
}
