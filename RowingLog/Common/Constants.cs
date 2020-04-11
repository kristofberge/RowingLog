// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="Constants.cs" company="ArcTouch LLC">
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
// //   Defines the Constants type.
// // </summary>
// //  --------------------------------------------------------------------------------------------------------------------
namespace RowingLog.Common
{
    public static class Constants
    {
        public const string StravaClientId = "40941";
        public const string StravaClientSecret = "cfe3bfe0768609fb12c03d2587f9cb5eb1afbd2e";
        public const string GrantTypeAuthorizartionCode = "authorization_code";
        public const string GrantTypeRefreshToken = "refresh_token";
        public const string StravaRedirectUri = "https://rowinglog";
        public const string StravaOAuthUri = "https://www.strava.com/oauth/authorize";

        public const string DatabaseName = "RowingLogDb";

    }
}
