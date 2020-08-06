using System.Collections.Generic;
using System.Threading.Tasks;
using Pertemps.Dtos;
using Pertemps.Entities;

namespace Pertemps.Repositories
{
    public interface ICandidateRepository
    {
        Task<CandidateEntity> GetSingle(int id);
        void Add(CandidateEntity item);
        void Update(CandidateEntity item);
        void Delete(CandidateEntity item);
        Task<IList<CandidateEntity>> GetAll();
        bool Save();
    }
}
