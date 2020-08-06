using Pertemps.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Pertemps.Repositories
{
    public class SkillRepository : ISkillRepository
    {
        private readonly TestDbContext _testDbContext;

        public SkillRepository(TestDbContext testDbContext)
        {
            _testDbContext = testDbContext;
        }

        public async Task<IList<SkillEntity>> GetAll()
        {
            return await _testDbContext.Skills.OrderBy(c => c.Description).ToListAsync();
        }
        
        public async Task<IList<CandidateSkillEntity>> GetCandidateSkills(int id)
        {
            return await _testDbContext.CandidateSkills.Where(t => t.CandidateId == id)
                .ToListAsync();
        }
        
        public void Add(CandidateSkillEntity tag)
        {
            _testDbContext.CandidateSkills.Add(tag);
        }
        
        public void Remove(CandidateSkillEntity tag)
        {
            _testDbContext.CandidateSkills.Remove(tag);
        }
        
        public bool Save()
        {
            return (_testDbContext.SaveChanges() >= 0);
        }
    }
}
