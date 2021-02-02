using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectStatusAPI.Data.Projects
{
    public interface IProjectRepository : IRepository<ProjectDto>
    {
        Task<IEnumerable<ProjectDto>> GetAll();
        Task<IEnumerable<ProjectDto>> GetByName(string name);
    }
}