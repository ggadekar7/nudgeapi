using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nudgeapi.AutoMapper
{
    using Models = NudgeApi.Models;
    using DC = NudgeApi.DataContracts;

    using Profile = global::AutoMapper.Profile;
    public class APIMappingProfile : Profile
    {
        public APIMappingProfile()
        {
            CreateMap<DC.LaptopResponse, Models.LaptopResponse>().ReverseMap();
            CreateMap<DC.ConfigurationResponse, Models.ConfigurationResponse>().ReverseMap();
            CreateMap<DC.Laptop, Models.Laptop>().ReverseMap(); 
        }
    }
}
