using RaidPlanner.Bll.ObjectModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RaidPlanner.Bll.Services.IServices
{
    public interface IJobService
    {
        Task<IEnumerable<JobModel>> GetAllJobsAsync();
        Task<JobModel> GetJobByIdAsync(int id);
        Task<JobModel> CreateJobAsync(JobModel jobModel);
        Task<JobModel> UpdateJobAsync(JobModel jobModel);
        Task<bool> DeleteJobAsync(int id);
    }
}
