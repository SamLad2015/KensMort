using Microsoft.AspNetCore.Mvc;
using Pertemps.Dtos;
using Pertemps.Services;

namespace Pertemps.v1.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    //[Route("api/[controller]")]
    public class SkillController : ControllerBase
    {
        private readonly ISkillService _skillService;

        public SkillController(
            ISkillService skillService)
        {
            _skillService = skillService;
        }

        [HttpGet(Name = nameof(GetAll))]
        public ActionResult GetAll(ApiVersion version)
        {
            var skillTags = _skillService.GetAllSkillTags();
            
            return Ok(skillTags.Result);
        }
        
        [HttpPost]
        [Route("{candidateId:int}/skills", Name = nameof(Add))]
        public ActionResult Add(int candidateId, SkillTagsDto tagsDto)
        {
            _skillService.AddSkillTags(candidateId, tagsDto.SkillTagIds);
            
            return Ok();
        }
        
        [HttpPut]
        [Route("{candidateId:int}/skills", Name = nameof(Update))]
        public ActionResult Update(int candidateId, SkillTagsDto tagsDto)
        {
            _skillService.UpdateSkillTags(candidateId, tagsDto.SkillTagIds);
            
            return Ok();
        }
        
        [HttpDelete]
        [Route("{candidateId:int}", Name = nameof(Delete))]
        public ActionResult Delete(int candidateId)
        {
            _skillService.RemoveSkillTags(candidateId);
            
            return Ok();
        }
    }
}
