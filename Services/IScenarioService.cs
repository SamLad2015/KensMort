using System.Collections.Generic;
using System.Threading.Tasks;
using KensMort.Models;
using Microsoft.AspNetCore.Http;

namespace KensMort.Services
{
    public interface IScenarioService
    {
        void UploadScenarios(IFormFile file);
        Task<IList<ScenarioModel>> GetAll();
    }
}