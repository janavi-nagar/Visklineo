using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using Visklineo.Business.ViewModels;
using Visklineo.Business.ViewModels.User;

namespace Visklineo.Business.Helpers
{
    public class ApiHelper
    {
        private readonly HttpClient _httpClient;
        public ApiHelper()
        {
        }
        public static async Task<Response> ApiHelperAsync(HttpMethod method, string url, string content)
        {
            HttpClient _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(AppSettings.WebApi);
            _httpClient.DefaultRequestHeaders
                    .Accept
                    .Add(new MediaTypeWithQualityHeaderValue("application/json"));//ACCEPT header  

            HttpRequestMessage request = new HttpRequestMessage(method, url);//add the `[Route("relativeAddress")]` in the API action method. 
            
            //request.Headers.Add("Authorization", $"Bearer {token}");   //add jwt token to the header 
            request.Content = new StringContent(content, Encoding.UTF8, "application/json");//CONTENT-TYPE header  
            var result = await _httpClient.SendAsync(request);
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<Response>(result.Content.ReadAsStringAsync().Result);
            }
            else
            {
                return new Response { Message = "Something went wrong, Please try again later.", Status = false };
            }
        }
    }
}