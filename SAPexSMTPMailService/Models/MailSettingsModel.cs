using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAPexSMTPMailService.Models
{
    public class MailSettingsModel
    {
        public string SMTPAddress { get; set; }
        public string SMTPPassword { get; set; }
        public string SMTPHost { get; set; }
        public int SMTPPort { get; set; }

    }
}
