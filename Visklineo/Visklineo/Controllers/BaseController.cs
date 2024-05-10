using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;
using Visklineo.Business.Helpers;
using Visklineo.Business.ViewModels;

namespace Visklineo.Controllers
{
    public class BaseController : Controller
    {
        public BaseController()
        {
        }

        public async Task<Response> GetAsync(string model, string path)
        {
            return await GetResponseAsync(HttpMethod.Get, model, path);
        } 
        public async Task<Response> PostAsync(object model, string path)
        {
            return await GetResponseAsync(HttpMethod.Post, JsonSerializer.Serialize(model), path);
        } 
        public async Task<Response> GetResponseAsync(HttpMethod method, string model, string path)
        {
            var response = await ApiHelper.ApiHelperAsync(method, path ,model);
            return response;
        } 
    }
}