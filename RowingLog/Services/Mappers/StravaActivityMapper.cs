// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="StravaActivityMapper.cs" company="ArcTouch LLC">
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
// //   Defines the StravaActivityMapper type.
// // </summary>
// //  --------------------------------------------------------------------------------------------------------------------
using System;
using RowingLog.Common.Enums;
using RowingLog.Models;
using RowingLog.Repository.Api.Models;

namespace RowingLog.Services.Mappers
{
    public class StravaActivityMapper : IMapper<StravaApiActivity, StravaActivity>
    {
        private readonly IMapperService mapperService;

        public StravaActivityMapper(IMapperService mapperService)
        {
            this.mapperService = mapperService;
        }

        public StravaActivity Map(StravaApiActivity from)
        {
            return new StravaActivity
            {
                Name = from.Name,
                Type = this.mapperService.Map<StravaActivityType, ActivityType>(from.Type),
                StartTime = from.StartDateLocal,
                EndTime = from.StartDateLocal + TimeSpan.FromSeconds(from.ElapsedTime),
                Distance = from.Distance,
                MovingTime = TimeSpan.FromSeconds(from.MovingTime),
                AverageSpeed = from.AverageSpeed
            };
        }
    }
}
