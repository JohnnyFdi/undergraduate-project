using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientRestApi.Contracte
{
    public class ContracteCaseDetailedDto
    {
        public int ContractCId { get; set; }
        public string AdminEmail { get; set; }
        public string UserFullName { get; set; }
        public string Adresa { get; set; }
        public DateTime DataSemnarii { get; set; }
        public int Costuri { get; set; }
        public int PretVanzare { get; set; }
    }
}
