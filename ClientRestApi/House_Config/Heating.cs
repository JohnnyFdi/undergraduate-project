using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ClientRestApi.House_Config
{
    public class Heating
    {
        [Key]
        public int HeatingId { get; set; }
        public string HeatName { get; set; }

        public int HeatPrice { get; set; }

    }
}
