// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="ApiAthlete.cs" company="ArcTouch LLC">
// //   Copyright 2019 ArcTouch LLC.
// //   All rights reserved.
// //
// //   This file, its contents, concepts, methods, behavior, and operation
// //   (collectively the "Software") are protected by trade secret, patent,
// //   and copyright laws. The use of the Software is governed by a license
// //   agreement. Disclosure of the Software to third parties, in any form,
// //   in whole or in part, is expressly prohibited except as authorized by
// //   the license agreement.
// // </copyright>
// // <summary>
// //   Defines the ApiAthlete type.
// // </summary>
// //  --------------------------------------------------------------------------------------------------------------------
using System;
using Newtonsoft.Json;

namespace RowingLog.Repository.Api.Models
{
    public class StravaApiAthlete : BaseStravaModel
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Country { get; set; }

        public string Sex { get; set; }

        public bool Premium { get; set; }

        public bool Summit { get; set; }

        [JsonProperty(PropertyName = "created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty(PropertyName = "updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty(PropertyName = "badge_type_id")]
        public int BadgeTypeId { get; set; }

        [JsonProperty(PropertyName = "profile_medium")]
        public string ProfileMedium { get; set; }

        [JsonProperty(PropertyName = "profile")]
        public string Profile { get; set; }
    }
}
