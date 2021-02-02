using System;
using ProjectStatusAPI.Storage.Projects;

namespace ProjectStatusAPI.Storage.DataPoint
{
    public class DataPointDto
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public DateTime TimeCreate { get; set; }
        
        public int ProjectId { get; set; }
        public virtual ProjectDto ProjectDto { get; set; }
    }
}