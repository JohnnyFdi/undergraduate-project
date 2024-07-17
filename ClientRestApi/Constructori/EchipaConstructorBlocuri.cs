using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ClientRestApi.Admin;

namespace ClientRestApi.Angajati
{
    public class EchipaConstructorBlocuri
    {
        [Key]
        public int ConstructorId { get; set; }
        public string ConsName{ get; set; }

        public string ConsStatus { get; set; }

        public int? ProiectId { get; set; }

        public Proiect Proiect { get; set; }

    }
}
