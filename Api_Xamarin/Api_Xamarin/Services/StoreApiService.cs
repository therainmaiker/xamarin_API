using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Api_Xamarin.Models;
using Newtonsoft.Json;
using Xamarin.Essentials;

namespace Api_Xamarin.Services
{
    public static class StoreApiService
    {
        public static async Task<List<Category>> GetCategories()
        {
            await TokenValidator.CheckTokenValidity();
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("bearer", Preferences.Get("accessToken", string.Empty));
            var response = await httpClient.GetStringAsync(ApiSettings.ApiUrl_Category);
            return JsonConvert.DeserializeObject<List<Category>>(response);
        }
        
        public static async Task<List<Product>> GetProducts()
        {
            await TokenValidator.CheckTokenValidity();
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("bearer", Preferences.Get("accessToken", string.Empty));
            var response = await httpClient.GetStringAsync(ApiSettings.ApiUrl_Product);
            return JsonConvert.DeserializeObject<List<Product>>(response);
        }
    }
}