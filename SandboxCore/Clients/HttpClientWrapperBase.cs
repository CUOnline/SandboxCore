using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace SandboxCore.Clients
{
    public class HttpClientWrapperBase : IDisposable
    {
        protected readonly string baseUrl;
        private HttpClient httpClient;

        protected HttpClientWrapperBase(IConfiguration configuration)
        {
            CustomDelegatingHandler customDelegatingHandler = new CustomDelegatingHandler(configuration);
            baseUrl = configuration["CanvasSettings:BaseUrl"] + "api/v1";
            baseUrl = baseUrl.Trim('/');
            httpClient = new HttpClient(customDelegatingHandler);
        }

        protected HttpClient Client()
        {
            if (httpClient == null)
                throw new ObjectDisposedException("HttpClient has been disposed");

            return httpClient;
        }

        protected async Task<T> ExecuteGet<T>(string apiPath)
        {
            var response = await Client().GetStringAsync(baseUrl + "/" + apiPath);
            return JsonConvert.DeserializeObject<T>(response);
        }

        protected async Task ExecuteGet(string apiPath)
        {
            await Client().GetStringAsync(baseUrl + "/" + apiPath);
        }

        protected async Task<List<T>> ExecuteGetAll<T>(string apiPath)
        {
            var response = await Client().GetStringAsync(baseUrl + "/" + apiPath);
            return JsonConvert.DeserializeObject<List<T>>(response);
        }

        protected async Task<T> ExecutePost<T>(string apiPath, string json)
        {
            Client().DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await Client().PostAsync(baseUrl + "/" + apiPath, new StringContent(json, Encoding.UTF8, "application/json"));
            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(responseString);
            }

            var errMsg = $"Failed to call the API. HTTP Status: {response.StatusCode}, Reason {response.ReasonPhrase}";
            throw new Exception(errMsg);
        }

        protected async Task<T> ExecutePost<T>(string apiPath, IEnumerable<T> model)
        {
            var response = await Client().PostAsync(baseUrl + "/" + apiPath, new StringContent(JsonConvert.SerializeObject(model)));
            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(responseString);
            }

            var errMsg = String.Format("Failed to call the API. HTTP Status: {0}, Reason {1}", response.StatusCode, response.ReasonPhrase);
            throw new Exception(errMsg);
        }
        protected async Task<T> ExecutePost<T>(string apiPath, IEnumerable<int> model)
        {
            var response = await Client().PostAsync(baseUrl + "/" + apiPath, new StringContent(JsonConvert.SerializeObject(model)));
            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(responseString);
            }

            var errMsg = String.Format("Failed to call the API. HTTP Status: {0}, Reason {1}", response.StatusCode, response.ReasonPhrase);
            throw new Exception(errMsg);
        }

        protected async Task<T> ExecutePut<T>(string apiPath, T model)
        {
            var response = await Client().PutAsync(baseUrl + "/" + apiPath, new StringContent(JsonConvert.SerializeObject(model)));
            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(responseString);
            }

            var errMsg = String.Format("Failed to call the API. HTTP Status: {0}, Reason {1}", response.StatusCode, response.ReasonPhrase);
            throw new Exception(errMsg);
        }

        #region Dispose
        ~HttpClientWrapperBase()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(false);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (httpClient != null)
            {
                if (disposing)
                {
                    httpClient.Dispose();
                    httpClient = null;
                }
            }
        }
        #endregion
    }
}