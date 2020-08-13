using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KensMort.Models;
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
        public async Task<IList<CategoryModel>> GetCategories(ApiVersion version)
        {
            return await _portfolioService.GetCategories();
        }
        
        [HttpGet]
        [Route("categories/{id}/portfolios", Name = nameof(GetPortfolios))]
        public async Task<IList<PortfolioModel>> GetPortfolios(ApiVersion version, [FromRoute] long id)
        {
            return await _portfolioService.GetPortfolios(id);
        }
    }
}