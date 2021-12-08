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
        Task<string> AddCandidateResponseTestFileAsync(Guid candidateProccessTestTaskId, Guid candidateResponseTestFileId);
        Task<CandidateProcessTestTaskDtoModel> GetCandidateProcessTestTaskByIdAsync(Guid candidateProccessTestTaskId);
        Task<IEnumerable<CandidateProcessTestTaskDtoModel>> GetCandidateProcessTestTasksAsync();
        Task<string> UpdateCandidateProcessTestTaskAsync(Guid candidateProccessTestTaskId, UpdateCandidateProcessTestTaskDtoModel updateCandidateProccessTestTaskDM);
        Task<bool> DeleteCandidateProcessTestTaskAsync(Guid candidateProccessTestTaskId);
    }
}
