using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Refit;

namespace Nevarro.Interfaces
{
    public interface INevarroApi
    {
        [Get("/images")]
        Task<List<Uri>> GetImages();
    }
}
