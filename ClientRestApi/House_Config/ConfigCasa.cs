using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ClientRestApi.House_Config
{
    public class ConfigCasa
    {
        [Key]
        public int ConfigCasaId { get; set; }
        public int UserId { get; set; }
        public string Material { get; set; }
        public string Finisaj { get; set; }
        public string TipIncalzire { get; set; }
        public string Ventilatie { get; set; }
        public string ColectareReziduri { get; set; }


        // Proprietatea de navigare către User
        
        public User User { get; set; }
        public ICollection<ConfigCamera> ConfigCameras { get; set; }
    }
}
