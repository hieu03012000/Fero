using System;
using System.Collections.Generic;

namespace Fero.Data.Models
{
    public partial class BodyAttribute
    {
        public int Id { get; set; }
        public decimal? Value { get; set; }
        public int? BodyAttTypeId { get; set; }
        public int? BodyPartId { get; set; }

        public virtual BodyAttributeType BodyAttType { get; set; }
        public virtual BodyPart BodyPart { get; set; }
    }
}
