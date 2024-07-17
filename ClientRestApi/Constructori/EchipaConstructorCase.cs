using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ClientRestApi.Admin;

namespace ClientRestApi.Constructori
{
    public class EchipaConstructorCase
    {
        [Key]
        public int ConstructorCaseId { get; set; }
        public string ConsName { get; set; }

        public string ConsStatus { get; set; }

        public int? CasaId { get; set; }

        public CasaVanduta CasaVanduta { get; set; }

    }
}
