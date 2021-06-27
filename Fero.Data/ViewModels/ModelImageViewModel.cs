using System;
using System.Collections.Generic;
using System.Text;

namespace Fero.Data.ViewModels
{
    public class ModelImageViewModel
    {
        public int Id { get; set; }
        public string Extension { get; set; }
        public string FileName { get; set; }
        public DateTime UploadDate { get; set; }
    }
}
