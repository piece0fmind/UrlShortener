using Microsoft.EntityFrameworkCore;
using ShortURL.Application.Domain;
using ShortURL.Application.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortURL.Application.Features.UrlShortener
{
    public class UrlShortenerService : IUrlShortenerService
    {
        private readonly Random _random = new();
        private readonly AppDbContext _dbContext;

        public UrlShortenerService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public UrlDto GetOriginalUrl(string code)
        {
            try
            {
                var urlDetails = GetUrlByCode(code);
                return new UrlDto { Original = urlDetails.Original, Shortened = urlDetails.Shortened };
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<string> ShortenUrl(string url)
        {
            var shortCode = GenerateUniqueCode(url);

            if (!await _dbContext.Urls.AnyAsync(s => s.Shortened == shortCode))
            {
                SaveToDb(url, shortCode);
            }
            return shortCode;
        }
        private string GenerateUniqueCode(string url)
        {

            var codeChars = new char[ShortLinkSettings.Length];
            int maxValue = ShortLinkSettings.Alphabet.Length;
            var code = "";

            for (var i = 0; i < ShortLinkSettings.Length; i++)
            {
                var randomIndex = _random.Next(maxValue);

                codeChars[i] = ShortLinkSettings.Alphabet[randomIndex];
            }
            code = new string(codeChars);

            return code;
        }
        private void SaveToDb(string url, string code)
        {
            var urlDetails = new Domain.Url
            {
                Original = url,
                Shortened = code,
                CreatedAt = DateTime.UtcNow
            };
            _dbContext.Add(urlDetails);
            _dbContext.SaveChanges();
        }
        private Url GetUrlByCode(string code)
        {
            var urlInfo = _dbContext.Urls.FirstOrDefault(s => s.Shortened == code);
            if(urlInfo is null)
            {
                return new Url();
            }
            return urlInfo;
        }
    }
    
}
