using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ClientRestApi.Admin
{
    public class ProiectPostDto
    {
        
        public int ProiectId { get; set; }
        public string Nume { get; set; }
        public int NumarApartamente { get; set; }

        public IFormFile UrlImgProiect { get; set; }
        

        public string Descriere1 { get; set; }

        public string Descriere2 { get; set; }

        public ICollection<ApartamenteDto> Apartamente { get; set; }
        public ICollection<IFormFile> Imagini { get; set; }
    }
}
