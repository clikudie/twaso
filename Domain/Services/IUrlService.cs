using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Twaso.Domain.Models;
using Twaso.Domain.Services.Communication;

namespace Twaso.Domain.Services
{
    public interface IUrlService
    {
        Task<UrlResponse> AddAsync(Url url);
        Task<Url> GetUrl(string hash);
    }
}
