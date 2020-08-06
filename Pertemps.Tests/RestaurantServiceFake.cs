using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pertemps.Dtos;
using Pertemps.Services;

namespace Pertemps.Tests
{
    public class CandidateServiceFake: ICandidateService
    {
        private IList<CandidateDto> _candidates;
        public CandidateServiceFake()
        {
            _candidates = new List<CandidateDto>()
            {
                new CandidateDto()
                {
                    Id = 1,
                    Name = "test 1",
                    Position = "Position for test 1",
                    Match = 1,
                    Contract = true,
                    Available = false,
                },
                new CandidateDto()
                {
                    Id = 2,
                    Name = "test 3",
                    Position = "Address for test 2",
                    Match = 3,
                    Contract = true,
                    Available = true
                },
                new CandidateDto()
                {
                    Id = 3,
                    Name = "test 33",
                    Position = "Address for test 3",
                    Match = 5,
                    Contract = true,
                    Available = false
                }
            };
        }
        
        public async Task<IList<CandidateDto>> GetAll()
        {
            await Task.Delay(500);
            return _candidates;
        }

        public async Task<CandidateDto> AddCandidate(CandidateRequestDto requestDto)
        {
            await Task.Delay(200);
            var request = new CandidateDto
            {
                Id = 4,
                Name = requestDto.Name,
                Position = requestDto.Position,
                Contract = requestDto.Contract,
                Available = requestDto.Available,
                Match = requestDto.Match,
            };
            _candidates.Add(request);
            return request;
        }

        public async void UpdateCandidate(int id, CandidateRequestDto requestDto)
        {
            var request = new CandidateDto
            {
                Id = id,
                Name = requestDto.Name,
                Position = requestDto.Position,
                Available = requestDto.Available,
                Contract = requestDto.Contract,
                Match = requestDto.Match,
                Skills = new List<string> {"test 1", "test 3"}
            };
            _candidates.Remove(_candidates.FirstOrDefault(r => r.Id == id));
            _candidates.Add(request);
        }

        public async void DeleteCandidate(int id)
        {
            await Task.Delay(500);
            _candidates.Remove(_candidates.FirstOrDefault(r => r.Id == id));
        }
    }
}