using System;
using System.Collections.Generic;

namespace Fero.Data.Models
{
    public partial class BodyPart
    {
        public BodyPart()
        {
            BodyAttribute = new HashSet<BodyAttribute>();
            CollectionImage = new HashSet<CollectionImage>();
            Tattoo = new HashSet<Tattoo>();
        }

        public int Id { get; set; }
        public bool? IsFeatured { get; set; }
        public string ModelId { get; set; }
        public int? BodyPartTypeId { get; set; }

        public virtual BodyPartType BodyPartType { get; set; }
        public virtual Model Model { get; set; }
        public virtual ICollection<BodyAttribute> BodyAttribute { get; set; }
        public virtual ICollection<CollectionImage> CollectionImage { get; set; }
        public virtual ICollection<Tattoo> Tattoo { get; set; }
    }
}
