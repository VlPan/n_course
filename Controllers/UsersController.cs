using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using N_Course.API.Data;
using N_Course.API.Dtos;
using N_Course.API.Models;

namespace N_Course.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IDatingRepository _repo;
        private readonly IMapper _mapper;

        public UsersController(IDatingRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _repo.GetUsers();

            var usersToReturn = users;

            return Ok(usersToReturn);
        }

        [HttpGet("{id}", Name = "GetUser")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _repo.GetUser(id);

            var userToReturn = _mapper.Map<UserForDetailedDto>(user);

            return Ok(userToReturn);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, UserForUpdateDto userForUpdateDto)
        {
            var userFromRepo = await _repo.GetUser(id);
            System.Diagnostics.Debug.WriteLine(userFromRepo);
            _mapper.Map(userForUpdateDto, userFromRepo);

            if (await _repo.SaveAll())
                return NoContent();

            throw new Exception($"Updating user {id} failed on save");
        }

        [HttpDelete("{id}")]
         public async Task<IActionResult> RemoveUser(int id)
        {
            var userFromRepo = await _repo.GetUser(id);
            _repo.Delete(userFromRepo);

            if (await _repo.SaveAll())
                return NoContent();

            throw new Exception($"Updating user {id} failed on save");
        }

        [HttpPost]
         public async Task<IActionResult> CreateUser(UserForCreateDto userForCreatingDto)
        {
     
            var userToCreate = _mapper.Map<User>(userForCreatingDto);
            _repo.Add(userToCreate);

            if (await _repo.SaveAll())
                return NoContent();

            throw new Exception($"Updating user failed on save");
        }


    }
}