using AutoMapper;
using Project.App.MainObject1Module.Contracts;

namespace Project.App.MainObject1Module
{
    public class MainObject1MappingProfile : Profile
    {
        public MainObject1MappingProfile()
        {
            CreateMap<MainObject1CreateModel, MainObject1>();
            CreateMap<MainObject1, MainObject1Response>();
        }
    }
}