using System.Collections.Generic;
using System.Threading.Tasks;
using Pertemps.Entities;

namespace Pertemps.Services
{
    public interface ISkillService
    {
        Task<IList<SkillEntity>> GetAllSkillTags();
        void AddSkillTags(int candidateId, IList<int> skillTagIds);
        void UpdateSkillTags(int candidateId, IList<int> skillTagIds);
        void RemoveSkillTags(int candidateId);
    }
}