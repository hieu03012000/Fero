using System;
using System.Collections.Generic;

namespace Fero.Data.Models
{
    public partial class BrandCategory
    {
        public BrandCategory()
        {
            Brand = new HashSet<Brand>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Brand> Brand { get; set; }
    }
}
