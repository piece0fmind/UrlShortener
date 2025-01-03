using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortURL.Application.Features.UrlShorter
{
    public class CreateShortUrlHandler 
    {
        
    }
    public record CreateShortUrlCommand(string url);
}
