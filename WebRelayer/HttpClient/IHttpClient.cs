using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebRelayer.Helpers;

namespace WebRelayer.Services
{
    public interface IHttpClient
    {
        Task<T> SendPostAsync<T>(string requestUrl, object obj);

        Task<T> SendGetAsync<T>(string requestUrl);
    }
}
