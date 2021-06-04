using System;
using System.Collections.Generic;

namespace Fero.Data.Models
{
    public partial class CollectionImage
    {
        public CollectionImage()
        {
            Image = new HashSet<Image>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? BodyPartId { get; set; }

        public virtual BodyPart BodyPart { get; set; }
        public virtual ICollection<Image> Image { get; set; }
    }
}
