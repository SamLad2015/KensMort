using System.Collections.Generic;
using System.Threading.Tasks;
using KensMort.Entities;

namespace KensMort.Repositories
{
    public class ScenarioRepository : IScenarioRepository
    {
        private readonly TestDbContext _testDbContext;

        public ScenarioRepository(TestDbContext testDbContext)
        {
            _testDbContext = testDbContext;
        }

        public Task<IList<ScenarioEntity>> Upload()
        {
            throw new System.NotImplementedException();
        }
    }
}
