using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SAPex.Models
{
    public class TestResultsViewModel
    {
        public string Email { get; set; }

        public Guid FileId { get; set; }

        public string Token { get; set; }
    }
}
