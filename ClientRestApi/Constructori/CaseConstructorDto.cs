using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientRestApi.Constructori
{
    public class CaseConstructorDto
    {
        public int CasaId { get; set; }
        public int NumarCamere { get; set; }

        public int Suprafata { get; set; }

        public int Etaje { get; set; }

        public string Adresa { get; set; }

        
        public string DetaliiCasa { get; set; }
    }
}
