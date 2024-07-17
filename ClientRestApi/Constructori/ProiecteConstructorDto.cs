using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientRestApi.Constructori
{
    public class ProiecteConstructorDto
    {
        public int ProiectId { get; set; }
        public string Nume { get; set; }
        public int NumarApartamente { get; set; }
        public string UrlImgProiect { get; set; }
        public string Descriere1 { get; set; }
        public string Descriere2 { get; set; }
    }
}
