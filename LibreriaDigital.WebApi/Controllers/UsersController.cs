using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using LibreriaDigital.Domain.Entities;
using LibreriaDigital.Application.Interfaces;
using LibreriaDigital.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibreriaDigital.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UsersController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

[HttpGet]
        [ProducesResponseType(typeof(IEnumerable<UserDetailsDto>), 200)]
        public async Task<ActionResult<IEnumerable<UserDetailsDto>>> GetUsers()
        {
            var users = await _userRepository.GetAllAsync();

            if (users == null)
            {
                return NotFound();
            }

            var userDtos = _mapper.Map<IEnumerable<UserDetailsDto>>(users);

            return Ok(userDtos);
        }
        
        // GET: api/Users/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(UserDetailsDto), 200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<UserDetailsDto>> GetUser(int id)
        {
            var user = await _userRepository.GetByIdAsync(id); 

            if (user == null)
            {
                return NotFound();
            }

            var userDto = _mapper.Map<UserDetailsDto>(user);
            
            return Ok(userDto);
        }

        // POST: api/Users
        [HttpPost]
        [ProducesResponseType(typeof(UserDetailsDto), 201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<UserDetailsDto>> PostUser(UserCreateDto userDto)
        {
            var userEntity = _mapper.Map<User>(userDto);
            
            await _userRepository.AddAsync(userEntity);

            var createdUser = await _userRepository.GetByIdAsync(userEntity.Id);
            
            var createdUserDto = _mapper.Map<UserDetailsDto>(createdUser);

            return CreatedAtAction(nameof(GetUser), new { id = createdUserDto.Id }, createdUserDto);
        }
        
        // PUT: api/Users/5
        [HttpPut("{id}")]
        public async Task<ActionResult> PutUser(int id, UserCreateDto userDto)
        {

            if (!await _userRepository.ExistsAsync(id))
            {
                return NotFound();
            }
            
            var userToUpdate = _mapper.Map<User>(userDto);
            
            userToUpdate.Id = id;
            
            await _userRepository.UpdateAsync(userToUpdate);

            return NoContent();
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            if (!await _userRepository.ExistsAsync(id))
            {
                return NotFound();
            }

            await _userRepository.DeleteAsync(id);

            return NoContent();
        }
    }
}