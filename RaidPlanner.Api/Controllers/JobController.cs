using Microsoft.AspNetCore.Mvc;
using RaidPlanner.Api.Dto;
using RaidPlanner.Bll.Services.IServices;
using Mapster;
using RaidPlanner.Bll.ObjectModels;

namespace RaidPlanner.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private readonly IJobService _jobService;

        public JobController(IJobService jobService)
        {
            _jobService = jobService;
        }

        // GET: api/Job
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JobDto>>> GetJobs()
        {
            var jobs = await _jobService.GetAllJobsAsync();
            return Ok(jobs.Adapt<IEnumerable<JobDto>>());
        }

        // GET: api/Job/5
        [HttpGet("{id}")]
        public async Task<ActionResult<JobDto>> GetJob(int id)
        {
            var job = await _jobService.GetJobByIdAsync(id);

            if (job == null)
            {
                return NotFound();
            }

            return Ok(job.Adapt<JobDto>());
        }

        // POST: api/Job
        [HttpPost]
        public async Task<ActionResult<JobDto>> PostJob(JobDto jobDto)
        {
            var jobModel = jobDto.Adapt<JobModel>();
            var createdJob = await _jobService.CreateJobAsync(jobModel);
            return CreatedAtAction("GetJob", new { id = createdJob.Id }, createdJob.Adapt<JobDto>());
        }

        // PUT: api/Job/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJob(int id, JobDto jobDto)
        {
            if (id != jobDto.Id)
            {
                return BadRequest();
            }

            var jobModel = jobDto.Adapt<JobModel>();
            await _jobService.UpdateJobAsync(jobModel);
            return NoContent();
        }

        // DELETE: api/Job/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJob(int id)
        {
            var deleted = await _jobService.DeleteJobAsync(id);
            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
