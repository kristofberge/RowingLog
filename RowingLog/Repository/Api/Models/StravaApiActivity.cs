using System;
using Newtonsoft.Json;
using RowingLog.Common.Enums;

namespace RowingLog.Repository.Api.Models
{
    public class StravaApiActivity : BaseStravaModel
    {
        public MetaAthlete Athlete { get; set; }

        public string Name { get; set; }

        public double Distance { get; set; }

        [JsonProperty(PropertyName = "moving_time")]
        public int MovingTime { get; set; }

        [JsonProperty(PropertyName = "elapsed_time")]
        public int ElapsedTime { get; set; }

        [JsonProperty(PropertyName = "total_elevation_gain")]
        public double TotalElevationGain { get; set; }

        public StravaActivityType Type { get; set; }

        [JsonProperty(PropertyName = "workout_type")]
        public int? WorkoutType { get; set; }

        public long Id { get; set; }

        [JsonProperty(PropertyName = "external_id")]
        public string ExternalId { get; set; }

        [JsonProperty(PropertyName = "upload_id")]
        public string UploadId { get; set; }

        [JsonProperty(PropertyName = "start_date")]
        public DateTime StartDate { get; set; }

        [JsonProperty(PropertyName = "start_date_local")]
        public DateTime StartDateLocal { get; set; }

        public string Timezone { get; set; }

        [JsonProperty(PropertyName = "utc_offset")]
        public string UtcOffset { get; set; }

        [JsonProperty(PropertyName = "start_latlng")]
        public float[] StartLatLng { get; set; }

        [JsonProperty(PropertyName = "end_latlng")]
        public float[] EndLatLng { get; set; }

        [JsonProperty(PropertyName = "location_city")]
        public string LocationCity { get; set; }

        [JsonProperty(PropertyName = "location_state")]
        public string LocationState { get; set; }

        [JsonProperty(PropertyName = "location_country")]
        public string LocationCountry { get; set; }

        [JsonProperty(PropertyName = "start_latitude")]
        public float StartLatitude { get; set; }

        [JsonProperty(PropertyName = "start_longitude")]
        public float StartLongitude { get; set; }

        [JsonProperty(PropertyName = "achievement_count")]
        public int AchievementCount { get; set; }

        [JsonProperty(PropertyName = "kudos_count")]
        public int KudosCount { get; set; }

        [JsonProperty(PropertyName = "comment_count")]
        public int CommentCount { get; set; }

        [JsonProperty(PropertyName = "athlete_count")]
        public int AthleteCount { get; set; }

        [JsonProperty(PropertyName = "photo_count")]
        public int PhotoCount { get; set; }

        public PlygonMap Map { get; set; }

        [JsonProperty(PropertyName = "trainer")]
        public bool IsTrainer { get; set; }

        [JsonProperty(PropertyName = "commute")]
        public bool IsCommute { get; set; }

        [JsonProperty(PropertyName = "manual")]
        public bool IsManual { get; set; }

        [JsonProperty(PropertyName = "private")]
        public bool IsPrivate { get; set; }

        [JsonProperty(PropertyName = "flagged")]
        public bool IsFlagged { get; set; }

        [JsonProperty(PropertyName = "gear_id")]
        public string GearId { get; set; }

        [JsonProperty(PropertyName = "from_accepted_tag")]
        public bool IsFromAcceptedTag { get; set; }

        [JsonProperty(PropertyName = "average_speed")]
        public double AverageSpeed { get; set; }

        [JsonProperty(PropertyName = "max_speed")]
        public double MaxSpeed { get; set; }

        [JsonProperty(PropertyName = "average_cadence")]
        public double AverageCadence { get; set; }

        [JsonProperty(PropertyName = "average_watts")]
        public double AverageWatts { get; set; }

        [JsonProperty(PropertyName = "weighted_average_watts")]
        public double WeightedAverageWatts { get; set; }

        public double Kilojoules { get; set; }

        [JsonProperty(PropertyName = "device_watts")]
        public bool IsDeviceWatts { get; set; }

        [JsonProperty(PropertyName = "has_heartrate")]
        public bool HasHeartrate { get; set; }

        [JsonProperty(PropertyName = "average_heartrate")]
        public double AverageHeartrate { get; set; }

        [JsonProperty(PropertyName = "max_heartrate")]
        public int MaxHeartrate { get; set; }

        [JsonProperty(PropertyName = "max_watts")]
        public int MaxWatts { get; set; }

        [JsonProperty(PropertyName = "pr_count")]
        public int PRCount { get; set; }

        [JsonProperty(PropertyName = "total_photo_count")]
        public int TotalPhotoCount { get; set; }

        [JsonProperty(PropertyName = "has_kudoed")]
        public bool HasKudoed { get; set; }

        [JsonProperty(PropertyName = "suffer_score")]
        public int SufferScore { get; set; }

        public class MetaAthlete : BaseStravaModel
        {
            public int Id { get; set; }
        }

        public class PlygonMap : BaseStravaModel
        {
            public string Id { get; set; }

            [JsonProperty(PropertyName = "summary_polyline")]
            public string SummaryPolyline { get; set; }
        }
    }
}
