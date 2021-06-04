using System;
using System.Collections.Generic;

namespace Fero.Data.Models
{
    public partial class TattooType
    {
        public TattooType()
        {
            Tattoo = new HashSet<Tattoo>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Tattoo> Tattoo { get; set; }
    }
}
