using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientRestApi.Constructori
{
    
    public class EchipaConstructoriBlocuriUpdateDto
    {
        public int? ProiectId { get; set; }

        public string EstimatedTime { get; set; } // Adăugat pentru timpul estimat
    }
}
