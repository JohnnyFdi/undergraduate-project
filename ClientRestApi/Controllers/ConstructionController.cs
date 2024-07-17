using Microsoft.AspNetCore.Mvc;
using ClientRestApi.Models;
using System.Collections.Generic;
using System.Linq;
using ClientRestApi.Angajati;
using ClientRestApi.Constructori;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace ClientRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConstructionController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly AppDbContext _context;

        public ConstructionController(IConfiguration configuration, AppDbContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        // GET: api/Construction
        // GET: api/Construction
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EchipaConstructorBlocuriResponseDto>>> GetEchipeConstructori()
        {
            var echipe = await _context.EchipaConstructorBlocuris
                                       .Include(e => e.Proiect)
                                       .ToListAsync();

            var response = echipe.Select(e => new EchipaConstructorBlocuriResponseDto
            {
                ConstructorId = e.ConstructorId,
                ConsName = e.ConsName,
                ConsStatus = e.ConsStatus,
                ProiectId = e.ProiectId,
                Proiect = e.Proiect != null ? new ProiecteConstructorDto
                {
                    ProiectId = e.Proiect.ProiectId,
                    Nume = e.Proiect.Nume,
                    NumarApartamente = e.Proiect.NumarApartamente,
                    UrlImgProiect = e.Proiect.UrlImgProiect,
                    Descriere1 = e.Proiect.Descriere1,
                    Descriere2 = e.Proiect.Descriere2
                } : null
            }).ToList();

            return Ok(response);
        }

        // GET: api/Construction/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EchipaConstructorBlocuriResponseDto>> GetEchipaConstructor(int id)
        {
            var echipa = await _context.EchipaConstructorBlocuris
                                       .Include(e => e.Proiect)
                                       .FirstOrDefaultAsync(e => e.ConstructorId == id);

            if (echipa == null)
            {
                return NotFound();
            }

            var responseDto = new EchipaConstructorBlocuriResponseDto
            {
                ConstructorId = echipa.ConstructorId,
                ConsName = echipa.ConsName,
                ConsStatus = echipa.ConsStatus,
                ProiectId = echipa.ProiectId,
                Proiect = echipa.Proiect != null ? new ProiecteConstructorDto
                {
                    ProiectId = echipa.Proiect.ProiectId,
                    Nume = echipa.Proiect.Nume,
                    NumarApartamente = echipa.Proiect.NumarApartamente,
                    UrlImgProiect = echipa.Proiect.UrlImgProiect,
                    Descriere1 = echipa.Proiect.Descriere1,
                    Descriere2 = echipa.Proiect.Descriere2
                } : null
            };

            return Ok(responseDto);
        }

        // POST: api/Construction
        [HttpPost]
        public async Task<ActionResult<EchipaConstructorBlocuriResponseDto>> CreateEchipaConstructor(EchipaConstructoriBlocuriDto echipaDto)
        {
            var echipa = new EchipaConstructorBlocuri
            {
                ConsName = echipaDto.ConsName,
                ConsStatus = echipaDto.ConsStatus,
                ProiectId = echipaDto.ProiectId
            };

            _context.EchipaConstructorBlocuris.Add(echipa);
            await _context.SaveChangesAsync();

            // Încărcarea detaliilor proiectului asociat
            await _context.Entry(echipa).Reference(e => e.Proiect).LoadAsync();

            var responseDto = new EchipaConstructorBlocuriResponseDto
            {
                ConstructorId = echipa.ConstructorId,
                ConsName = echipa.ConsName,
                ConsStatus = echipa.ConsStatus,
                ProiectId = echipa.ProiectId,
                Proiect = echipa.Proiect != null ? new ProiecteConstructorDto
                {
                    ProiectId = echipa.Proiect.ProiectId,
                    Nume = echipa.Proiect.Nume,
                    NumarApartamente = echipa.Proiect.NumarApartamente,
                    UrlImgProiect = echipa.Proiect.UrlImgProiect,
                    Descriere1 = echipa.Proiect.Descriere1,
                    Descriere2 = echipa.Proiect.Descriere2
                } : null
            };

            return CreatedAtAction(nameof(GetEchipaConstructor), new { id = echipa.ConstructorId }, responseDto);
        }




        // PUT: api/Construction/5

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEchipaConstructor(int id, EchipaConstructoriBlocuriUpdateDto echipaDto)
        {
            var echipa = await _context.EchipaConstructorBlocuris
                                       .FirstOrDefaultAsync(e => e.ConstructorId == id);

            if (echipa == null)
            {
                return NotFound();
            }

            // Păstrează ID-ul proiectului curent înainte de a face "unassign"
            var currentProiectId = echipa.ProiectId;

            // Actualizează doar ProiectId și ConsStatus în funcție de ProiectId
            echipa.ProiectId = echipaDto.ProiectId;
            if (echipa.ProiectId != null)
            {
                echipa.ConsStatus = "indisponibil";
            }
            else
            {
                echipa.ConsStatus = "disponibil";
            }

            // Salvează modificările în baza de date
            _context.Entry(echipa).State = EntityState.Modified;

            // Adăugăm înregistrarea în istoricul asignărilor
            _context.AssignmentHistories.Add(new AssignmentHistory
            {
                ConstructorId = echipa.ConstructorId,
                ProiectId = echipaDto.ProiectId ?? currentProiectId, // Folosește ProiectId curent pentru unassign
                AssignedDate = DateTime.UtcNow,
                Action = echipaDto.ProiectId == null ? "unassign" : "assign",
                EstimatedTime = echipaDto.EstimatedTime // Adăugăm timpul estimat
            });

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EchipaConstructorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }




        /*[HttpPut("{id}")]
        public async Task<IActionResult> UpdateEchipaConstructor(int id, EchipaConstructoriBlocuriUpdateDto echipaDto)
        {
            var echipa = await _context.EchipaConstructorBlocuris
                                       .FirstOrDefaultAsync(e => e.ConstructorId == id);

            if (echipa == null)
            {
                return NotFound();
            }

            // Actualizează doar ProiectId și ConsStatus dacă ProiectId nu este null
            echipa.ProiectId = echipaDto.ProiectId;
            if (echipa.ProiectId != null)
            {
                echipa.ConsStatus = "indisponibil";
            }
            else
            {
                echipa.ConsStatus = "disponibil";
            }

            // Salvează modificările în baza de date
            _context.Entry(echipa).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EchipaConstructorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
        */

        // DELETE: api/Construction/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEchipaConstructor(int id)
        {
            var echipa = await _context.EchipaConstructorBlocuris.FindAsync(id);
            if (echipa == null)
            {
                return NotFound();
            }

            _context.EchipaConstructorBlocuris.Remove(echipa);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EchipaConstructorExists(int id)
        {
            return _context.EchipaConstructorBlocuris.Any(e => e.ConstructorId == id);
        }

        [HttpGet("history")]
        public async Task<ActionResult<IEnumerable<AssignmentHistory>>> GetAssignmentHistory()
        {
            return await _context.AssignmentHistories
                                 .OrderByDescending(h => h.AssignedDate)
                                 .ToListAsync();
        }
    }
}
