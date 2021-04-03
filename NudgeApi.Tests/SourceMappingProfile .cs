using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace NudgeApi.Tests
{
    public class SourceMappingProfile : Profile
    {
        public SourceMappingProfile()
        {
            CreateMap<IMapper,Mapper>().ReverseMap();
        }

    }
}
