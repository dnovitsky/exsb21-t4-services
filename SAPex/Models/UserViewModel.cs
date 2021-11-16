using System;
using System.Collections.Generic;
using BusinessLogicLayer.DtoModels;

namespace SAPex.Models
{
    public class UserViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public string Location { get; set; }

        public IList<string> Roles { get; set; }
    }
}
