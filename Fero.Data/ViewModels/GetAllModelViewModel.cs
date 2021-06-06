﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Fero.Data.ViewModels
{
    public class GetAllModelViewModel
    {
        public GetAllModelViewModel()
        {
            ModelStyle = new HashSet<ModelDetailModelStyleViewModel>();
        }


        public string Name { get; set; }
        public byte Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string SubAddress { get; set; }
        public string Phone { get; set; }
        public string Gifted { get; set; }
        public bool Status { get; set; }
        public virtual ICollection<ModelDetailModelStyleViewModel> ModelStyle { get; set; }
    }
}
