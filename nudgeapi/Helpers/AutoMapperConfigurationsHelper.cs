using DC=NudgeApi.DataContracts.Laptop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models= NudgeApi.Models.Laptop;
using Microsoft.Extensions.DependencyInjection;
using nudgeapi.AutoMapper;
using AutoMapper;

namespace nudgeapi.Helpers
{
    public class AutoMapperConfigurationsHelper : Profile
    {
        public AutoMapperConfigurationsHelper()
        {
            //CreateMap<DC.Laptop, Models.Laptop>();
           
        }
        public static void ConfigureAutomapper(IServiceCollection services)
        {
            // ### Automap settings ###
            services.AddAutoMapper();
            ConfigureMapper();
        }
        public static void ConfigureMapper()
        {
            //Mapping settings
            Mapper.Reset();//required because .NET Core DI engine calls the init many times (so, it loads mappings many times). Solution from Jimmy Bogard.

            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<APIMappingProfile>();
                cfg.ValidateInlineMaps = false;
            }
            );

        }
    }
}
