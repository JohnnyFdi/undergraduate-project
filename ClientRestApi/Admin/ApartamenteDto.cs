using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientRestApi.Admin
{
    public class ApartamenteDto
    {
        public int ApartamentId { get; set; }
        public int NumarApartament { get; set; }

        public int NumarCamere { get; set; }

        public int Suprafata { get; set; }

        public string Compartimentare { get; set; }

        public string Etaj { get; set; }

        public string Status { get; set; }
        


    }
}
