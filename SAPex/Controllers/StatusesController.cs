﻿using Microsoft.AspNetCore.Mvc;
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
    public class StatusesController : AbstractController<StatusViewModel>
    {
    }
}
