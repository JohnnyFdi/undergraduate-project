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
    public class HouseConstructionController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly AppDbContext _context;

        public HouseConstructionController(IConfiguration configuration, AppDbContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        // GET: api/Construction
        // GET: api/Construction
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EchipaConstructorCaseResponseDto>>> GetEchipeConstructori()
        {
            var echipe = await _context.EchipaConstructorCases
                                       .Include(e => e.CasaVanduta)
                                       .ToListAsync();

            var response = echipe.Select(e => new EchipaConstructorCaseResponseDto
            {
                ConstructorCaseId = e.ConstructorCaseId,
                ConsName = e.ConsName,
                ConsStatus = e.ConsStatus,
                CasaId = e.CasaId,
                CasaVanduta = e.CasaVanduta != null ? new CaseConstructorDto
                {
                    CasaId = e.CasaVanduta.CasaId,
                    NumarCamere = e.CasaVanduta.NumarCamere,
                    Suprafata = e.CasaVanduta.Suprafata,
                    Etaje = e.CasaVanduta.Etaje,
                    Adresa = e.CasaVanduta.Adresa,
                    DetaliiCasa = e.CasaVanduta.DetaliiCasa
                } : null
            }).ToList();

            return Ok(response);
        }

        // GET: api/Construction/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EchipaConstructorCaseResponseDto>> GetEchipaConstructor(int id)
        {
            var echipa = await _context.EchipaConstructorCases
                                       .Include(e => e.CasaVanduta)
                                       .FirstOrDefaultAsync(e => e.ConstructorCaseId == id);

            if (echipa == null)
            {
                return NotFound();
            }

            var responseDto = new EchipaConstructorCaseResponseDto
            {
                ConstructorCaseId = echipa.ConstructorCaseId,
                ConsName = echipa.ConsName,
                ConsStatus = echipa.ConsStatus,
                CasaId = echipa.CasaId,
                CasaVanduta = echipa.CasaVanduta != null ? new CaseConstructorDto
                {
                    CasaId = echipa.CasaVanduta.CasaId,
                    NumarCamere = echipa.CasaVanduta.NumarCamere,
                    Suprafata = echipa.CasaVanduta.Suprafata,
                    Etaje = echipa.CasaVanduta.Etaje,
                    Adresa = echipa.CasaVanduta.Adresa,
                    DetaliiCasa = echipa.CasaVanduta.DetaliiCasa
                } : null
            };

            return Ok(responseDto);
        }

        // POST: api/Construction
        [HttpPost]
        public async Task<ActionResult<EchipaConstructorCaseResponseDto>> CreateEchipaConstructor(EchipaConstructoriCaseDto echipaDto)
        {
            var echipa = new EchipaConstructorCase
            {
                ConsName = echipaDto.ConsName,
                ConsStatus = echipaDto.ConsStatus,
                CasaId = echipaDto.CasaId
            };

            _context.EchipaConstructorCases.Add(echipa);
            await _context.SaveChangesAsync();

            // Încărcarea detaliilor proiectului asociat
            await _context.Entry(echipa).Reference(e => e.CasaVanduta).LoadAsync();

            var responseDto = new EchipaConstructorCaseResponseDto
            {
                ConstructorCaseId = echipa.ConstructorCaseId,
                ConsName = echipa.ConsName,
                ConsStatus = echipa.ConsStatus,
                CasaId = echipa.CasaId,
                CasaVanduta = echipa.CasaVanduta != null ? new CaseConstructorDto
                {
                    CasaId = echipa.CasaVanduta.CasaId,
                    NumarCamere = echipa.CasaVanduta.NumarCamere,
                    Suprafata = echipa.CasaVanduta.Suprafata,
                    Etaje = echipa.CasaVanduta.Etaje,
                    Adresa = echipa.CasaVanduta.Adresa,
                    DetaliiCasa = echipa.CasaVanduta.DetaliiCasa
                } : null
            };

            return CreatedAtAction(nameof(GetEchipaConstructor), new { id = echipa.ConstructorCaseId }, responseDto);
        }




        // PUT: api/Construction/5

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEchipaConstructor(int id, EchipaConstructoriCaseUpdateDto echipaDto)
        {
            var echipa = await _context.EchipaConstructorCases
                                       .FirstOrDefaultAsync(e => e.ConstructorCaseId == id);

            if (echipa == null)
            {
                return NotFound();
            }

            // Păstrează ID-ul proiectului curent înainte de a face "unassign"
            var currentProiectId = echipa.CasaId;

            // Actualizează doar ProiectId și ConsStatus în funcție de ProiectId
            echipa.CasaId = echipaDto.CasaId;
            if (echipa.CasaId != null)
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
            _context.AssignmentHistoryHouses.Add(new AssignmentHistoryHouse
            {
                ConstructorCaseId = echipa.ConstructorCaseId,
                CasaId = echipaDto.CasaId ?? currentProiectId, // Folosește ProiectId curent pentru unassign
                AssignedDate = DateTime.UtcNow,
                Action = echipaDto.CasaId == null ? "unassign" : "assign",
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
            var echipa = await _context.EchipaConstructorCases.FindAsync(id);
            if (echipa == null)
            {
                return NotFound();
            }

            _context.EchipaConstructorCases.Remove(echipa);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EchipaConstructorExists(int id)
        {
            return _context.EchipaConstructorCases.Any(e => e.ConstructorCaseId == id);
        }

        [HttpGet("history")]
        public async Task<ActionResult<IEnumerable<AssignmentHistoryHouse>>> GetAssignmentHistory()
        {
            return await _context.AssignmentHistoryHouses
                                 .OrderByDescending(h => h.AssignedDate)
                                 .ToListAsync();
        }
    }
}
