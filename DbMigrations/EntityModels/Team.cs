using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbMigrations.EntityModels
{
    public class Team
    {
        public int Id { get; set; }
        public List<Sandbox> SandboxId { get; set; }
        public string Name { get; set; }
       
    }
}
