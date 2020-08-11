using System.Collections.Generic;
using System.Threading.Tasks;
using KensMort.Entities;


namespace KensMort.Repositories
{
    public interface IScenarioRepository
    { 
        Task<IList<ScenarioEntity>> Upload();
    }
}
