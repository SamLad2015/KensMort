using System.Collections.Generic;

namespace KensMort.Models
{
    public class ScenarioModel
    {
        public long Id { get; set; }
        public int Month { get; set; }
        public decimal Rate { get; set; }
        public decimal Hpi { get; set; }
    }
}