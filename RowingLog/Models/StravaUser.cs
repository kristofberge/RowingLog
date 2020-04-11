using RowingLog.Common.Enums;

namespace RowingLog.Models
{
    public class StravaUser
    {
        public int StravaId { get; set; }

        public string Username { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Country { get; set; }

        public Sex Sex { get; set; }

        public bool HasPremium { get; set; }

        public bool HasSummit { get; set; }

        public string AccessToken { get; set; }

        public string RefreshToken { get; set; }

        public string Avatar { get; set; }
    }
}