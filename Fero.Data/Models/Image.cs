using System;
using System.Collections.Generic;

namespace Fero.Data.Models
{
    public partial class Image
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string Extension { get; set; }
        public DateTime UploadDate { get; set; }
        public int? CollectionId { get; set; }

        public virtual CollectionImage Collection { get; set; }
    }
}
