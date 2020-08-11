using System.Collections.Generic;
using System.Threading.Tasks;
using KensMort.Models;

namespace KensMort.Services
{
    public interface IPortfolioService
    {
        Task<IList<CategoryModel>> GetCategories();
        Task<IList<PortfolioModel>> GetPortfolios(long categoryId);
    }
}