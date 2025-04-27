using Mapster;
using RaidPlanner.Bll.ObjectModels;
using RaidPlanner.DAL.Models;
using RaidPlanner.DAL.Repository.IRepository;
using RaidPlanner.Bll.Services.IServices;

namespace RaidPlanner.Bll.Services
{
    public class JobService : IJobService
    {
        private readonly IJobRepository _jobRepository;

        public JobService(IJobRepository jobRepository)
        {
            _jobRepository = jobRepository;
        }

        public async Task<IEnumerable<JobModel>> GetAllJobsAsync()
        {
            var jobs = await _jobRepository.GetAllAsync();
            return jobs.Adapt<IEnumerable<JobModel>>();
        }

        public async Task<JobModel> GetJobByIdAsync(int id)
        {
            var job = await _jobRepository.GetByIdAsync(id);
            return job?.Adapt<JobModel>();
        }

        public async Task<JobModel> CreateJobAsync(JobModel jobModel)
        {
            var job = jobModel.Adapt<Job>();
            await _jobRepository.AddAsync(job);
            return job.Adapt<JobModel>();
        }

        public async Task<JobModel> UpdateJobAsync(JobModel jobModel)
        {
            var job = jobModel.Adapt<Job>();
            await _jobRepository.UpdateAsync(job);
            return job.Adapt<JobModel>();
        }

        public async Task<bool> DeleteJobAsync(int id)
        {
            var job = await _jobRepository.GetByIdAsync(id);
            if (job != null)
            {
                await _jobRepository.DeleteAsync(job);
                return true;
            }
            return false;
        }
    }
}
