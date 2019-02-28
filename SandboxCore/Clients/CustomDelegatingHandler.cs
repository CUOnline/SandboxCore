using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace SandboxCore.Clients
{
    public class CustomDelegatingHandler : DelegatingHandler
    {
        private readonly IConfiguration configuration;

        public CustomDelegatingHandler(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", configuration["CanvasSettings:CanvasToken"]);
            InnerHandler = new HttpClientHandler();
            return await base.SendAsync(request, cancellationToken);
        }
    }
}