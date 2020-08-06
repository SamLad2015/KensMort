using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Pertemps.Entities
{
    public class CandidateEntity: BaseEntity
    {
        public string Name { get; set; }
        public string Position { get; set; }
        [JsonIgnore] 
        [IgnoreDataMember] 
        public IList<CandidateSkillEntity> Skills { get; set; }
        public bool Contract { get; set; }
        public bool Available { get; set; }
        public double Match { get; set; }
    }
}
