using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectStatusAPI.API.DataPoint;
using ProjectStatusAPI.Exceptions.API;
using Xunit;

namespace ProjectStatusAPI.Tests.Unit.Controller
{
    public class ProjectStatsControllerTests
    {
        [Fact]
        public async Task GetDataPointsOneSuccess()
        {
            var repo = new MockDataPointRepository();
            var controller = new ProjectStatsController(repo);
            var result = await controller.GetDataPoints(1) as OkObjectResult;
            Assert.NotNull(result);

            var list = ((IEnumerable<DataPoint>) result.Value).ToList();
            Assert.NotNull(list);
            Assert.Single(list);

            var expected = repo.FakeData.First(d => d.Id == 1);
            var actual = list[0];

            Assert.Equal(expected.Id, actual.Id);
            Assert.Equal(expected.Value, actual.Value);
            Assert.Equal(expected.TimeCreate, actual.TimeCreate);
        }

        [Fact]
        public async Task GetDataPointsMultipleSuccess()
        {
            var repo = new MockDataPointRepository();
            var controller = new ProjectStatsController(repo);
            var result = await controller.GetDataPoints(2) as OkObjectResult;
            Assert.NotNull(result);

            var list = ((IEnumerable<DataPoint>) result.Value).ToList();
            Assert.NotNull(list);
            Assert.Equal(2, list.Count);

            var expected = repo.FakeData.Where(d => d.ProjectId == 2).ToList();

            for (int i = 0; i < list.Count; i++)
            {
                Assert.Equal(expected[i].Id, list[i].Id);
                Assert.Equal(expected[i].Value, list[i].Value);
                Assert.Equal(expected[i].TimeCreate, list[i].TimeCreate);
            }
        }
        
        [Fact]
        public async Task AddDataPointSuccess()
        {
            var repo = new MockDataPointRepository();
            int previousLength = repo.FakeData.Count;

            var controller = new ProjectStatsController(repo);
            var result = await controller.AddDataPoint(2, new DataPointCreateInfo
            {
                Value = 20,
                TimeCreate = new DateTime()
            });

            Assert.IsType<OkResult>(result);
            Assert.Equal(previousLength + 1, repo.FakeData.Count);
        }

        [Fact]
        public async Task AddDataPointFailureMissingTimeCreate()
        {
            var repo = new MockDataPointRepository();
            var controller = new ProjectStatsController(repo);
            await Assert.ThrowsAsync<RequestFieldMissingException>(async () =>
            {
                await controller.AddDataPoint(2, new DataPointCreateInfo
                {
                    Value = 20
                });
            });
        }
        
        [Fact]
        public async Task AddDataPointFailureMissingValue()
        {
            var repo = new MockDataPointRepository();
            var controller = new ProjectStatsController(repo);
            await Assert.ThrowsAsync<RequestFieldMissingException>(async () =>
            {
                await controller.AddDataPoint(2, new DataPointCreateInfo
                {
                    TimeCreate = new DateTime()
                });
            });
        }
    }
}