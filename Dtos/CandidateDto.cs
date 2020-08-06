using System.Collections.Generic;
using Pertemps.Entities;

namespace Pertemps.Dtos
{
    public class CandidateDto: CandidateRequestDto
    {
        public int Id { get; set; }
        public IList<string> Skills { get; set; }
    }
}