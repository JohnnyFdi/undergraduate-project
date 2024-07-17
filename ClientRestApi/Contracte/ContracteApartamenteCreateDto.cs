using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientRestApi.Contracte
{
    public class ContracteApartamenteCreateDto
    {
        public int UserId { get; set; }
        public int ApartamentId { get; set; }
        public DateTime DataSemnarii { get; set; }
        public int Costuri { get; set; }
        public int PretVanzare { get; set; }
    }
}
