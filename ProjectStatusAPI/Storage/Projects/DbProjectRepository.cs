using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ProjectStatusAPI.Storage.Projects
{
    public class DbProjectRepository : IProjectRepository
    {
        private readonly DataContext _context;

        public DbProjectRepository(DataContext context)
        {
            _context = context;
        }

        public async Task Create(ProjectDto entity)
        {
            await _context.Projects.AddAsync(entity);
            await _context.SaveChangesAsyncWrapper();
        }

        public async Task<ProjectDto> GetById(int id)
        {
            return await _context.Projects.FindAsync(id);
        }

        public async Task<ProjectDto> Update(ProjectDto entity)
        {
            var ent = _context.Projects.Update(entity);
            await _context.SaveChangesAsyncWrapper();
            return ent.Entity;
        }

        public async Task<ProjectDto> DeleteById(int id)
        {
            var project = new ProjectDto() {Id = id};
            _context.Projects.Attach(project);
            var ent =_context.Projects.Remove(project);
            await _context.SaveChangesAsyncWrapper();
            return ent.Entity;
        }

        public async Task<IEnumerable<ProjectDto>> GetAll()
        {
            return await _context.Projects.ToListAsync();
        }

        public async Task<IEnumerable<ProjectDto>> GetByName(string name)
        {
            return await _context.Projects.Where(p => p.Name == name).ToListAsync();
        }
    }
}