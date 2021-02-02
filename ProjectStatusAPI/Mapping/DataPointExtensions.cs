using ProjectStatusAPI.API.Projects;
using ProjectStatusAPI.Data.DataPoint;

namespace ProjectStatusAPI.Mapping
{
    public static class DataPointExtensions
    {
        public static DataPointDto ToDataPointDto(this DataPoint dataPoint)
        {
            return new()
            {
                Id = dataPoint.Id,
                Value = dataPoint.Value,
                TimeCreate = dataPoint.TimeCreate
            };
        }
        
        public static DataPoint ToDataPoint(this DataPointDto dataPoint)
        {
            return new()
            {
                Id = dataPoint.Id,
                Value = dataPoint.Value,
                TimeCreate = dataPoint.TimeCreate
            };
        }
        
        public static DataPointDto ToDataPointDto(this DataPointCreateInfo info, int projectId)
        {
            return new()
            {
                Value = info.Value ?? default,
                TimeCreate = info.TimeCreate ?? default,
                ProjectId = projectId
            };
        }
    }
}