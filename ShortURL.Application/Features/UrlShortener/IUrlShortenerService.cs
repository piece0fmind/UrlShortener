using ShortURL.Application.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortURL.Application.Features.UrlShortener
{
    public interface IUrlShortenerService
    {
        Task<string> ShortenUrl(string url);
        UrlDto GetOriginalUrl(string code);
    }
}
