using System;

namespace ProjectStatusAPI.API.DataPoint
{
    public class DataPoint
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public DateTime TimeCreate { get; set; }
    }
}