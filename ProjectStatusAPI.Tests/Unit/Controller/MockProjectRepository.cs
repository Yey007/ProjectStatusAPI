using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MoreLinq;
using ProjectStatusAPI.Storage.Projects;

namespace ProjectStatusAPI.Tests.Unit.Controller
{
    public class MockProjectRepository : IProjectRepository
    {
        public List<ProjectDto> FakeData { get; } = new()
        {
            new ProjectDto
            {
                Id = 1,
                Name = "Hello"
            },
            new ProjectDto
            {
                Id = 2,
                Name = "World!"
            },
            new ProjectDto
            {
                Id = 3,
                Name = "A Project"
            }
        };
        
        public Task Create(ProjectDto entity)
        {
            int idToInsert = FakeData.Max(p => p.Id) + 1;
            if (entity.Id == 0)
            {
                entity.Id = idToInsert;
            }
            FakeData.Add(entity);
            return Task.CompletedTask;
        }

        public Task<ProjectDto> GetById(int id)
        {
            return Task.FromResult(FakeData.First(p => p.Id == id));
        }

        public Task<ProjectDto> Update(ProjectDto entity)
        {
            var proj = FakeData.First(p => p.Id == entity.Id);
            int index = FakeData.IndexOf(proj);
            FakeData[index] = entity;
            return Task.FromResult(entity);
        }

        public Task<ProjectDto> DeleteById(int id)
        {
            var proj = FakeData.First(p => p.Id == id);
            FakeData.RemoveAt(id);
            return Task.FromResult(proj);
        }

        public Task<IEnumerable<ProjectDto>> GetAll()
        {
            return Task.FromResult(FakeData.AsEnumerable());
        }

        public Task<IEnumerable<ProjectDto>> GetByName(string name)
        {
            return Task.FromResult(FakeData.Where(p => p.Name == name));
        }
    }
}