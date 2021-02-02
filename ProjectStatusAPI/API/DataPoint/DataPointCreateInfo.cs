using System;

namespace ProjectStatusAPI.API.DataPoint
{
    public class DataPointCreateInfo
    {
        public int? Value { get; set; }
        public DateTime? TimeCreate { get; set; }
    }
}