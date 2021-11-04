using System;
using Microsoft.AspNetCore.Mvc;

namespace SAPex.Controllers.Authorization
{
    [Route("/google/authorization")]
    [ApiController]
    public class GoogleAuthorizationController : ControllerBase
    {
        public GoogleAuthorizationController()
        {
        }
    }
}
