using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientRestApi.Constructori
{
    public class EchipaConstructorCaseResponseDto
    {
        public int ConstructorCaseId { get; set; }
        public string ConsName { get; set; }
        public string ConsStatus { get; set; }
        public int? CasaId { get; set; }
        public CaseConstructorDto CasaVanduta { get; set; }
    }
}
