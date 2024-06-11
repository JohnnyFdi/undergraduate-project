using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ClientRestApi.House_Config
{
    public class Ventilation
    {
        [Key]
        public int VentilationId { get; set; }
        public string VentName { get; set; }

        public int VentPrice { get; set; }

    }
}
