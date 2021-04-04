using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Twaso.Domain.Models;
using Twaso.Domain.Repository;
using Twaso.Domain.Services;
using Twaso.Domain.Services.Communication;

namespace Twaso.Services
{
    public class UrlService : IUrlService
    {
        private readonly IUrlRepository _urlRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UrlService(IUrlRepository urlRepository, IUnitOfWork unitOfWork)
        {
            _urlRepository = urlRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<UrlResponse> AddAsync(Url url)
        {
            try
            {
                var now = DateTime.UtcNow;

                var hash = ComputeHash(url.OriginalUrl).Substring(0, 8);
                url.Hash = hash;
                url.CreationDate = now;
                url.ExpirationDate = now.AddHours(1);

                await _urlRepository.AddAsync(url);
                await _unitOfWork.CompleteAsync();

                return new UrlResponse(url);
            }
            catch (Exception ex)
            {
                return new UrlResponse(ex.Message);
            }
        }

        public async Task<Url> GetUrl(string hash)
        {
            try
            {
                return await _urlRepository.FindByHashAsync(hash);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private string ComputeHash(string originalUrl)
        {
            var builder = new StringBuilder();
            using (var hash = SHA256.Create())
            {
                var encoding = Encoding.UTF8;
                byte[] res = hash.ComputeHash(encoding.GetBytes(originalUrl));
                foreach(byte b in res)
                {
                    builder.Append(b.ToString("x2"));
                }
            }
            return builder.ToString();
        }
    }
}
