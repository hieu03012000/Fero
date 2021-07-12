using System;
using System.Collections.Generic;
using System.Text;

namespace Fero.Data.ViewModels
{
    public class StaffViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }

    public class StaffLoginViewModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
