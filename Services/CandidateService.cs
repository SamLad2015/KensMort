using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Pertemps.Dtos;
using Pertemps.Entities;
using Pertemps.Repositories;

namespace Pertemps.Services
{
    public class CandidateService: ICandidateService
    {
        private readonly ICandidateRepository _candidateRepository;
        private readonly ISkillRepository _skillRepository;
        private readonly IMapper _mapper;
        public CandidateService(ICandidateRepository candidateRepository,
            ISkillRepository skillRepository,
            IMapper mapper)
        {
            _mapper = mapper;
            _candidateRepository = candidateRepository;
            _skillRepository = skillRepository;
        }

        public async Task<IList<CandidateDto>> GetAll()
        {
            return _mapper.Map<IList<CandidateDto>>((await _candidateRepository.GetAll()));
        }

        public async Task<CandidateDto> AddCandidate(CandidateRequestDto requestDto)
        {
            CandidateEntity toAdd = new CandidateEntity
            {
                Name = requestDto.Name,
                Position = requestDto.Position,
                Contract = requestDto.Contract,
                Available = requestDto.Available,
                Match = requestDto.Match
            };

            _candidateRepository.Add(toAdd);
            
            if (!_candidateRepository.Save())
            {
                throw new Exception("Creating a item failed on save.");
            }
            
            return _mapper.Map<CandidateDto>((await _candidateRepository.GetSingle(toAdd.Id)));
        }
        
        public void UpdateCandidate(int candidateId, CandidateRequestDto requestDto)
        {
            var existingItem = _candidateRepository.GetSingle(candidateId).Result;
            existingItem.Name = requestDto.Name;
            existingItem.Position = requestDto.Position;
            existingItem.Contract = requestDto.Contract;
            existingItem.Available = requestDto.Available;
            existingItem.Match = requestDto.Match;
            
            _candidateRepository.Update(existingItem);

            if (!_candidateRepository.Save())
            {
                throw new Exception("Updating a item failed on save.");
            }
        }
        
        public void DeleteCandidate(int candidateId)
        {
            var existingItem = _candidateRepository.GetSingle(candidateId).Result;

            _candidateRepository.Delete(existingItem);

            if (!_candidateRepository.Save())
            {
                throw new Exception("Deleting a item failed on save.");
            }
        }
    }
}