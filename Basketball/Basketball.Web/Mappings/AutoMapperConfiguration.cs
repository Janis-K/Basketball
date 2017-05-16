using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Basketball.Models.Models;
using Basketball.Web.ViewModels;

namespace Basketball.Web.Mappings
{
    public static class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Country, CountryViewModel>()
                    .ForMember(g => g.CountryId, map => map.MapFrom(vm => vm.Id));
                cfg.CreateMap<CountryViewModel, Country>();
                cfg.CreateMap<Team, TeamViewModel>()
                    .ForMember(g => g.TeamId, map => map.MapFrom(x => x.Id))
                    .ForMember(g => g.CountryName, map => map.MapFrom(x => x.TeamCountry.CountryName));
                cfg.CreateMap<TeamViewModel, Team>()
                    .ForMember(g => g.CountryId, map => map.MapFrom(x => x.CountryId));

            });
            Mapper.Configuration.CompileMappings();
        }
    }
}