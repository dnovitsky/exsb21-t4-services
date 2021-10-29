using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SAPex.Models;
using SAPex.Controllers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace SAPex
{
    [Route("api/skills")]
    [ApiController]
    public class SkillsController: AbstractController<SkillViewModel>
    {
        public SkillsController()
        {
            this.storageList = new List<SkillViewModel>() {
                new SkillViewModel(Guid.NewGuid(), "Skill 1"),
                new SkillViewModel(Guid.NewGuid(), "Skill 2"),
                new SkillViewModel(Guid.NewGuid(), "Skill 3"),
                new SkillViewModel(Guid.NewGuid(), "Skill 4")
            };
        }
    }
}
