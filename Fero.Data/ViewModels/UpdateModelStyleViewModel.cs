using System;
using System.Collections.Generic;
using System.Text;

namespace Fero.Data.ViewModels
{
    public class UpdateModelStyleViewModel
    {
        public UpdateModelStyleViewModel()
        {
            ModelStyle = new HashSet<CreateAccountModelStyleViewModel>();
        }
        public string Id { get; set; }
        public virtual ICollection<CreateAccountModelStyleViewModel> ModelStyle { get; set; }
    }
}
