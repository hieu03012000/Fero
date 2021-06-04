using System;
using System.Collections.Generic;

namespace Fero.Data.Models
{
    public partial class Tattoo
    {
        public int Id { get; set; }
        public string Position { get; set; }
        public string Description { get; set; }
        public int? TattooTypeId { get; set; }
        public int? BodyPartId { get; set; }

        public virtual BodyPart BodyPart { get; set; }
        public virtual TattooType TattooType { get; set; }
    }
}
