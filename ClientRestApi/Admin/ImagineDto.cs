using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ClientRestApi.Admin
{
    public class ImagineDto
    {
        public int ImagineId { get; set; }
        public string Url { get; set; }
    }
}
