using System.Collections.Generic;
using ProjectStatusAPI.Data.DataPoint;

namespace ProjectStatusAPI.Data.Projects
{
    public class ProjectDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual List<DataPointDto> DataPoints { get; set; } = new();
    }
}