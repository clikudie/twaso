using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Twaso.Domain.Models;

namespace Twaso.Domain.Repository
{
    public interface IUrlRepository
    {
        Task AddAsync(Url url);
        Task<Url> FindByHashAsync(string hash);
    }
}
