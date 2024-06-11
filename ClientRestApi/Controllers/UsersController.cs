using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ClientRestApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace ClientRestApi.Controllers
{   [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public static User user = new User();
        private readonly IConfiguration _configuration;
        private readonly IUserRepository _userRepository;
        

        public UsersController(IConfiguration configuration, IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _configuration = configuration;
          
        }

        [HttpGet("search")]

        public async Task<ActionResult<IEnumerable<User>>> Search(string name, string email)
        {
            try
            {
                var result = await _userRepository.Search(name, email);

                if(result.Any())
                {
                    return Ok(result);
                }

                return NotFound();
            }

            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");

            }

        }

        [HttpGet]

        public async Task<ActionResult> GetUsers()
        {
            try
            {
                return Ok(await _userRepository.GetUsers());
            }
            catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpGet("{id:int}")]

        public async Task<ActionResult<User>> GetUser(int id)
        {
            try
            {
                var result = await _userRepository.GetUser(id);

                if(result == null)
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

        public async Task<ActionResult<User>> CreateUser(User user)
        {
            try
            {
                if (user == null)
                    return BadRequest();

                var us = await _userRepository.GetUserByEmail(user.Email);
                
                if(us !=null)
                {
                    ModelState.AddModelError("Email", "User email already in use");
                    return BadRequest(ModelState);
                }

                var createdUser = await _userRepository.AddUser(user);

                return CreatedAtAction(nameof(GetUser),
                    new { id = createdUser.UserId }, createdUser);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new User record");
            }
        }

        [HttpPost("login")]
        public async Task<ActionResult<User>> Login(UserDto request)
        {
            try
            {
                // Verificăm dacă email-ul există în baza de date
                var user = await _userRepository.GetUserByEmail(request.Email);

                if (user == null)
                {
                    return BadRequest("Email not found.");
                }

                // Verificăm dacă parola este corectă
                if (user.Password != request.Password)
                {
                    return BadRequest("Wrong password.");
                }

                string token = CreateToken(user);

                return Ok(token);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error during authentication");
            }
        }

        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim> {
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
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

        public async Task<ActionResult<User>> UpdateUser(int id, User user)
        {
            try
            {
                if (id != user.UserId)
                    return BadRequest("User ID mismatch");

                var userToUpdate = await _userRepository.GetUser(id);

                if(userToUpdate == null)
                {
                    return NotFound($"User with Id = {id} not found");
                }

                return await _userRepository.UpdateUser(user);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating User record");
            }
        }

        [HttpDelete("{id:int}")]

        public async Task<ActionResult> DeleteUser(int id)
        {
            try
            {
                var userToDelete = await _userRepository.GetUser(id);

                if(userToDelete == null)
                {
                    return NotFound($"User with Id= {id} not found");
                }

                await _userRepository.DeleteUser(id);

                return Ok($"User with Id = {id} deleted");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting User record");
            }
        }

        [HttpGet("profile"), Authorize]
        public async Task<ActionResult<User>> GetProfile()
        {
            try
            {
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

                return Ok(user);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving user data from the database");
            }
        }

        [HttpPut("profile"), Authorize]
        public async Task<ActionResult<User>> UpdateProfile(UserDtoUpdate updatedUserDto)
        {
            try
            {
                var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);

                if (userIdClaim == null)
                {
                    return Unauthorized("User ID not found in token");
                }

                var userId = int.Parse(userIdClaim.Value);

                var existingUser = await _userRepository.GetUser(userId);

                if (existingUser == null)
                {
                    return NotFound("User not found");
                }

                // Actualizăm doar numele, prenumele, email-ul și numărul de telefon
                existingUser.FirstName = updatedUserDto.FirstName ?? existingUser.FirstName;
                existingUser.LastName = updatedUserDto.LastName ?? existingUser.LastName;
                existingUser.Email = updatedUserDto.Email ?? existingUser.Email;
                existingUser.PhoneNumber = updatedUserDto.PhoneNumber ?? existingUser.PhoneNumber;

                var updatedUser = await _userRepository.UpdateUser(existingUser);

                return Ok(updatedUser);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating user profile");
            }
        }

    }
}
