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
        static string baseUrl = "http://10.0.2.2:5000";

        public static async Task<ObservableCollection<Uri>> CallImagesEndpoint()
        {
            apiService = RestService.For<INevarroApi>(baseUrl);
            var images = await apiService.GetImages();
            return images;
        }
   
    }
}
