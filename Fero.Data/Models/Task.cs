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
        public int? CastingId { get; set; }
        public string ModelId { get; set; }

        public virtual Casting Casting { get; set; }
        public virtual Model Model { get; set; }
    }
}
