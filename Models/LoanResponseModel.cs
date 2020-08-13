using System.Collections.Generic;

namespace KensMort.Models
{
    public class LoanResponseModel
    {
        public IList<LoanModel> Loans;
        public long ProcessedLoanCount { get; set; }
    }
}