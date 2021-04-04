using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Twaso.Domain.Models
{
    public class Url
    {
        public string Hash { get; set; }
        public string OriginalUrl { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
