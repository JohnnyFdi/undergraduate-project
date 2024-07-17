using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientRestApi.House_Config
{
    public class HouseConfigResponseDto
    {
        public int ConfigCasaId { get; set; }
        public string Material { get; set; }
        public string Finisaj { get; set; }
        public string TipIncalzire { get; set; }
        public string Ventilatie { get; set; }
        public string ColectareReziduri { get; set; }
        public List<CameraConfigDto> Camere { get; set; }
    }
}
