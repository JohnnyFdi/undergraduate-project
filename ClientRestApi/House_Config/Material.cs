using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ClientRestApi.House_Config
{
    public class Material
    {
        [Key]
        public int MaterialId { get; set; }
        public string MatName { get; set; }

        public double Material_xm2 { get; set; }

    }
}
