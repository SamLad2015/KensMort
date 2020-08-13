using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using KensMort.Models;
using KensMort.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;

namespace KensMort.Controllers.v1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    //[Route("api/[controller]")]
    public class ScenarioController : ControllerBase
    {
        private readonly IScenarioService _scenarioService;

        public ScenarioController(
            IScenarioService scenarioService)
        {
            _scenarioService = scenarioService;
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        }

        [HttpPost]
        [Route("upload", Name = nameof(Upload))]
        public async Task<IList<ScenarioModel>> Upload(IFormFile formFile)  
        {
            try
            {
                _scenarioService.UploadScenarios(formFile);
            
                var scenarios = await  _scenarioService.GetAll();
                return await Task.FromResult(scenarios);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }  
    }
}
