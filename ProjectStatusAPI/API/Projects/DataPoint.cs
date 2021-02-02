using System;

namespace ProjectStatusAPI.API.Projects
{
    public class DataPoint
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public DateTime TimeCreate { get; set; }
    }
}