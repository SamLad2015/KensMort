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
        public ActionResult GetLoans(ApiVersion version, [FromQuery] LoanRequestModel request)
        {
            var candidates = _loanService.GetAll(request);
            
            return Ok(candidates.Result);
        }
    }
}
