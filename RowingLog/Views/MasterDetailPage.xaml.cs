// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="MasterDetailPage.xaml.cs" company="ArcTouch LLC">
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
// //   Defines the MasterDetailPage.xaml type.
// // </summary>
// //  --------------------------------------------------------------------------------------------------------------------
using MvvmCross.Forms.Presenters.Attributes;
using MvvmCross.Forms.Views;
using RowingLog.ViewModels;
using Xamarin.Forms.Xaml;

namespace RowingLog.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [MvxMasterDetailPagePresentation(Position = MasterDetailPosition.Root, WrapInNavigationPage = false, Title = "MasterDetail Page")]
    public partial class MasterDetailPage : MvxMasterDetailPage<MasterDetailViewModel>
    {
        public MasterDetailPage()
        {
            InitializeComponent(); 
        }
    }
}
