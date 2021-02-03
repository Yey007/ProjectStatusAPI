using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectStatusAPI.API.Projects;
using ProjectStatusAPI.Exceptions.API;
using Xunit;

namespace ProjectStatusAPI.Tests.Unit.Controller
{
    public class ProjectsControllerTests
    {
        [Fact]
        public async Task GetProjectsSuccess()
        {
            var repo = new MockProjectRepository();
            var controller = new ProjectsController(repo);
            var result = await controller.GetProjects() as OkObjectResult;

            Assert.NotNull(result);

            var list = ((IEnumerable<Project>) result.Value).ToList();
            Assert.NotNull(list);

            for (int i = 0; i < list.Count; i++)
            {
                Assert.Equal(repo.FakeData[i].Id, list[i].Id);
                Assert.Equal(repo.FakeData[i].Name, list[i].Name);
            }
        }

        [Fact]
        public async Task GetProjectSuccess()
        {
            var repo = new MockProjectRepository();
            var controller = new ProjectsController(repo);
            var result = await controller.GetProject(1) as OkObjectResult;

            Assert.NotNull(result);

            var proj = result.Value as Project;
            Assert.NotNull(proj);

            Assert.Equal(repo.FakeData[0].Id, proj.Id);
            Assert.Equal(repo.FakeData[0].Name, proj.Name);
        }

        [Fact]
        public async Task CreateProjectSuccess()
        {
            var repo = new MockProjectRepository();
            int previousLength = repo.FakeData.Count;

            var controller = new ProjectsController(repo);
            var result = await controller.CreateProject(new ProjectCreateInfo {Name = "Hello"});

            Assert.IsType<OkResult>(result);
            Assert.Equal(previousLength + 1, repo.FakeData.Count);
        }

        [Fact]
        public async Task CreateProjectFailMissingName()
        {
            var repo = new MockProjectRepository();

            var controller = new ProjectsController(repo);
            await Assert.ThrowsAsync<RequestFieldMissingException>(async () =>
                await controller.CreateProject(new ProjectCreateInfo {Name = null}));
        }
    }
}