// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="StravaActivityItemViewModel.cs" company="ArcTouch LLC">
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
// //   Defines the StravaActivityItemViewModel type.
// // </summary>
// //  --------------------------------------------------------------------------------------------------------------------
using System;
namespace RowingLog.ViewModels
{
    public class StravaActivityItemViewModel
    {
        public string AthleteName { get; set; }
        public string AthleteAvatar { get; set; }
        public string Name { get; set; }
        public string Date { get; set; }
        public string Type { get; set; }
        public string Distance { get; set; }
        public string DistanceUnit { get; set; }
        public string Split { get; set; }
        public string SplitUnit { get; set; }
    }
}
