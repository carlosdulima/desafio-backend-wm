using AutoMapper;
using Webmotors.ApplicationCore.Domains;
using Webmotors.UI.Models;

namespace Webmotors.UI.Configuration
{
    public class WebMapperProfile : Profile
    {
        public WebMapperProfile()
        {
            CreateMap<Ad, AdViewModel>().ReverseMap();
        }
    }
}
