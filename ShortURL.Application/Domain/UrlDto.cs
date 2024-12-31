using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortURL.Application.Domain
{
    public class UrlDto
    {
        public string Original { get; set; } = string.Empty;
        public string Shortened { get; set; } = string.Empty;
    }
}
