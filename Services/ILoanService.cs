using System.Collections.Generic;
using System.Threading.Tasks;
using KensMort.Models;

namespace KensMort.Services
{
    public interface ILoanService
    {
        Task<IList<LoanModel>> GetAll(LoanRequestModel request);
    }
}