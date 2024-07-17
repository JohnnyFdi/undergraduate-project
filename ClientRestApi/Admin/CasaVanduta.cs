using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using ClientRestApi.Constructori;

namespace ClientRestApi.Admin
{
    public class CasaVanduta
    {
        [Key]
        public int CasaId { get; set; }

        public int NumarCamere { get; set; }

        public int Suprafata { get; set; }

        public int Etaje { get; set; }

        public string Adresa { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public string DetaliiCasa { get; set; }

        public EchipaConstructorCase EchipaConstructorCase { get; set; }
    }
}
