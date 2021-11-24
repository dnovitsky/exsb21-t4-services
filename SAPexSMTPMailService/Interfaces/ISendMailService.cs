using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAPexSMTPMailService.Interfaces
{
    public interface ISendMailService
    {
        bool MainProcess(string head, string message, string mailTo);
    }
}
