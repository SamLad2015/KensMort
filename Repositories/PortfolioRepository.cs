using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using KensMort.Entities;

namespace KensMort.Repositories
{
    public class PortfolioRepository: IPortfolioRepository
    { 
        private readonly TestDbContext _testDbContext;
        private IList<CategoryEntity> _categories;
        private IList<PortfolioEntity> _portfolios;

        public PortfolioRepository(TestDbContext testDbContext)
        {
            _testDbContext = testDbContext;
            SetDummyCategories();
        }

        public async Task<IList<CategoryEntity>> GetCategories()
        {
            return await Task.FromResult(_categories);
        }
        
        public async Task<IList<PortfolioEntity>> GetPortfolios(long categoryId)
        {
            var portfolios = _portfolios.Where(p => p.CategoryId == categoryId).ToList();
            return await Task.FromResult(portfolios);
        }

        private void SetDummyCategories()
        {
            _categories = new List<CategoryEntity>();
            _portfolios = new List<PortfolioEntity>();
            for (int i = 1; i < 6; i++)
            {
                _categories.Add(new CategoryEntity {Id = i, CategoryName = "Test category " + i});
                SetDummyPortfolios(i);
            }
        }

        private void SetDummyPortfolios(long categoryId)
        {
            for (int i = 1; i < new Random().Next(1, 10); i++)
            {
                _portfolios.Add(new PortfolioEntity
                {
                    Id = i, 
                    PortfolioName = "Test Cat " + categoryId + " portfolio " + i,
                    CategoryId = categoryId
                });
            }
        }
    }
}