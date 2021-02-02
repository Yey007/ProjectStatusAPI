using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectStatusAPI.Exceptions.API;
using ProjectStatusAPI.Mapping;
using ProjectStatusAPI.Storage.DataPoint;

namespace ProjectStatusAPI.API.DataPoint
{
    [ApiController]
    [Route("/projects/{projectId}/stats")]
    public class ProjectStatsController : Controller
    {
        private readonly IDataPointRepository _repository;

        public ProjectStatsController(IDataPointRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetDataPoints([FromRoute] int projectId)
        {
            var all = await _repository.GetAllByProjectId(projectId);
            return Ok(all.Select(t => t.ToDataPoint()));
        }

        [HttpPost]
        public async Task<IActionResult> AddDataPoint([FromRoute] int projectId, [FromBody] DataPointCreateInfo info)
        {
            if (info.TimeCreate is null)
            {
                throw new RequestFieldMissingException(nameof(info.TimeCreate));
            }

            if (info.Value is null)
            {
                throw new RequestFieldMissingException(nameof(info.Value));
            }
            
            await _repository.Create(info.ToDataPointDto(projectId));
            return Ok();
        }
    }
}