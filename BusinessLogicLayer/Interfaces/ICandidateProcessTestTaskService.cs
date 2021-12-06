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
        Task<CandidateProccessTestTaskDtoModel> CreateCandidateProcessTestTaskAsync(CandidateProccessTestTaskDtoModel candidateProccessTestTaskDM);
        Task<CandidateProccessTestTaskDtoModel> GetCandidateProcessTestTaskByIdAsync(Guid candidateProccessTestTaskId);
        Task<IEnumerable<CandidateProccessTestTaskDtoModel>> GetCandidateProcessTestTasksAsync();
        Task<CandidateProccessTestTaskDtoModel> UpdateCandidateProcessTestTaskAsync(Guid candidateProccessTestTaskId, UpdateCandidateProccessTestTaskDtoModel updateCandidateProccessTestTaskDM);
        Task<bool> DeleteCandidateProcessTestTaskAsync(Guid candidateProccessTestTaskId);
    }
}
