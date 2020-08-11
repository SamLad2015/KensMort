using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KensMort.Entities;
using KensMort.Helpers;
using KensMort.Models;

namespace KensMort.Repositories
{
    public class LoanRepository : ILoanRepository
    {
        private readonly TestDbContext _testDbContext;

        public LoanRepository(TestDbContext testDbContext)
        {
            _testDbContext = testDbContext;
        }

        public async Task<IList<LoanEntity>> GetAll(LoanRequestModel request)
        {
            IList<LoanEntity> loans = new List<LoanEntity>();
            for (int i = 1; i < 201; i++)
            {
                loans.Add(new LoanEntity
                {
                    Id = i, 
                    Balance = new Random().Next(1111, 999999),
                    Wac = Math.Round((decimal)(new Random().Next(1, 999) / 100.0), 2),
                    Btl = new Random().Next(0, 2),
                    LoanEndDate = RandomDate.NextDate(request.CutOffDate)
                });
            }
            return await Task.FromResult(loans);
        }
    }
}
