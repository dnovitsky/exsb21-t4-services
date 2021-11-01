using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using SAPex.Models;
using SAPex.Controllers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SAPex
{
    [Route("api/statuses")]
    [ApiController]
    public class StatusesController : AbstractNameController<StatusViewModel>
    {
        protected override bool IsValidPostData(StatusViewModel requestData)
        {
            return requestData.name != null;
        }
        protected override bool IsValidPutData(StatusViewModel requestData)
        {
            return requestData.name != null;
        }
        protected override void UpdateFields(StatusViewModel responce, StatusViewModel requestData)
        {
            responce.name = requestData.name != null ? requestData.name : responce.name;
        }
    }
}
