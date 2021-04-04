using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Twaso.Domain.Models;

namespace Twaso.Domain.Services.Communication
{
    public class UrlResponse : BaseResponse
    {
        public Url Url { get; private set; }

        private UrlResponse(bool success, string message, Url url) : base(success, message)
        {
            Url = url;
        }

        public UrlResponse(Url url) : this(true, string.Empty, url) { }

        public UrlResponse(string message) : this(false, message, null) { }
    }
}
