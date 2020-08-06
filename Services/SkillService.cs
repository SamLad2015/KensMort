using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pertemps.Entities;
using Pertemps.Repositories;

namespace Pertemps.Services
{
    public class SkillService: ISkillService
    {
        private ISkillRepository _skillRepository;
        public SkillService(ISkillRepository skillRepository)
        {
            _skillRepository = skillRepository;
        }
        public async Task<IList<SkillEntity>> GetAllSkillTags()
        {
            return await _skillRepository.GetAll();
        }

        public void AddSkillTags(int candidateId, IList<int> skillTagIds)
        {
            foreach (int id in skillTagIds)
            {
                _skillRepository.Add(new CandidateSkillEntity
                {
                    SkillId = id,
                    CandidateId = candidateId
                });
            }
            
            if (!_skillRepository.Save())
            {
                throw new Exception("Adding a item failed on save.");
            }
        }
        
        public void UpdateSkillTags(int candidateId, IList<int> skillTagIds)
        {
            var existingTags = _skillRepository.GetCandidateSkills(candidateId);

            foreach (var tag in existingTags.Result)
            {
                _skillRepository.Remove(tag);
            }
            
            foreach (int id in skillTagIds)
            {
                _skillRepository.Add(new CandidateSkillEntity
                {
                    SkillId = id,
                    CandidateId = candidateId
                });
            }
            
            if (!_skillRepository.Save())
            {
                throw new Exception("Updating a item failed on save.");
            }
        }
        
        public void RemoveSkillTags(int candidateId)
        {
            var existingTags = _skillRepository.GetCandidateSkills(candidateId);

            foreach (var tag in existingTags.Result)
            {
                _skillRepository.Remove(tag);
            }
            
            if (!_skillRepository.Save())
            {
                throw new Exception("Deleting a item failed on save.");
            }
        }
    }
}