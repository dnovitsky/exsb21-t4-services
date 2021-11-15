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

        public static explicit operator UserDtoModel(UserViewModel model)
        {
            UserDtoModel dto = new ();
            dto.Id = model.Id;
            dto.Name = model.Name;
            dto.Surname = model.Surname;
            dto.Email = model.Email;
            dto.Location = model.Location;
            dto.Roles = model.Roles;
            return dto;
        }

        public static implicit operator UserViewModel(UserDtoModel dto)
        {
            UserViewModel model = new ();
            model.Id = dto.Id;
            model.Name = dto.Name;
            model.Surname = dto.Surname;
            model.Email = dto.Email;
            model.Location = dto.Location;
            model.Roles = dto.Roles;
            return model;
        }
    }
}
