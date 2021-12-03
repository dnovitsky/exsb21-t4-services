﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public interface ITestTaskTokenBusinessService
    {
        public string GetJwtToken(string email);
        public string GetEmailByToken(string JWTtoken);
    }
}
