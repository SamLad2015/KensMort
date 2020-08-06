using System.Collections.Generic;

namespace Pertemps.Entities
{
    public class SkillEntity: BaseEntity
    {
        public string Description { get; set; }
        public IList<CandidateSkillEntity> Skills { get; set; }
    }
}