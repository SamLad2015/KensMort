using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using KensMort.Models;
using KensMort.Repositories;

namespace KensMort.Services
{
    public class PortfolioService: IPortfolioService
    {
        private readonly IPortfolioRepository _portfolioRepository;
        private readonly IMapper _mapper;
        public PortfolioService(IPortfolioRepository portfolioRepository,
            IMapper mapper)
        {
            _portfolioRepository = portfolioRepository;
            _mapper = mapper;
        }

        public async Task<IList<CategoryModel>> GetCategories()
        {
            return _mapper.Map<IList<CategoryModel>>((await _portfolioRepository.GetCategories()));
        }

        public async Task<IList<PortfolioModel>> GetPortfolios(long categoryId)
        {
            return _mapper.Map<IList<PortfolioModel>>((await _portfolioRepository.GetPortfolios(categoryId)));
        }
    }
}