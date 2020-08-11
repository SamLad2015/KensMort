using System;
using System.Collections.Generic;
using KensMort.Entities;

namespace KensMort.Models
{
    public class LoanModel
    {
        public long Id { get; set; }
        public decimal Balance { get; set; }
        public decimal Wac { get; set; }
        public decimal Btl { get; set; }
        public DateTime LoanEndDate { get; set; }
    }
}