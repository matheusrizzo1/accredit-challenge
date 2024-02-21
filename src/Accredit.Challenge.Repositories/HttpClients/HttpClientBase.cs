using Accredit.Challenge.Borders.Exceptions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Accredit.Challenge.Repositories.HttpClients
{
    public abstract class HttpClientBase
    {
        protected readonly HttpClient _httpClient;
        protected HttpClientBase(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        protected async Task<TResponse> Execute<TResponse>(string uri)
        {
            var serializerSettings = new JsonSerializerSettings();
            serializerSettings.Converters.Add(new StringEnumConverter());
            serializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            HttpResponseMessage response = null;

            try
            {
                response = await _httpClient.GetAsync(uri);
            }
            catch (Exception ex)
            {
                throw new HttpRequestException($"Error calling api: '{uri}' with method: 'GET'.", inner: ex);
            }

            var responseContent = await response.Content.ReadAsStringAsync();

            ValidateResponse(response, responseContent);

            return DeserializeObject<TResponse>(responseContent);
        }

        private static void ValidateResponse(HttpResponseMessage response, string responseContent)
        {
            if (response.IsSuccessStatusCode)
                return;

            var statusCode = (int)response.StatusCode;

            Exception ex = new RepositoryException(responseContent, (HttpStatusCode)statusCode);

            if (response.StatusCode == HttpStatusCode.NotFound)
                ex = new NotFoundException(responseContent);

            throw ex;
        }
        protected virtual TResponse DeserializeObject<TResponse>(string responseContent) => JsonConvert.DeserializeObject<TResponse>(responseContent);
    }
}
