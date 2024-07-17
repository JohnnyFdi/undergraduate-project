using Microsoft.AspNetCore.Mvc;
using ClientRestApi.Models;
using System.Collections.Generic;
using System.Linq;
using ClientRestApi.House_Config;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace ClientRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HouseConfigController : ControllerBase
    {
        private readonly IHouseConfigRepository _houseConfigRepository;
        private readonly IConfiguration _configuration;
        private readonly IUserRepository _userRepository;
        


        public HouseConfigController(IConfiguration configuration, IHouseConfigRepository houseConfigRepository, IUserRepository userRepository)
        {
            _houseConfigRepository = houseConfigRepository;
            _configuration = configuration;
            _userRepository = userRepository;


        }


        [HttpGet("materials")]

        public async Task<ActionResult> GetMaterials()
        {
            try
            {
                return Ok(await _houseConfigRepository.GetMaterials());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpGet("finishes")]

        public async Task<ActionResult> GetFinishes()
        {
            try
            {
                return Ok(await _houseConfigRepository.GetFinishes());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpGet("heatings")]

        public async Task<ActionResult> GetHeatings()
        {
            try
            {
                return Ok(await _houseConfigRepository.GetHeatings());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpGet("ventilations")]

        public async Task<ActionResult> GetVentilations()
        {
            try
            {
                return Ok(await _houseConfigRepository.GetVentilations());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpGet("wastes")]

        public async Task<ActionResult> GetWastes()
        {
            try
            {
                return Ok(await _houseConfigRepository.GetWastes());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpPost("addHouseConfig")]
        [Authorize]
        public async Task<ActionResult<ConfigCasa>> AddHouseConfig([FromBody] HouseConfigDto houseConfigDto)
        {
            try
            {
                // Obține email-ul utilizatorului din token
                var email = User.FindFirstValue(ClaimTypes.Email);
                if (email == null)
                {
                    return Unauthorized("Email not found in token");
                }

                // Obține utilizatorul din baza de date folosind email-ul
                var user = await _userRepository.GetUserByEmail(email);
                if (user == null)
                {
                    return NotFound("User not found");
                }

                // Creăm obiectul ConfigCasa din DTO
                var configCasa = new ConfigCasa
                {
                    UserId = user.UserId,
                    Material = houseConfigDto.Material,
                    Finisaj = houseConfigDto.Finisaj,
                    TipIncalzire = houseConfigDto.TipIncalzire,
                    Ventilatie = houseConfigDto.Ventilatie,
                    ColectareReziduri = houseConfigDto.ColectareReziduri,
                    ConfigCameras = houseConfigDto.Camere.Select(c => new ConfigCamera
                    {
                        NumeCamera = c.NumeCamera,
                        Suprafata = c.Suprafata,
                        IncalzirePardoseala = c.IncalzirePardoseala
                    }).ToList()
                };

                // Salvăm ConfigCasa și camerele asociate în baza de date
                var createdConfigCasa = await _houseConfigRepository.AddHouseConfig(configCasa);

                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating new house configuration record");
            }
        }

        [HttpGet("getHouseConfig/{id:int}")]
        public async Task<ActionResult<HouseConfigResponseDto>> GetHouseConfig(int id)
        {
            try
            {
                var configCasa = await _houseConfigRepository.GetHouseConfigById(id);

                if (configCasa == null)
                {
                    return NotFound();
                }

                // Transformăm entitatea ConfigCasa într-un DTO
                var houseConfigDto = new HouseConfigResponseDto
                {
                    ConfigCasaId = configCasa.ConfigCasaId,
                    Material = configCasa.Material,
                    Finisaj = configCasa.Finisaj,
                    TipIncalzire = configCasa.TipIncalzire,
                    Ventilatie = configCasa.Ventilatie,
                    ColectareReziduri = configCasa.ColectareReziduri,
                    Camere = configCasa.ConfigCameras.Select(c => new CameraConfigDto
                    {
                        NumeCamera = c.NumeCamera,
                        Suprafata = c.Suprafata,
                        IncalzirePardoseala = c.IncalzirePardoseala
                    }).ToList()
                };

                return Ok(houseConfigDto);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        [HttpGet("getHouseConfigsByUserId/{userId:int}")]
        public async Task<ActionResult<IEnumerable<HouseConfigResponseDto>>> GetHouseConfigsByUserId(int userId)
        {
            try
            {
                var configCasas = await _houseConfigRepository.GetHouseConfigsByUserId(userId);

                if (configCasas == null || !configCasas.Any())
                {
                    return NotFound();
                }

                var houseConfigDtos = configCasas.Select(configCasa => new HouseConfigResponseDto
                {
                    ConfigCasaId = configCasa.ConfigCasaId,
                    Material = configCasa.Material,
                    Finisaj = configCasa.Finisaj,
                    TipIncalzire = configCasa.TipIncalzire,
                    Ventilatie = configCasa.Ventilatie,
                    ColectareReziduri = configCasa.ColectareReziduri,
                    Camere = configCasa.ConfigCameras.Select(c => new CameraConfigDto
                    {
                        NumeCamera = c.NumeCamera,
                        Suprafata = c.Suprafata,
                        IncalzirePardoseala = c.IncalzirePardoseala
                    }).ToList()
                }).ToList();

                return Ok(houseConfigDtos);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }
        /*
        [HttpPost("addHouseConfig")]
        [Authorize]
        public async Task<ActionResult<ConfigCasa>> AddHouseConfig([FromBody] HouseConfigDto houseConfigDto)
        {
            try
            {
                // Logging
                Console.WriteLine("Received HouseConfigDto:");
                Console.WriteLine($"Material: {houseConfigDto.Material}");
                Console.WriteLine($"Finisaj: {houseConfigDto.Finisaj}");
                Console.WriteLine($"TipIncalzire: {houseConfigDto.TipIncalzire}");
                Console.WriteLine($"Ventilatie: {houseConfigDto.Ventilatie}");
                Console.WriteLine($"ColectareReziduri: {houseConfigDto.ColectareReziduri}");
                Console.WriteLine($"Number of Camere: {houseConfigDto.Camere.Count}");

                var email = User.FindFirstValue(ClaimTypes.Email);
                if (email == null)
                {
                    return Unauthorized("Email not found in token");
                }

                var user = await _userRepository.GetUserByEmail(email);
                if (user == null)
                {
                    return NotFound("User not found");
                }

                var configCasa = new ConfigCasa
                {
                    UserId = user.UserId,
                    Material = houseConfigDto.Material,
                    Finisaj = houseConfigDto.Finisaj,
                    TipIncalzire = houseConfigDto.TipIncalzire,
                    Ventilatie = houseConfigDto.Ventilatie,
                    ColectareReziduri = houseConfigDto.ColectareReziduri,
                    ConfigCameras = houseConfigDto.Camere.Select(c => new ConfigCamera
                    {
                        NumeCamera = c.NumeCamera,
                        Suprafata = c.Suprafata,
                        IncalzirePardoseala = c.IncalzirePardoseala
                    }).ToList()
                };

                var createdConfigCasa = await _houseConfigRepository.AddHouseConfig(configCasa);

                return CreatedAtAction(nameof(GetHouseConfig), new { id = createdConfigCasa.ConfigCasaId }, createdConfigCasa);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new house configuration record");
            }
        }

        [HttpGet("getHouseConfig/{id:int}")]
        public async Task<ActionResult<ConfigCasa>> GetHouseConfig(int id)
        {
            try
            {
                var result = await _houseConfigRepository.GetHouseConfigById(id);

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
        } */
    }
}