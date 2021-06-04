using System;
using System.Collections.Generic;

namespace Fero.Data.Models
{
    public partial class ModelCasting
    {
        public ModelCasting()
        {
            Payment = new HashSet<Payment>();
            Task = new HashSet<Task>();
        }

        public int Id { get; set; }
        public byte? ModelRate { get; set; }
        public string ModelReview { get; set; }
        public byte? CustomerRate { get; set; }
        public string CustomerReview { get; set; }
        public string ModelId { get; set; }
        public int? CastingId { get; set; }
        public bool? Status { get; set; }

        public virtual Casting Casting { get; set; }
        public virtual Model Model { get; set; }
        public virtual ICollection<Payment> Payment { get; set; }
        public virtual ICollection<Task> Task { get; set; }
    }
}
