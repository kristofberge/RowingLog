using System;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Refit;
using RowingLog.Services;
using static RowingLog.Repository.Api.ApiConstants;

namespace RowingLog.Repository.Api
{
    public class ApiFactory : IApiFactory
    {
        public Lazy<T> Api<T>()
        {
            return new Lazy<T>(() => Create<T>(StravaBaseUrl));
        }

        private static TApi Create<TApi>(string baseUrl)
        {
            return RestService.For<TApi>(GetClient(baseUrl));
        }

        private static HttpClient GetClient(string baseUrl)
        {
            var client = new HttpClient(new ProxyClientHandler())
            {
                BaseAddress = new Uri(baseUrl),
                DefaultRequestHeaders = { { Accept, ApplicationJson } }
            };

            return client;
        }


        class ProxyClientHandler : HttpClientHandler
        {

            public ProxyClientHandler()
            {
#if DEBUG || STAGING
                Proxy = System.Net.WebRequest.DefaultWebProxy;
                UseProxy = Proxy != null;
#endif
            }

            protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                var sw = new Stopwatch();
                sw.Start();

#if DEBUG || STAGING
                LogRequest(request);
#endif

                HttpResponseMessage httpResponseMessage = await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
                sw.Stop();

#if DEBUG || STAGING
                LogResponse(await httpResponseMessage.Content.ReadAsStringAsync(), httpResponseMessage.RequestMessage.RequestUri.ToString(), ref sw);
#endif
                return httpResponseMessage;
            }

            private void LogRequest(HttpRequestMessage httpRequest)
            {
                var sb = new StringBuilder();
                sb.AppendLine("===================================");
                sb.AppendLine($"Request for {httpRequest.RequestUri}");
                sb.AppendLine("===================================");
                sb.AppendLine($"Method: {httpRequest.Method}");
                sb.AppendLine($"Headers");

                foreach (var header in httpRequest.Headers)
                {
                    sb.AppendLine($"{header.Key} : {Newtonsoft.Json.JsonConvert.SerializeObject(header.Value)}");
                }

                sb.AppendLine("===================================");
                Debug.WriteLine(sb.ToString());
            }

            private void LogResponse(string responseContent, string requestUri, ref Stopwatch sw)
            {
                var sb = new StringBuilder();
                sb.AppendLine("===================================");
                sb.AppendLine($"Response for call to {requestUri} took {sw.Elapsed.ToString("c")} to complete");
                sb.AppendLine("===================================");
                sb.AppendLine(responseContent);
                sb.AppendLine("===================================");
                Debug.WriteLine(sb.ToString());
            }
        }
    }
}
