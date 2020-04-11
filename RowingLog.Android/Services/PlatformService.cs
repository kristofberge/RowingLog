// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="PlatformService.cs" company="ArcTouch LLC">
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
// //   Defines the PlatformService type.
// // </summary>
// //  --------------------------------------------------------------------------------------------------------------------
using System;
using System.IO;
using RowingLog.Services;
using static RowingLog.Common.Constants;

namespace RowingLog.Droid.Services
{
    public class PlatformService : IPlatformService
    {
        private string databaseLocation;

        public string DatabaseLocation
        {
            get
            {
                if (string.IsNullOrEmpty(this.databaseLocation))
                {
                    this.databaseLocation = Path.Combine(
                                Environment.GetFolderPath(Environment.SpecialFolder.Personal),
                                DatabaseName);
                }

                return databaseLocation;
            }
        }

        public void InitializeDatabase()
        {
            if (!File.Exists(this.databaseLocation))
            {
                File.Create(this.databaseLocation).Dispose();
            }
        }
    }
}
