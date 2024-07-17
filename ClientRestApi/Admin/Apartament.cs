using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using ClientRestApi.Contracte;

namespace ClientRestApi.Admin
{
    public class Apartament
    {
        [Key]
        public int ApartamentId { get; set; }
        public int NumarApartament { get; set; }

        public int NumarCamere { get; set; }

        public int Suprafata { get; set; }

        public string Compartimentare { get; set; }

        public string Etaj { get; set; }

        public string Status { get; set; }
        public int ProiectId { get; set; }
        public Proiect Proiect { get; set; }

        public ContracteApartamente ContracteApartamente { get; set; }


    }
}
