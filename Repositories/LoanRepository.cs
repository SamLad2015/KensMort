using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KensMort.Entities;
using KensMort.Helpers;
using KensMort.Models;

namespace KensMort.Repositories
{
    public class LoanRepository : ILoanRepository
    {
        private readonly TestDbContext _testDbContext;
        private IList<LoanEntity> loans = new List<LoanEntity>();
        public LoanRepository(TestDbContext testDbContext)
        {
            _testDbContext = testDbContext;
            LoadFakeLoans();
        }

        public async Task<IList<LoanEntity>> GetAll(LoanRequestModel request)
        {
            IList<LoanEntity> loansFiltered = new List<LoanEntity>();
            for (int i = 1; i < 201; i++)
            {
                loansFiltered.Add(new LoanEntity
                {
                    Id = i, 
                    Balance = new Random().Next(1111, 999999),
                    Wac = Math.Round((decimal)(new Random().Next(1, 999) / 100.0), 2),
                    Btl = new Random().Next(0, 2),
                    LoanEndDate = RandomDate.NextDate(request.CutOffDate)
                });
            }
            return await Task.FromResult(loansFiltered);
        }

        public async Task<IList<LoanEntity>> GetProcessedLoans(long lastProcessedLoanId)
        {
            return await Task.FromResult(loans.Where(l => l.Id > lastProcessedLoanId).Take(1000).ToList());
        }

        public async Task<long> GetLoansCount()
        {
            return await Task.FromResult(loans.Count);
        }

        private void LoadFakeLoans()
        {
            for (int i = 1; i < 180001; i++)
            {
                loans.Add(new LoanEntity
                {
                    Id = i, 
                    Balance = new Random().Next(1111, 999999),
                    Wac = Math.Round((decimal)(new Random().Next(1, 999) / 100.0), 2),
                    Btl = new Random().Next(0, 2),
                    LoanEndDate = RandomDate.NextDate(DateTime.Now.AddYears(1))
                });
            }
        }
    }
}
