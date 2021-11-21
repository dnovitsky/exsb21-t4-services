using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DtoModels
{
    public class UserSandboxDtoModel
    {
        public Guid Id { get; set; }
        public Guid SandboxId { get; set; }
        public Guid UserId { get; set; }
    }
}
