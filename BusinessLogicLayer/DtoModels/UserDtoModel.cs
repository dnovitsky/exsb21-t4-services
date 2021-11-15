using System;
using System.Collections.Generic;
using BusinessLogicLayer.DtoModels.BaseModels;

namespace BusinessLogicLayer.DtoModels
{
    public class UserDtoModel : ItemDtoModel
    {
       public string Surname { get; set; }
       public string Email { get; set; }
       public string Location { get; set; }
       public IList<string> Roles { get; set; }
    }
}
