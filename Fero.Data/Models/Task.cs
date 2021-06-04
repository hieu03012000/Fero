using System;
using System.Collections.Generic;

namespace Fero.Data.Models
{
    public partial class Task
    {
        public int Id { get; set; }
        public DateTime StartAt { get; set; }
        public DateTime EndAt { get; set; }
        public byte Status { get; set; }
        public int? ModelCastingId { get; set; }

        public virtual ModelCasting ModelCasting { get; set; }
    }
}
