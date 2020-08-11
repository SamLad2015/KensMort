using System.Collections.Generic;
using System.Threading.Tasks;
using KensMort.Entities;

namespace KensMort.Repositories
{
    public interface IPortfolioRepository
    {
        Task<IList<CategoryEntity>> GetCategories();
        Task<IList<PortfolioEntity>> GetPortfolios(long categoryId);
    }
}