using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace KensMort.Entities
{
    public class LoanEntity: BaseEntity
    {
        public decimal Balance { get; set; }
        public decimal Wac { get; set; }
        public decimal Btl { get; set; }
        public DateTime LoanEndDate { get; set; }
    }
}
