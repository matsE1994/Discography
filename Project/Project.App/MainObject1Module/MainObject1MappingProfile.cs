using System;
using AutoMapper;
using Project.App.MainObject1Module.Contracts;

namespace Project.App.MainObject1Module
{
    public class MainObject1MappingProfile : Profile
    {
        public MainObject1MappingProfile()
        {
            CreateMap<MainObject1CreateModel, MainObject1>()
                .ForMember(
                    x => x.Id,
                    d => d.NullSubstitute(Guid.NewGuid()));
            CreateMap<MainObject1, MainObject1Response>();
        }
    }
}