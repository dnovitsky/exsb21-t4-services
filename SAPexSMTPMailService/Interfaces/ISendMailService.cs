using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAPexSMTPMailService.Interfaces
{
    public interface ISendMailService
    {
        Task<bool> MainProcess(Guid candidateId, Guid sandboxId);
    }
}
