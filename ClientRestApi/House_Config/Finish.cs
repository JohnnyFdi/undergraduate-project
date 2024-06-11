using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ClientRestApi.House_Config
{
    public class Finish
    {
        [Key]
        public int FinishId { get; set; }
        public string FinName { get; set; }

        public double Finish_xm2 { get; set; }

    }
}
