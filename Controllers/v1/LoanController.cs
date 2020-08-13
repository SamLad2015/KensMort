using System.Collections.Generic;
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
    public class LoanController : ControllerBase
    {
        private readonly ILoanService _loanService;

        public LoanController(
            ILoanService loanService)
        {
            _loanService = loanService;
        }

        [HttpGet(Name = nameof(GetLoans))]
        public async Task<IList<LoanModel>> GetLoans(ApiVersion version, [FromQuery] LoanRequestModel request)
        {
            return await _loanService.GetAll(request);
        }
        
        [HttpGet]
        [Route("count", Name = nameof(GetLoanCount))]
        public async Task<long> GetLoanCount(ApiVersion version)
        {
            return await _loanService.GetLoansCount();
        }
        
        [HttpGet]
        [Route("processed/{processedLoanCount}", Name = nameof(GetProcessedLoans))]
        public async Task<LoanResponseModel> GetProcessedLoans(ApiVersion version, [FromRoute] long processedLoanCount)
        {
            return await _loanService.GetProcessedLoans(processedLoanCount);
        }
    }
}
