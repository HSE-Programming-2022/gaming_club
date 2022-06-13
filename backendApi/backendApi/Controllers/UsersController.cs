using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using backendApi.Dtos;
using backendApi.Entities;
using backendApi.Repositories;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Matching;

namespace backendApi.Controllers
{
    [ApiController]
    [Route("users")]
    public class UsersController : ControllerBase
    {
        private readonly IUsersRepository repository;

        public UsersController(IUsersRepository repository)
        {
            this.repository = repository;
        }

        private string GetHashFromString(string str)
        {
            StringBuilder hashedPass = new StringBuilder();
            using (SHA256 hash = SHA256Managed.Create()) {
                Encoding enc = Encoding.UTF8;
                Byte[] result = hash.ComputeHash(enc.GetBytes(str));

                foreach (Byte b in result)
                    hashedPass.Append(b.ToString("x2"));
            }

            return hashedPass.ToString();
        }
        
        [HttpGet]
        public IEnumerable<UserDto> GetUsers()
        {
            var items = repository.GetUsers().Select(item => item.AsDto());
            return items;
        }

        [HttpGet("{id}")]
        public ActionResult<UserDto> GetUser(Guid id)
        {
            var user = repository.GetUser(id);
            if (user is null)
            {
                return NotFound();
            }
            
            return user.AsDto();
        }

        [HttpPost("login")]
        public ActionResult<UserDto> LoginUser(VerifyUserDto userDto)
        {
            var user = repository.GetUserByEmail(userDto.Email);
            if (user is null)
            {
                return BadRequest();
            }
            if (GetHashFromString(userDto.Password) == user.Password)
            {
                return CreatedAtAction(nameof(GetUser), new {id = user.Id}, user.AsDto());
            }
            return BadRequest();
        }
        
        [HttpPost("verify")]
        public ActionResult<UserDto> GetUser(VerifyUserDto userDto)
        {
            Thread.Sleep(3000);
            var user = repository.GetUserByEmail(userDto.Email);
            if (user is null)
            {
                return NotFound();
            }


            if (userDto.Password == user.Password)
            {
                return Ok();
            }

            return NotFound();
        }

        [HttpPost]
        public ActionResult<UserDto> CreateUser(CreateUserDto userDto)
        {
            if (repository.GetUserByEmail(userDto.Email) is not null ||
                repository.GetUserByEmail(userDto.PhoneNumber) is not null)
            {
                return Conflict();
            }

            User user = new()
            {
                Id = Guid.NewGuid(),
                Name = userDto.Name,
                Surname = userDto.Surname,
                Password = GetHashFromString(userDto.Password),
                Email = userDto.Email,
                PhoneNumber = userDto.PhoneNumber,
                Balance = userDto.Balance,
                CreatedDate = DateTimeOffset.Now
            };
            
            repository.CreateUser(user);
            return CreatedAtAction(nameof(GetUser), new {id = user.Id}, user.AsDto());
        }

        [HttpPut("{id}")]
        public ActionResult UpdateUser(Guid id, UpdateUserDto userDto)
        {
            var user = repository.GetUser(id);
            if (user is null)
            {
                return NotFound();
            }

            User updatedUser = user with
            {
                Email = userDto.Email,
                Balance = userDto.Balance
            };
            repository.UpdateUser(updatedUser);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteItem(Guid id)
        {
            var user = repository.GetUser(id);
            if (user is null)
            {
                return NotFound();
            }
            
            repository.DeleteUser(user);
            return NoContent();
        }
        
    }
}