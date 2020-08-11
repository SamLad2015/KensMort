using System.Collections.Generic;
using System.Linq;
using KensMort.Services;
using Microsoft.AspNetCore.Mvc;

namespace KensMort.Controllers.v1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    //[Route("api/[controller]")]
    public class PortfolioController: ControllerBase
    {
        private readonly IPortfolioService _portfolioService;

        public PortfolioController(
            IPortfolioService portfolioService)
        {
            _portfolioService = portfolioService;
        }
        
        [HttpGet]
        [Route("categories", Name = nameof(GetCategories))]
        public ActionResult GetCategories(ApiVersion version)
        {
            var categories = _portfolioService.GetCategories();
            
            return Ok(categories.Result);
        }
        
        [HttpGet]
        [Route("categories/{id}/portfolios", Name = nameof(GetPortfolios))]
        public ActionResult GetPortfolios(ApiVersion version, [FromRoute] long id)
        {
            var portfolios = 
                _portfolioService.GetPortfolios(id);
            
            return Ok(portfolios.Result);
        }
    }
}