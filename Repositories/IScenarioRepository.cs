using System.Collections.Generic;
using System.Threading.Tasks;
using KensMort.Entities;


namespace KensMort.Repositories
{
    public interface IScenarioRepository
    { 
        void Upload(IList<ScenarioEntity> list);
        Task<IList<ScenarioEntity>> GetAll();
    }
    
    
}
