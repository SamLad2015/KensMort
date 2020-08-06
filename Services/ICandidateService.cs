using System.Collections.Generic;
using System.Threading.Tasks;
using Pertemps.Dtos;

namespace Pertemps.Services
{
    public interface ICandidateService
    {
        Task<IList<CandidateDto>> GetAll();
        Task<CandidateDto> AddCandidate(CandidateRequestDto requestDto);
        void UpdateCandidate(int id, CandidateRequestDto requestDto);
        void DeleteCandidate(int restaurantId);
    }
}