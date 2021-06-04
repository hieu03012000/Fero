using System;
using System.Collections.Generic;

namespace Fero.Data.Models
{
    public partial class Notification
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public TimeSpan Time { get; set; }
        public DateTime Date { get; set; }
        public string ModelId { get; set; }
        public string CustomerId { get; set; }
    }
}
