using System.Threading.Tasks;
using UnixTimeStamp;
using Xamarin.Essentials;

namespace Api_Xamarin.Services
{
    public static class TokenValidator
    {
        public static async Task CheckTokenValidity()
        {
            var expirationTime = Preferences.Get("tokenExpirationTime", 0);
            Preferences.Set("currentTime", UnixTime.GetCurrentTime());
            var currentTime = Preferences.Get("currentTime", 0);
            if (expirationTime < currentTime)
            {
                var email = Preferences.Get("email", string.Empty);
                var password = Preferences.Get("password", string.Empty);
                await AuthApiService.Login(email,password); 
            }
        }
        
    }
}