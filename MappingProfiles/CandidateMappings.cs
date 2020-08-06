using System.Linq;
using AutoMapper;
using Pertemps.Dtos;
using Pertemps.Entities;

namespace Pertemps.MappingProfiles
{
    public class CandidateMappings : Profile
    {
        public CandidateMappings()
        {
            CreateMap<CandidateEntity, CandidateDto>()
                .ForMember(obj => obj.Skills, 
                    opt => 
                        opt.MapFrom(src => 
                            src.Skills.Select(c => c.Skill.Description).ToList()))
                .ReverseMap();
            CreateMap<CandidateRequestDto, CandidateEntity>();
        }
    }
}
