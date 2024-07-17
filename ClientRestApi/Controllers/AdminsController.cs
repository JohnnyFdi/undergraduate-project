using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ClientRestApi.Admin;
using ClientRestApi.Contracte;
using ClientRestApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace ClientRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminsController : ControllerBase
    {
        public static AdminUser adminuser = new AdminUser();
        private readonly IConfiguration _configuration;
        private readonly IAdminRepository _adminRepository;
        private readonly AppDbContext _context;


        public AdminsController(IConfiguration configuration, IAdminRepository adminRepository, AppDbContext context)
        {
            _adminRepository = adminRepository;
            _configuration = configuration;
            _context = context;

        }

        

        [HttpGet]

        public async Task<ActionResult> GetAdminUsers()
        {
            try
            {
                return Ok(await _adminRepository.GetAdminUsers());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpGet("{id:int}")]

        public async Task<ActionResult<AdminUser>> GetAdminUser(int id)
        {
            try
            {
                var result = await _adminRepository.GetAdminUser(id);

                if (result == null)
                {
                    return NotFound();
                }

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }

        }

        [HttpPost("register")]

        public async Task<ActionResult<AdminUser>> CreateAdminUser(AdminUser adminuser)
        {
            try
            {
                if (adminuser == null)
                    return BadRequest();

                var us = await _adminRepository.GetAdminUserByEmail(adminuser.Email);

                if (us != null)
                {
                    ModelState.AddModelError("Email", "User email already in use");
                    return BadRequest(ModelState);
                }

                var createdUser = await _adminRepository.AddAdminUser(adminuser);

                return CreatedAtAction(nameof(GetAdminUser),
                    new { id = createdUser.AdminId }, createdUser);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new User record");
            }
        }
        
        [HttpPost("login")]
        public async Task<ActionResult<AdminUser>> Login(AdminDto request)
        {
            try
            {
                // Verificăm dacă email-ul există în baza de date
                var adminuser = await _adminRepository.GetAdminUserByEmail(request.Email);

                if (adminuser == null)
                {
                    return BadRequest("Email not found.");
                }

                // Verificăm dacă parola este corectă
                if (adminuser.Password != request.Password)
                {
                    return BadRequest("Wrong password.");
                }

                string token = CreateToken(adminuser);

                return Ok(token);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error during authentication");
            }
        }

        private string CreateToken(AdminUser adminuser)
        {
            List<Claim> claims = new List<Claim> {
                new Claim(ClaimTypes.NameIdentifier, adminuser.AdminId.ToString()),
                new Claim(ClaimTypes.Email, adminuser.Email),
                new Claim(ClaimTypes.Role, "User"),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value!));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: creds
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        

        [HttpPut("{id:int}")]

        public async Task<ActionResult<AdminUser>> UpdateAdminUser(int id, AdminUser adminuser)
        {
            try
            {
                if (id != adminuser.AdminId)
                    return BadRequest("User ID mismatch");

                var userToUpdate = await _adminRepository.GetAdminUser(id);

                if (userToUpdate == null)
                {
                    return NotFound($"User with Id = {id} not found");
                }

                return await _adminRepository.UpdateAdminUser(adminuser);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating User record");
            }
        }

        [HttpDelete("{id:int}")]

        public async Task<ActionResult> DeleteAdminUser(int id)
        {
            try
            {
                var userToDelete = await _adminRepository.GetAdminUser(id);

                if (userToDelete == null)
                {
                    return NotFound($"User with Id= {id} not found");
                }

                await _adminRepository.DeleteAdminUser(id);

                return Ok($"User with Id = {id} deleted");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting User record");
            }
        }

        
        [HttpGet("profile"), Authorize]
        public async Task<ActionResult<AdminUser>> GetProfile()
        {
            try
            {
                var email = User.FindFirstValue(ClaimTypes.Email);
                if (email == null)
                {
                    return Unauthorized("Email not found in token");
                }

                var user = await _adminRepository.GetAdminUserByEmail(email);
                if (user == null)
                {
                    return NotFound("User not found");
                }

                return Ok(user);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving user data from the database");
            }
        }

        [HttpPut("profile"), Authorize]
        public async Task<ActionResult<AdminUser>> UpdateProfile(AdminDto updatedUserDto)
        {
            try
            {
                var adminIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);

                if (adminIdClaim == null)
                {
                    return Unauthorized("User ID not found in token");
                }

                var adminId = int.Parse(adminIdClaim.Value);

                var existingUser = await _adminRepository.GetAdminUser(adminId);

                if (existingUser == null)
                {
                    return NotFound("User not found");
                }

                // Actualizăm doar numele, prenumele, email-ul și numărul de telefon
                
                existingUser.Email = updatedUserDto.Email ?? existingUser.Email;
                existingUser.Password = updatedUserDto.Password ?? existingUser.Password;

                var updatedUser = await _adminRepository.UpdateAdminUser(existingUser);

                return Ok(updatedUser);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating user profile");
            }
        }
        

        [HttpGet("proiecte")]
        public async Task<ActionResult<IEnumerable<ProiectGetDto>>> GetProiecte()
        {
            var proiecte = await _context.Proiecte
                .Select(p => new ProiectGetDto
                {
                    ProiectId = p.ProiectId,
                    Nume = p.Nume,
                    NumarApartamente = p.NumarApartamente,
                    Descriere1 = p.Descriere1,
                    Descriere2 = p.Descriere2,
                    ImgUrl = $"{Request.Scheme}://{Request.Host}/uploads/{Path.GetFileName(p.UrlImgProiect)}", // Setăm URL-ul imaginii în proprietatea corectă
            Apartamente = p.Apartamente.Select(a => new ApartamenteDto
                    {
                        ApartamentId = a.ApartamentId,
                        NumarApartament = a.NumarApartament,
                        NumarCamere = a.NumarCamere,
                        Suprafata = a.Suprafata,
                        Compartimentare = a.Compartimentare,
                        Etaj = a.Etaj,
                        Status = a.Status
                    }).ToList(),
                    Imagini = p.Imagini.Select(i => new ImagineDto
                    {
                        ImagineId = i.ImagineId,
                        Url = $"{Request.Scheme}://{Request.Host}/uploads/{Path.GetFileName(i.Url)}"
                    }).ToList()
                }).ToListAsync();

            return Ok(proiecte);
        }


        [HttpGet("proiect/{id:int}")]
        public async Task<ActionResult<ProiectGetDto>> GetProiect(int id)
        {
            var proiect = await _context.Proiecte
                .Where(p => p.ProiectId == id)
                .Select(p => new ProiectGetDto
                {
                    ProiectId = p.ProiectId,
                    Nume = p.Nume,
                    NumarApartamente = p.NumarApartamente,
                    Descriere1 = p.Descriere1,
                    Descriere2 = p.Descriere2,
                    ImgUrl = $"{Request.Scheme}://{Request.Host}/uploads/{p.UrlImgProiect}", // Setăm URL-ul imaginii în proprietatea corectă
            Apartamente = p.Apartamente.Select(a => new ApartamenteDto
                    {
                        ApartamentId = a.ApartamentId,
                        NumarApartament = a.NumarApartament,
                        NumarCamere = a.NumarCamere,
                        Suprafata = a.Suprafata,
                        Compartimentare = a.Compartimentare,
                        Etaj = a.Etaj,
                        Status = a.Status
                    }).ToList(),
                    Imagini = p.Imagini.Select(i => new ImagineDto
                    {
                        ImagineId = i.ImagineId,
                        Url = $"{Request.Scheme}://{Request.Host}/uploads/{i.Url}"
                    }).ToList()
                }).FirstOrDefaultAsync();

            if (proiect == null)
            {
                return NotFound();
            }

            return Ok(proiect);
        }


        [HttpPost("adaugare_proiect")]
        public async Task<ActionResult<ProiectGetDto>> CreateProiect([FromForm] ProiectPostDto proiectDto)
        {
            var proiect = new Proiect
            {
                Nume = proiectDto.Nume,
                NumarApartamente = proiectDto.NumarApartamente,
                Descriere1 = proiectDto.Descriere1,
                Descriere2 = proiectDto.Descriere2,
                Apartamente = proiectDto.Apartamente.Select(a => new Apartament
                {
                    NumarApartament = a.NumarApartament,
                    NumarCamere = a.NumarCamere,
                    Suprafata = a.Suprafata,
                    Compartimentare = a.Compartimentare,
                    Etaj = a.Etaj,
                    Status = a.Status
                }).ToList(),
                Imagini = proiectDto.Imagini.Select(i => new Imagine
                {
                    Url = SaveImage(i) // Metodă pentru a salva imaginea și a returna URL-ul ei
                }).ToList()
            };

            if (proiectDto.UrlImgProiect != null)
            {
                proiect.UrlImgProiect = SaveImage(proiectDto.UrlImgProiect); // Metodă pentru a salva imaginea și a returna URL-ul
            }

            _context.Proiecte.Add(proiect);
            await _context.SaveChangesAsync();

            var proiectGetDto = new ProiectGetDto
            {
                ProiectId = proiect.ProiectId,
                Nume = proiect.Nume,
                NumarApartamente = proiect.NumarApartamente,
                Descriere1 = proiect.Descriere1,
                Descriere2 = proiect.Descriere2,
                ImgUrl = $"{Request.Scheme}://{Request.Host}/uploads/{proiect.UrlImgProiect}",
                Apartamente = proiect.Apartamente.Select(a => new ApartamenteDto
                {
                    ApartamentId = a.ApartamentId,
                    NumarApartament = a.NumarApartament,
                    NumarCamere = a.NumarCamere,
                    Suprafata = a.Suprafata,
                    Compartimentare = a.Compartimentare,
                    Etaj = a.Etaj,
                    Status = a.Status
                }).ToList(),
                Imagini = proiect.Imagini.Select(i => new ImagineDto
                {
                    ImagineId = i.ImagineId,
                    Url = $"{Request.Scheme}://{Request.Host}/uploads/{i.Url}"
                }).ToList()
            };

            return CreatedAtAction(nameof(GetProiect), new { id = proiect.ProiectId }, proiectGetDto);
        }

        private string SaveImage(IFormFile image)
        {
            // Specificăm directorul de încărcare
            var uploadsDir = @"D:\LinkedIn\Licenta\uploads";

            // Asigurăm că directorul există
            if (!Directory.Exists(uploadsDir))
            {
                Directory.CreateDirectory(uploadsDir);
            }

            // Generăm un nume unic pentru fișier pentru a evita coliziunile
            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);
            var filePath = Path.Combine(uploadsDir, fileName);

            // Salvăm fișierul pe disc
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                image.CopyTo(stream);
            }

            // Returnăm calea relativă a fișierului
            return Path.Combine("uploads", fileName).Replace("\\", "/");
        }

        [HttpDelete("sterge_proiect/{id:int}")]
        public async Task<IActionResult> DeleteProiect(int id)
        {
            var proiect = await _context.Proiecte.FindAsync(id);
            if (proiect == null)
            {
                return NotFound();
            }

            _context.Proiecte.Remove(proiect);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("casavanduta")]
        public async Task<ActionResult> GetCasaVandutas()
        {
            try
            {
                return Ok(await _adminRepository.GetCasaVandutas());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpGet("casavanduta/{id:int}")]
        public async Task<ActionResult<CasaVanduta>> GetCasaVanduta(int id)
        {
            try
            {
                var result = await _adminRepository.GetCasaVanduta(id);

                if (result == null)
                {
                    return NotFound();
                }

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpPost("casavanduta")]
        public async Task<ActionResult<CasaVanduta>> CreateCasaVanduta(CasaVanduta casaVanduta)
        {
            try
            {
                if (casaVanduta == null)
                    return BadRequest();

                var createdCasaVanduta = await _adminRepository.AddCasaVanduta(casaVanduta);

                return CreatedAtAction(nameof(GetCasaVanduta),
                    new { id = createdCasaVanduta.CasaId }, createdCasaVanduta);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new CasaVanduta record");
            }
        }

        [HttpPut("casavanduta/{id:int}")]
        public async Task<ActionResult<CasaVanduta>> UpdateCasaVanduta(int id, CasaVanduta casaVanduta)
        {
            try
            {
                if (id != casaVanduta.CasaId)
                    return BadRequest("CasaVanduta ID mismatch");

                var casaToUpdate = await _adminRepository.GetCasaVanduta(id);

                if (casaToUpdate == null)
                {
                    return NotFound($"CasaVanduta with Id = {id} not found");
                }

                return await _adminRepository.UpdateCasaVanduta(casaVanduta);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating CasaVanduta record");
            }
        }

        [HttpDelete("casavanduta/{id:int}")]
        public async Task<ActionResult> DeleteCasaVanduta(int id)
        {
            try
            {
                var casaToDelete = await _adminRepository.GetCasaVanduta(id);

                if (casaToDelete == null)
                {
                    return NotFound($"CasaVanduta with Id = {id} not found");
                }

                await _adminRepository.DeleteCasaVanduta(id);

                return Ok($"CasaVanduta with Id = {id} deleted");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting CasaVanduta record");
            }
        }

        [HttpPost("contracte-apartamente")]
        [Authorize]
        public async Task<ActionResult<ContracteApartamenteDto>> CreateContracteApartamente([FromBody] ContracteApartamenteCreateDto contractDto)
        {
            var adminIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (adminIdClaim == null)
            {
                return Unauthorized("Admin ID not found in token");
            }

            var adminId = int.Parse(adminIdClaim.Value);

            var apartament = await _context.Apartamente.FindAsync(contractDto.ApartamentId);
            if (apartament == null)
            {
                return NotFound("Apartament not found");
            }

            if (apartament.Status != "disponibil")
            {
                return BadRequest("Apartament is not available");
            }

            var contract = new ContracteApartamente
            {
                AdminId = adminId,
                UserId = contractDto.UserId,
                ApartamentId = contractDto.ApartamentId,
                DataSemnarii = contractDto.DataSemnarii,
                Costuri = contractDto.Costuri,
                PretVanzare = contractDto.PretVanzare
            };

            _context.ContracteApartamentes.Add(contract);

            // Schimbăm statusul apartamentului
            apartament.Status = "indisponibil";

            await _context.SaveChangesAsync();

            var resultDto = new ContracteApartamenteDto
            {
                ContractApId = contract.ContractApId,
                AdminId = contract.AdminId,
                UserId = contract.UserId,
                ApartamentId = contract.ApartamentId,
                DataSemnarii = contract.DataSemnarii,
                Costuri = contract.Costuri,
                PretVanzare = contract.PretVanzare
            };

            return CreatedAtAction(nameof(GetContracteApartamente), new { id = contract.ContractApId }, resultDto);
        }

        // Metoda pentru a citi toate contractele
        [HttpGet("contracte-apartamente")]
        public async Task<ActionResult<IEnumerable<ContracteApartamenteDetailedDto>>> GetContracteApartamente()
        {
            var contracte = await _context.ContracteApartamentes
                .Include(c => c.AdminUser)
                .Include(c => c.User)
                .Include(c => c.Apartament)
                .ThenInclude(a => a.Proiect)
                .Select(c => new ContracteApartamenteDetailedDto
                {
                    ContractApId = c.ContractApId,
                    AdminEmail = c.AdminUser.Email,
                    UserFullName = $"{c.User.FirstName} {c.User.LastName}",
                    NumarApartament = c.Apartament.NumarApartament,
                    NumeProiect = c.Apartament.Proiect.Nume,
                    DataSemnarii = c.DataSemnarii,
                    Costuri = c.Costuri,
                    PretVanzare = c.PretVanzare
                }).ToListAsync();

            return Ok(contracte);
        }

        // Metoda pentru a citi un contract specific
        [HttpGet("contracte-apartamente/{id:int}")]
        public async Task<ActionResult<ContracteApartamenteDto>> GetContracteApartamente(int id)
        {
            var contract = await _context.ContracteApartamentes
                .Where(c => c.ContractApId == id)
                .Select(c => new ContracteApartamenteDto
                {
                    ContractApId = c.ContractApId,
                    AdminId = c.AdminId,
                    UserId = c.UserId,
                    ApartamentId = c.ApartamentId,
                    DataSemnarii = c.DataSemnarii,
                    Costuri = c.Costuri,
                    PretVanzare = c.PretVanzare
                }).FirstOrDefaultAsync();

            if (contract == null)
            {
                return NotFound();
            }

            return Ok(contract);
        }

        // Metoda pentru a șterge un contract
        [HttpDelete("contracte-apartamente/{id:int}"), Authorize]
        public async Task<IActionResult> DeleteContracteApartamente(int id)
        {
            var contract = await _context.ContracteApartamentes.FindAsync(id);
            if (contract == null)
            {
                return NotFound();
            }

            var apartament = await _context.Apartamente.FindAsync(contract.ApartamentId);
            if (apartament != null)
            {
                apartament.Status = "disponibil";
            }

            _context.ContracteApartamentes.Remove(contract);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPost("contracte-case")]
        [Authorize]
        public async Task<ActionResult<ContracteCaseDto>> CreateContracteCase([FromBody] ContracteCaseCreateDto contractDto)
        {
            var adminIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (adminIdClaim == null)
            {
                return Unauthorized("Admin ID not found in token");
            }

            var adminId = int.Parse(adminIdClaim.Value);

            var casa = await _context.CasaVandutas.FindAsync(contractDto.CasaId);
            if (casa == null)
            {
                return NotFound("Casa not found");
            }

            

            var contract = new ContracteCase
            {
                AdminId = adminId,
                UserId = contractDto.UserId,
                CasaId = contractDto.CasaId,
                DataSemnarii = contractDto.DataSemnarii,
                Costuri = contractDto.Costuri,
                PretVanzare = contractDto.PretVanzare
            };

            _context.ContracteCases.Add(contract);

            // Schimbăm statusul casei
            

            await _context.SaveChangesAsync();

            var resultDto = new ContracteCaseDto
            {
                ContractCId = contract.ContractCId,
                AdminId = contract.AdminId,
                UserId = contract.UserId,
                CasaId = contract.CasaId,
                DataSemnarii = contract.DataSemnarii,
                Costuri = contract.Costuri,
                PretVanzare = contract.PretVanzare
            };

            return CreatedAtAction(nameof(GetContracteCase), new { id = contract.ContractCId }, resultDto);
        }

        // Metoda pentru a citi toate contractele
        [HttpGet("contracte-case")]
        public async Task<ActionResult<IEnumerable<ContracteCaseDetailedDto>>> GetContracteCase()
        {
            var contracte = await _context.ContracteCases
                .Include(c => c.AdminUser)
                .Include(c => c.User)
                .Include(c => c.CasaVanduta)
                
                .Select(c => new ContracteCaseDetailedDto
                {
                    ContractCId = c.ContractCId,
                    AdminEmail = c.AdminUser.Email,
                    UserFullName = $"{c.User.FirstName} {c.User.LastName}",
                    Adresa = c.CasaVanduta.Adresa,
                    
                    DataSemnarii = c.DataSemnarii,
                    Costuri = c.Costuri,
                    PretVanzare = c.PretVanzare
                }).ToListAsync();

            return Ok(contracte);
        }

        // Metoda pentru a citi un contract specific
        [HttpGet("contracte-case/{id:int}")]
        public async Task<ActionResult<ContracteCaseDto>> GetContracteCase(int id)
        {
            var contract = await _context.ContracteCases
                .Where(c => c.ContractCId == id)
                .Select(c => new ContracteCaseDto
                {
                    ContractCId = c.ContractCId,
                    AdminId = c.AdminId,
                    UserId = c.UserId,
                    CasaId = c.CasaId,
                    DataSemnarii = c.DataSemnarii,
                    Costuri = c.Costuri,
                    PretVanzare = c.PretVanzare
                }).FirstOrDefaultAsync();

            if (contract == null)
            {
                return NotFound();
            }

            return Ok(contract);
        }

        // Metoda pentru a șterge un contract
        [HttpDelete("contracte-case/{id:int}"), Authorize]
        public async Task<IActionResult> DeleteContracteCase(int id)
        {
            var contract = await _context.ContracteCases.FindAsync(id);
            if (contract == null)
            {
                return NotFound();
            }

            var casa = await _context.CasaVandutas.FindAsync(contract.CasaId);
            

            _context.ContracteCases.Remove(contract);
            await _context.SaveChangesAsync();

            return NoContent();
        }


    }
}

