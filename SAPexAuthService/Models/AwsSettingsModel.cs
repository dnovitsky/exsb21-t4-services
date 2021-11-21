using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAPexAuthService.Models
{
    public class AwsSettingsModel
    {
        public string AwsAccessKey { get; set; }

        public string AwsSecretKey { get; set; }

        public string AwsBucketName { get; set; }
        
    }
}
