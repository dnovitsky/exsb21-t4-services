using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public interface IEmailBuilderService
    {
        Task<string> BuildEmailSubject(Guid sandboxId);

        Task<string> BuildEmailBody(Guid candidateId, Guid sandboxId);
    }
}
