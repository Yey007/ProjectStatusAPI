using System.Collections.Generic;
using System.Threading.Tasks;
using ProjectStatusAPI.Exceptions.Data;

namespace ProjectStatusAPI.Storage.DataPoint
{
    public class DbDataPointRepository : IDataPointRepository
    {
        
        private readonly DataContext _context;

        public DbDataPointRepository(DataContext context)
        {
            _context = context;
        }
        
        public async Task Create(DataPointDto entity)
        {
            var project = await _context.Projects.FindAsync(entity.ProjectId);
            if (project is null)
            {
                throw new ResourceNotFoundException($"Project with id {entity.ProjectId}");
            }

            project.DataPoints.Add(entity);
            await _context.SaveChangesAsyncWrapper();
        }

        public async Task<DataPointDto> GetById(int id)
        {
            return await _context.DataPoints.FindAsync(id);
        }

        public async Task<DataPointDto> Update(DataPointDto entity)
        {
            var ent = _context.DataPoints.Update(entity);
            await _context.SaveChangesAsyncWrapper();
            return ent.Entity;
        }

        public async Task<DataPointDto> DeleteById(int id)
        {
            var dataPoint = new DataPointDto() {Id = id};
            _context.DataPoints.Attach(dataPoint);
            var ent =_context.DataPoints.Remove(dataPoint);
            await _context.SaveChangesAsyncWrapper();
            return ent.Entity;
        }

        public async Task<IEnumerable<DataPointDto>> GetAllByProjectId(int projectId)
        {
            var project = await _context.Projects.FindAsync(projectId);
            if (project is null)
            {
                throw new ResourceNotFoundException($"Project with id {projectId}");
            }
            return project.DataPoints;
        }
    }
}