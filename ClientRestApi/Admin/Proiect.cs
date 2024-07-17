using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ClientRestApi.Angajati;

namespace ClientRestApi.Admin
{
    public class Proiect
    {
        [Key]
        public int ProiectId { get; set; }
        public string Nume { get; set; }
        public int NumarApartamente { get; set; }

        public string UrlImgProiect { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public string Descriere1 { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public string Descriere2 { get; set; }

        public ICollection<Apartament> Apartamente { get; set; }
        public ICollection<Imagine> Imagini { get; set; }

        public EchipaConstructorBlocuri EchipaConstructorBlocuri { get; set; }
    }
}
