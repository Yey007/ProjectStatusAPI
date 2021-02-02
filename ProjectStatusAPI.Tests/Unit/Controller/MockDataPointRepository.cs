using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectStatusAPI.Storage.DataPoint;
using ProjectStatusAPI.Storage.Projects;

namespace ProjectStatusAPI.Tests.Unit.Controller
{
    public class MockDataPointRepository : IDataPointRepository
    {
        public List<DataPointDto> FakeData { get; } = new()
        {
            new DataPointDto
            {
                Id = 1,
                Value = 10,
                TimeCreate = new DateTime(2021, 01, 30),
                ProjectId = 1
            },
            new DataPointDto
            {
                Id = 2,
                Value = 20,
                TimeCreate = new DateTime(2020, 01, 30),
                ProjectId = 2
            },
            new DataPointDto
            {
                Id = 3,
                Value = 30,
                TimeCreate = new DateTime(2019, 01, 30),
                ProjectId = 2
            }
        };
        
        public Task Create(DataPointDto entity)
        {
            int idToInsert = FakeData.Max(p => p.Id) + 1;
            if (entity.Id == 0)
            {
                entity.Id = idToInsert;
            }
            FakeData.Add(entity);
            return Task.CompletedTask;
        }

        public Task<DataPointDto> GetById(int id)
        {
            return Task.FromResult(FakeData.First(p => p.Id == id));
        }

        public Task<DataPointDto> Update(DataPointDto entity)
        {
            var proj = FakeData.First(p => p.Id == entity.Id);
            int index = FakeData.IndexOf(proj);
            FakeData[index] = entity;
            return Task.FromResult(entity);
        }

        public Task<DataPointDto> DeleteById(int id)
        {
            var proj = FakeData.First(p => p.Id == id);
            FakeData.RemoveAt(id);
            return Task.FromResult(proj);
        }

        public Task<IEnumerable<DataPointDto>> GetAllByProjectId(int projectId)
        {
            return Task.FromResult(FakeData.Where(d => d.ProjectId == projectId));
        }
    }
}