using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientRestApi.Contracte
{
    public class ContracteApartamenteDetailedDto
    {
        public int ContractApId { get; set; }
        public string AdminEmail { get; set; }
        public string UserFullName { get; set; }
        public int NumarApartament { get; set; }
        public string NumeProiect { get; set; }
        public DateTime DataSemnarii { get; set; }
        public int Costuri { get; set; }
        public int PretVanzare { get; set; }
    }
}
