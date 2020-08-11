using System.Collections.Generic;
using System.Threading.Tasks;
using KensMort.Entities;
using KensMort.Models;

namespace KensMort.Repositories
{
    public interface ILoanRepository
    {
        Task<IList<LoanEntity>> GetAll(LoanRequestModel request);
    }
}
