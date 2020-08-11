using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using KensMort.Models;
using KensMort.Repositories;

namespace KensMort.Services
{
    public class LoanService: ILoanService
    {
        private readonly ILoanRepository _loanRepository;
        private readonly IScenarioRepository _scenarioRepository;
        private readonly IMapper _mapper;
        public LoanService(ILoanRepository loanRepository,
            IScenarioRepository scenarioRepository,
            IMapper mapper)
        {
            _mapper = mapper;
            _loanRepository = loanRepository;
            _scenarioRepository = scenarioRepository;
        }

        public async Task<IList<LoanModel>> GetAll(LoanRequestModel request)
        {
            return _mapper.Map<IList<LoanModel>>((await _loanRepository.GetAll(request)));
        }
    }
}