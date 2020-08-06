using System;
using Pertemps.Dtos;
using Microsoft.AspNetCore.Mvc;
using Pertemps.Services;

namespace Pertemps.v1.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    //[Route("api/[controller]")]
    public class CandidateListingController : ControllerBase
    {
        private readonly ICandidateService _candidateService;

        public CandidateListingController(
            ICandidateService candidateService)
        {
            _candidateService = candidateService;
        }

        [HttpGet(Name = nameof(GetAllItems))]
        public ActionResult GetAllItems(ApiVersion version)
        {
            var candidates = _candidateService.GetAll();
            
            return Ok(candidates.Result);
        }

        [HttpPost(Name = nameof(AddItem))]
        public ActionResult<CandidateDto> AddItem(ApiVersion version, [FromBody] CandidateRequestDto createDto)
        {
            try
            {
                if (createDto == null)
                {
                    return BadRequest();
                }
                
                var candidate = _candidateService.AddCandidate(createDto);

                return Ok(candidate.Result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        

        [HttpPut]
        [Route("{id:int}", Name = nameof(UpdateItem))]
        public ActionResult<CandidateRequestDto> UpdateItem(int id, [FromBody]CandidateRequestDto updateDto)
        {
            if (updateDto == null)
            {
                return BadRequest();
            }
            
            _candidateService.UpdateCandidate(id ,updateDto);

            return Ok();
        }
        
        [HttpDelete]
        [Route("{id:int}", Name = nameof(DeleteItem))]
        public ActionResult<CandidateRequestDto> DeleteItem(int id)
        {
            _candidateService.DeleteCandidate(id);

            return Ok();
        }
    }
}
