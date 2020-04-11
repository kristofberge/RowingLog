using System;
using RowingLog.Common.Enums;

namespace RowingLog.Models
{
    public class StravaActivity : BaseModel
    {
        public string Name { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public ActivityType Type { get; set; }
        public double Distance { get; set; }
        public TimeSpan MovingTime { get; set; }
        public double AverageSpeed { get; set; }
    }
}
