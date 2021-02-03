using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectStatusAPI.Storage.Projects
{
    public interface IProjectRepository : IRepository<ProjectDto>
    {
        Task<IEnumerable<ProjectDto>> GetAll();
        Task<IEnumerable<ProjectDto>> GetByName(string name);
    }
}