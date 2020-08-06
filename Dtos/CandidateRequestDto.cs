using System;
using System.Collections.Generic;
using Pertemps.Entities;

namespace Pertemps.Dtos
{
    public class CandidateRequestDto
    {
        public string Name { get; set; }
        public string Position { get; set; }
        public bool Contract { get; set; }
        public bool Available { get; set; }
        public float Match { get; set; }
    }
}
