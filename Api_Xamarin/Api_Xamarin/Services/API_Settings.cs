using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Api_Xamarin.Services
{
    public static class ApiSettings
    {
        //Root
        public static string ApiUrl = "https://store-api.conveyor.cloud/api";

        //Authentication EndPoints
        public static string ApiUrl_AuthLogin = ApiUrl + "/Auth/Login";
        public static string ApiUrl_AuthRegister = ApiUrl + "/Auth/Register";

        //Store EndPoints
        public static string ApiUrl_Category = ApiUrl + "/Category";
        public static string ApiUrl_Product = ApiUrl + "/Product";
        public static string ApiUrl_Order = ApiUrl + "/Order";
    }
}