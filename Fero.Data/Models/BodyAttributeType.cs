using System;
using System.Collections.Generic;

namespace Fero.Data.Models
{
    public partial class BodyAttributeType
    {
        public BodyAttributeType()
        {
            BodyAttribute = new HashSet<BodyAttribute>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Measure { get; set; }

        public virtual ICollection<BodyAttribute> BodyAttribute { get; set; }
    }
}
