using AutoMapper;
using KensMort.Entities;
using KensMort.Models;

namespace KensMort.MappingProfiles
{
    public class PortfolioMappings: Profile
    {
        public PortfolioMappings()
        {
            CreateMap<CategoryModel, CategoryEntity>().ReverseMap();
            CreateMap<PortfolioModel, PortfolioEntity>().ReverseMap();
        }
    }
}