using AutoMapper;
using KensMort.Entities;
using KensMort.Models;

namespace KensMort.MappingProfiles
{
    public class LoanMappings : Profile
    {
        public LoanMappings()
        {
            CreateMap<LoanEntity, LoanModel>().ReverseMap();
            CreateMap<ScenarioEntity, ScenarioModel>();
        }
    }
}
