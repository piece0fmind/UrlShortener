using Microsoft.AspNetCore.Mvc;
using ShortURL.Application.Domain;
using ShortURL.Application.Features.UrlShortener;
using ShortURL.Application.Shared;

namespace ShortURL.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UrlController : Controller
    {
        private readonly IUrlShortenerService _urlShortenerService;

        public UrlController(IUrlShortenerService urlShortenerService)
        {
            _urlShortenerService = urlShortenerService;
        }

        [HttpPost]
        public async Task<Response> ShortenUrl(string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                return new Response(false, "URL is required", null);
            }
            try
            {   
                var shortUrl = await _urlShortenerService.ShortenUrl(url);
                var urlDto = new UrlDto
                {
                    Original = url,
                    Shortened = shortUrl
                };
                return new Response(true, "Success", urlDto);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet]
        public Response GetOriginalUrl(string code)
        {
            try
            {
                if (string.IsNullOrEmpty(code))
                {
                    return new Response(false, "Code is required", null);
                }
                var urlDto = _urlShortenerService.GetOriginalUrl(code);
                return new Response(true, "Success", urlDto);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        
    }
}
