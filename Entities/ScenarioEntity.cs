using System.Collections.Generic;

namespace KensMort.Entities
{
    public class ScenarioEntity: BaseEntity
    {
        public int Month { get; set; }
        public decimal Rate { get; set; }
        public decimal Hpi { get; set; }
    }
}