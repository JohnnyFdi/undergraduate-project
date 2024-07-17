using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientRestApi.Constructori
{
    public class EchipaConstructorBlocuriResponseDto
    {
        public int ConstructorId { get; set; }
        public string ConsName { get; set; }
        public string ConsStatus { get; set; }
        public int? ProiectId { get; set; }
        public ProiecteConstructorDto Proiect { get; set; }
    }
}
