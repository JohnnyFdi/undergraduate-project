using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ClientRestApi.House_Config
{
    public class Waste
    {
        [Key]
        public int WasteId { get; set; }
        public string WasteName { get; set; }

        public int WastePrice { get; set; }

    }
}
