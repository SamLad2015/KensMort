using KensMort.Services;
using Microsoft.AspNetCore.Mvc;

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
        }

        [HttpPost]
        [Route("upload", Name = nameof(Upload))]
        public ActionResult Upload()
        {
            _scenarioService.UploadScenarios();
            
            return Ok();
        }
    }
}
