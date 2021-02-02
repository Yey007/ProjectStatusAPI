using ProjectStatusAPI.API.Projects;
using ProjectStatusAPI.Storage.Projects;

namespace ProjectStatusAPI.Mapping
{
    public static class ProjectExtensions
    {
        public static ProjectDto ToProjectDto(this Project project)
        {
            return new()
            {
                Id = project.Id,
                Name = project.Name
            };
        }
        
        public static Project ToProject(this ProjectDto project)
        {
            return new()
            {
                Id = project.Id,
                Name = project.Name
            };
        }
        
        public static ProjectDto ToProjectDto(this ProjectCreateInfo project)
        {
            return new()
            {
                Name = project.Name
            };
        }
    }
}