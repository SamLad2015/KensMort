using System.Collections.Generic;
using System.Threading.Tasks;
using Pertemps.Entities;


namespace Pertemps.Repositories
{
    public interface ISkillRepository
    { 
        Task<IList<SkillEntity>> GetAll();
        Task<IList<CandidateSkillEntity>> GetCandidateSkills(int id);
        void Add(CandidateSkillEntity tag);
        void Remove(CandidateSkillEntity tag);
        bool Save();
    }
}
