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

namespace ClientRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HouseConfigController : ControllerBase
    {
        private readonly IHouseConfigRepository _houseConfigRepository;
        private readonly IConfiguration _configuration;


        public HouseConfigController(IConfiguration configuration, IHouseConfigRepository houseConfigRepository)
        {
            _houseConfigRepository = houseConfigRepository;
            _configuration = configuration;


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
    }
}