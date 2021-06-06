using System;
using System.Collections.Generic;
using System.Text;

namespace Fero.Data.ViewModels
{
    public class UpdateCustomerViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Web { get; set; }
        public string TaxCode { get; set; }
        public string Fanpage { get; set; }
        public string Phone { get; set; }
        public string Username { get; set; }
    }

    public class CustomerProfileViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Web { get; set; }
        public string TaxCode { get; set; }
        public string Fanpage { get; set; }
        public string Phone { get; set; }
        public string Username { get; set; }
    }
}
