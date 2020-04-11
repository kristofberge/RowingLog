using RowingLog.Common.Enums;

namespace RowingLog.Services.Mappers
{
    public class StravaActivityTypeMapper : IMapper<StravaActivityType, ActivityType>
    {
        public ActivityType Map(StravaActivityType from)
        {
            switch (from)
            {
                case StravaActivityType.Rowing:
                    return ActivityType.WaterRowing;
                case StravaActivityType.Hike:
                    return ActivityType.Hike;
                case StravaActivityType.Ride:
                    return ActivityType.RoadCycling;
                case StravaActivityType.Run:
                    return ActivityType.Run;
                case StravaActivityType.Swim:
                    return ActivityType.Swim;
                case StravaActivityType.Walk:
                    return ActivityType.Walk;
                default:
                    return ActivityType.Workout;
            }
        }
    }
}
