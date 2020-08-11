using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KensMort.Entities;
using KensMort.Repositories;

namespace KensMort.Services
{
    public class ScenarioService: IScenarioService
    {
        private IScenarioRepository _scenarioRepository;
        public ScenarioService(IScenarioRepository scenarioRepository)
        {
            _scenarioRepository = scenarioRepository;
        }

        public void UploadScenarios()
        {
            throw new NotImplementedException();
        }
    }
}