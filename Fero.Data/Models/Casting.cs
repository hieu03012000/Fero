using System;
using System.Collections.Generic;

namespace Fero.Data.Models
{
    public partial class Casting
    {
        public Casting()
        {
            ApplyCasting = new HashSet<ApplyCasting>();
            ModelCasting = new HashSet<ModelCasting>();
            SubscribeCasting = new HashSet<SubscribeCasting>();
            Task = new HashSet<Task>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? MonopolyTime { get; set; }
        public DateTime? OpenTime { get; set; }
        public DateTime? CloseTime { get; set; }
        public byte Status { get; set; }
        public string CustomerId { get; set; }
        public int? BrandId { get; set; }
        public decimal? Salary { get; set; }

        public virtual Brand Brand { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual ICollection<ApplyCasting> ApplyCasting { get; set; }
        public virtual ICollection<ModelCasting> ModelCasting { get; set; }
        public virtual ICollection<SubscribeCasting> SubscribeCasting { get; set; }
        public virtual ICollection<Task> Task { get; set; }
    }
}
