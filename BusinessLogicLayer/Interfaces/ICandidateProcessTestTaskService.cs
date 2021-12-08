using BusinessLogicLayer.DtoModels;
using DbMigrations.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public interface ICandidateProcessTestTaskService
    {
        Task<CandidateProcessTestTaskDtoModel> CreateCandidateProcessTestTaskAsync(CandidateProcessTestTaskDtoModel candidateProccessTestTaskDM);
        Task<string> AddCandidateResponseTestFileAsync(Guid candidateProccessId, Guid candidateResponseTestFileId);
        Task<CandidateProcessTestTaskDtoModel> GetCandidateProcessTestTasksByCandidateProcessIdAsync(Guid candidateProcessId);
        Task<IEnumerable<CandidateProcessTestTaskDtoModel>> GetCandidateProcessTestTasksAsync();
        Task<string> UpdateCandidateProcessTestTaskAsync(Guid candidateProccessTestTaskId, UpdateCandidateProcessTestTaskDtoModel updateCandidateProccessTestTaskDM);
        Task<bool> DeleteCandidateProcessTestTaskAsync(Guid candidateProccessTestTaskId);
    }
}
