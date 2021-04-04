using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Twaso.Domain.Models;
using Twaso.Resources;

namespace Twaso.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Url, UrlResource>();
        }
    }
}
