using Api_Xamarin.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using UnixTimeStamp;
using Xamarin.Essentials;

namespace Api_Xamarin.Services
{
    class AuthApiService
    {
        //Post: Auth: Register
        public static async Task<bool> Register(string firstname, string lastname, string username, string email,
            string password, string address)
        {
            var user = new RegisterModel()
            {
                Username = username,
                FirstName = firstname,
                LastName = lastname,
                Email = email,
                Password = password,
                Address = address
            };

            var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(user);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(ApiSettings.ApiUrl_AuthRegister, content);

            if (!response.IsSuccessStatusCode)
            {
                return false;
            }

            var jsonResult = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<AuthModel>(jsonResult);

            Preferences.Set("token", result.Token);
            Preferences.Set("email", result.Email);
            Preferences.Set("userId", result.UserId);
            Preferences.Set("username", result.Username);
            Preferences.Set("userRoles", result.Roles.ToString());
            Preferences.Set("tokenExpirationTime", result.ExpiresOn);
            Preferences.Set("currentTokenTime", UnixTime.GetCurrentTime());

            return true;
        }

        //Post: Auth: Login
        public static async Task<bool> Login(string email, string password)
        {
            var user = new LoginModel()
            {
                Email = email,
                Password = password
            };
            var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(user);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(ApiSettings.ApiUrl_AuthLogin, data);
            if (!response.IsSuccessStatusCode) return false;
            var jsonResult = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<AuthModel>(jsonResult);

            if (result != null)
            {
                Preferences.Set("token", result.Token);
                Preferences.Set("email", result.Email);
                Preferences.Set("userId", result.UserId);
                Preferences.Set("username", result.Username);
                Preferences.Set("userRoles", result.Roles.ToString());
                Preferences.Set("tokenExpirationTime", result.ExpiresOn);
            }

            Preferences.Set("currentTokenTime", UnixTime.GetCurrentTime());
            return true;
        }
    }
}