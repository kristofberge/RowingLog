using RowingLog.iOS.Renderers;
using WebKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(WebView), typeof(CustomWebViewRenderer))]
namespace RowingLog.iOS.Renderers
{
    public class CustomWebViewRenderer : WkWebViewRenderer, IWKNavigationDelegate
    {
        private const string UserAgent = "Mozilla/5.0 (Linux; Android 4.1.1; Galaxy Nexus Build/JRO03C) AppleWebKit/535.19 (KHTML, like Gecko) Chrome/18.0.1025.166 Mobile Safari/535.19";

        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null && NativeView != null)
            {
                CustomUserAgent = UserAgent;
            }
        }
    }
}
