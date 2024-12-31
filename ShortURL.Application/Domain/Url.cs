using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortURL.Application.Domain
{
    public class Url
    {
        public Guid Id { get; set; }
        public string Original { get; set; }
        public string Shortened { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
