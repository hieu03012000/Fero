using System;
using System.Collections.Generic;
using System.Text;

namespace Fero.Data.ViewModels
{
    public class CreateFreeTimeViewModel
    {
        public DateTime StartAt { get; set; }
        public DateTime EndAt { get; set; }
        public string ModelId { get; set; }
    }

    public class CreateTaskViewModel
    {
        public DateTime StartAt { get; set; }
        public DateTime EndAt { get; set; }
        public int? CastingId { get; set; }
        public string ModelId { get; set; }
    }
}
