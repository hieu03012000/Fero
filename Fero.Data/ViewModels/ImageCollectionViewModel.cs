using System;
using System.Collections.Generic;
using System.Text;

namespace Fero.Data.ViewModels
{
    public class ImageCollectionViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gif { get; set; }
    }

    public class CreateImageCollectionViewModel
    {
        public string Name { get; set; }
    }
}
