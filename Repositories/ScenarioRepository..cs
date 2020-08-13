using System.Collections.Generic;
using System.Threading.Tasks;
using KensMort.Entities;

namespace KensMort.Repositories
{
    public class ScenarioRepository : IScenarioRepository
    {
        private readonly TestDbContext _testDbContext;
        private IList<ScenarioEntity> _scenarios;
        public ScenarioRepository(TestDbContext testDbContext)
        {
            _testDbContext = testDbContext;
        }

        public void Upload(IList<ScenarioEntity> list)
        {
            _scenarios = list;
        }

        public async Task<IList<ScenarioEntity>> GetAll()
        {
            return await Task.FromResult(_scenarios);
        }
    }
}
