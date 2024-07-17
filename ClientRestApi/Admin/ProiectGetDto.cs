using System.Collections.Generic;

namespace ClientRestApi.Admin
{
    public class ProiectGetDto
    {
        public int ProiectId { get; set; }
        public string Nume { get; set; }
        public int NumarApartamente { get; set; }

        // Proprietate pentru URL-ul imaginii
        public string ImgUrl { get; set; }

        public string Descriere1 { get; set; }
        public string Descriere2 { get; set; }
        public ICollection<ApartamenteDto> Apartamente { get; set; }
        public ICollection<ImagineDto> Imagini { get; set; }
    }
}

