using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Pertemps.Entities
{
    public class CandidateSkillEntity: BaseEntity
    {
        public int SkillId { get; set; }
        public int CandidateId { get; set; }
        [JsonIgnore] 
        [IgnoreDataMember] 
        public CandidateEntity Candidate { get; set; }
        [JsonIgnore] 
        [IgnoreDataMember] 
        public SkillEntity Skill { get; set; }
    }
}