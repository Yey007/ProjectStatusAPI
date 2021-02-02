using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectStatusAPI.Exceptions.API;

using ProjectStatusAPI.Mapping;
using ProjectStatusAPI.Storage.Projects;

namespace ProjectStatusAPI.API.Projects
{
    [ApiController]
    [Route("/projects")]
    public class ProjectsController : Controller
    {
        private readonly IProjectRepository _repository;

        public ProjectsController(IProjectRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetProjects()
        {
            var all = await _repository.GetAll();
            var allAsProjects = all.Select(p => p.ToProject());
            return Ok(allAsProjects);
        }

        [HttpGet]
        [Route("{projectId}")]
        public async Task<IActionResult> GetProject([FromRoute] int projectId)
        {
            var dto = await _repository.GetById(projectId);
            return Ok(dto.ToProject());
        }                                                                         

        [HttpPost]
        public async Task<IActionResult> CreateProject([FromBody] ProjectCreateInfo info)
        {
            if (info.Name is null)
            {
                throw new RequestFieldMissingException(nameof(info.Name));
            }
            
            await _repository.Create(info.ToProjectDto());
            return Ok();
        }
    }
}