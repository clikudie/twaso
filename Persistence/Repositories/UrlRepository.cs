using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Twaso.Domain.Models;
using Twaso.Domain.Repository;
using Twaso.Persistence.Contexts;

namespace Twaso.Persistence.Repositories
{
    public class UrlRepository : BaseRepository, IUrlRepository
    {
        public UrlRepository(AppDbContext context): base(context)
        {

        }
        public async Task AddAsync(Url url)
        {
            await _context.Urls.AddAsync(url);
        }

        public async Task<Url> FindByHashAsync(string hash)
        {
            return await _context.Urls.FindAsync(hash);
        }
    }
}
