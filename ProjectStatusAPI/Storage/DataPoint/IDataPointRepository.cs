using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectStatusAPI.Storage.DataPoint
{
    public interface IDataPointRepository : IRepository<DataPointDto>
    {
        Task<IEnumerable<DataPointDto>> GetAllByProjectId(int projectId);
    }
}