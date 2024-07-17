using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ClientRestApi.House_Config
{
    public class ConfigCamera
    {
        [Key]
        public int ConfigCameraId { get; set; }
        public int ConfigCasaId { get; set; }
        public string NumeCamera { get; set; }
        public int Suprafata { get; set; }
        public bool IncalzirePardoseala { get; set; }

        
         public ConfigCasa ConfigCasa { get; set; }
    }
}
