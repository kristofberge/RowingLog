// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="CustomWebViewRenderer.cs" company="ArcTouch LLC">
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
// //   Defines the CustomWebViewRenderer type.
// // </summary>
// //  --------------------------------------------------------------------------------------------------------------------
using Android.Content;
using RowingLog.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(WebView), typeof(CustomWebViewRenderer))]
namespace RowingLog.Droid.Renderers
{
    public class CustomWebViewRenderer : WebViewRenderer
    {
        private const string UserAgent = "Mozilla/5.0 (Linux; Android 4.1.1; Galaxy Nexus Build/JRO03C) AppleWebKit/535.19 (KHTML, like Gecko) Chrome/18.0.1025.166 Mobile Safari/535.19";

        public CustomWebViewRenderer(Context context)
            : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<WebView> e)
        {
            base.OnElementChanged(e);

            if (Element != null)
            {
                //Control.Settings.JavaScriptEnabled = true;
                Control.Settings.UserAgentString = UserAgent;
            }
        }
    }
}
