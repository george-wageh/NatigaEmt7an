using System.Net.Http;
using System.Net.Http.Json;
using System.Web;

namespace NewsBlazorAppAdmin.Services
{
    public class ApiServices
    {
        public ApiServices(IHttpClientFactory httpClientFactory)
        {
            HttpClientFactory = httpClientFactory;
            httpClient = HttpClientFactory.CreateClient("Client");
        }

        public IHttpClientFactory HttpClientFactory { get; }
        public HttpClient httpClient { get; }

        public async Task<O> PostJsonAsync<O>(string urlPath, Object i) where O : class  {


            try
            {
                var response = await httpClient.PostAsJsonAsync(urlPath, i);
                var responseDto = await response.Content.ReadFromJsonAsync<O>();
                return responseDto;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<O> PostAsync<O>(string urlPath, HttpContent i) where O : class
        {
            try
            {
                var response = await httpClient.PostAsync(urlPath, i);
                var responseDto = await response.Content.ReadFromJsonAsync<O>();
                return responseDto;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<O> PutJsonAsync<O>(string urlPath, Object i) where O : class
        {
            try
            {
                var response = await httpClient.PutAsJsonAsync(urlPath, i);
                var responseDto = await response.Content.ReadFromJsonAsync<O>();
                return responseDto;
            }
            catch (Exception ex)
            {
                return null;

            }
        }

        public async Task<O> GetJsonAsync<O>(string urlPath) where O : class
        {
            try
            {
                var response = await httpClient.GetFromJsonAsync<O>(urlPath);
                return response;
            }
            catch (Exception ex)
            {
                return null;

            }
        }
        public string GetQueryString(object obj)
        {
            var properties = from p in obj.GetType().GetProperties()
                             where p.GetValue(obj, null) != null
                             select p.Name + "=" + HttpUtility.UrlEncode(p.GetValue(obj, null).ToString());

            return "?"+ String.Join("&", properties.ToArray());
        }
        public async Task<O> GetJsonAsync<O>(string urlPath , object query) where O : class
        {
            try
            {
                var queryStr = GetQueryString(query);
                var response = await httpClient.GetFromJsonAsync<O>(urlPath + queryStr);
                return response;
            }
            catch (Exception ex)
            {
                return null;

            }
        }
        public async Task<O> DeleteJsonAsync<O>(string urlPath) where O : class
        {
            try
            {
                var response = await httpClient.DeleteFromJsonAsync<O>(urlPath);
                return response;
            }
            catch (Exception ex)
            {
                return null;

            }
        }

    }
}
