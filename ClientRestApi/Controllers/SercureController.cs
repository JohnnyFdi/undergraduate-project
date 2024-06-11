using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClientRestApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SecureController : ControllerBase
    {
        [HttpGet]
        [Authorize] // Această rută este protejată și necesită autentificare
        public IActionResult GetSecureData()
        {
            // Codul pentru a obține datele securizate
            return Ok("Date securizate"); // De exemplu, returnează "Date securizate" dacă utilizatorul este autentificat
        }
    }
}
