using System;
using System.Collections.Generic;

namespace Fero.Data.Models
{
    public partial class BodyPartType
    {
        public BodyPartType()
        {
            BodyPart = new HashSet<BodyPart>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<BodyPart> BodyPart { get; set; }
    }
}
