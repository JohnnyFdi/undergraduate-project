using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientRestApi.Contracte
{
    public class ContracteCaseDto
    {
        public int ContractCId { get; set; }
        public int AdminId { get; set; }
        public int UserId { get; set; }
        public int CasaId { get; set; }
        public DateTime DataSemnarii { get; set; }
        public int Costuri { get; set; }
        public int PretVanzare { get; set; }
    }
}
