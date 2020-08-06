using Pertemps.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Pertemps.Repositories
{
    public class CandidateRepository : ICandidateRepository
    {
        private readonly TestDbContext _testDbContext;

        public CandidateRepository(TestDbContext testDbContext)
        {
            _testDbContext = testDbContext;
        }

        public async Task<CandidateEntity> GetSingle(int id)
        {
            return await _testDbContext.Candidates.FirstOrDefaultAsync(x => x.Id == id);
        }

        public void Add(CandidateEntity item)
        {
            _testDbContext.Candidates.Add(item);
        }

        public void Update(CandidateEntity item)
        {
            _testDbContext.Candidates.Update(item);
        }
        
        public void Delete(CandidateEntity item)
        {
            _testDbContext.Candidates.Remove(item);
        }

        public async Task<IList<CandidateEntity>> GetAll()
        {
            return await _testDbContext.Candidates
                    .Include(c => c.Skills)
                    .ThenInclude(skill => skill.Skill).ToListAsync();
        }

        public bool Save()
        {
            return (_testDbContext.SaveChanges() >= 0);
        }
    }
}
