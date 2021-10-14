using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using exsb21_t4_services.Models;
using exsb21_t4_services.Models.RestModels;
using exsb21_t4_services.Repository;
using exsb21_t4_services.Repository.IRepository;
using exsb21_t4_services.Repository.RestRepository;
using Microsoft.AspNetCore.Mvc;

namespace exsb21_t4_services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly ISkillRepository _skillRepository;
        private readonly ISpecializationRepository _specializationRepository;
        private readonly ICandidateRepository _candidateRepository;
        private readonly IRestRepository _restRepository;


        public HomeController(ISkillRepository skillRepository, ISpecializationRepository specializationRepository, ICandidateRepository candidateRepository, IRestRepository restRepository)
        {
            _skillRepository = skillRepository;
            _specializationRepository = specializationRepository;
            _candidateRepository = candidateRepository;
            _restRepository = restRepository;
        }

        [HttpGet("skills")]
        public ActionResult<IEnumerable<Skill>> GetSkills()
        {
            return _skillRepository.FindAll(); ;
        }
         
        [HttpPost("skill")]
        public ActionResult<Skill> PostSkill([FromBody] Skill skill)
        {
            return _skillRepository.Add(skill); ;
        }

        [HttpGet("specializations")]
        public ActionResult<IEnumerable<Specialization>> GetSpecializations()
        {
            return _specializationRepository.FindAll(); ; 
        }


        [HttpPost("specialization")]
        public ActionResult<Specialization> Post([FromBody] Specialization specialization)
        {
            return _specializationRepository.Add(specialization); ;
        }


        [HttpGet("candidates")]
        public ActionResult<IEnumerable<Candidate>> GetCandidates()
        {
            return _candidateRepository.FindAll(); ;
        }

        [HttpPost("candidate")]
        public ActionResult<Candidate> Post([FromBody] Candidate candidate)
        {
            return _candidateRepository.Add(candidate); ;
        }

        [HttpGet("regions")]
        public ActionResult<RestCountryResponse> GetRegions()
        {
            return  _restRepository.GetCountry();
        }

        //Hello World!!!

    }
}