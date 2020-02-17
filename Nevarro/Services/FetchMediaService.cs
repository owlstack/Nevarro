using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Nevarro.Interfaces;
using Refit;

namespace Nevarro.Services
{
    public static class FetchMediaService
    {
        public static INevarroApi apiService;
        static string baseUrl = "https://nevarro-backend2.azurewebsites.net";

        public static async Task<List<Uri>> CallImagesEndpoint()
        {
            apiService = RestService.For<INevarroApi>(baseUrl);
            var images = await apiService.GetImages();
            return images;
        }
   
    }
}
