using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ClientRestApi.Admin
{
    public class Imagine
    {
        [Key]
        public int ImagineId { get; set; }
        public string Url { get; set; }

        public int ProiectId { get; set; }
        public Proiect Proiect { get; set; }
    }
}
