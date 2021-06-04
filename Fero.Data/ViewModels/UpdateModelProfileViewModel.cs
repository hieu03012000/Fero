using System;

namespace Fero.Data.ViewModels
{
    public class UpdateModelProfileViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public byte Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string SubAddress { get; set; }
        public string Phone { get; set; }
        public string Username { get; set; }
        public string Gifted { get; set; }
        public string Password { get; set; }
    }
}
