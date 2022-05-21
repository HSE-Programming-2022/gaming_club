using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using backendApi.Dtos;
using backendApi.Entities;
using backendApi.Repositories;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Mvc;

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

        [HttpPost]
        public ActionResult<UserDto> CreateUser(CreateUserDto userDto)
        {
            StringBuilder hashedPass = new StringBuilder();

            using (SHA256 hash = SHA256Managed.Create()) {
                Encoding enc = Encoding.UTF8;
                Byte[] result = hash.ComputeHash(enc.GetBytes(userDto.Password));

                foreach (Byte b in result)
                    hashedPass.Append(b.ToString("x2"));
            }

            User user = new()
            {
                Id = Guid.NewGuid(),
                Name = userDto.Name,
                Surname = userDto.Surname,
                Password = hashedPass.ToString(),
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
                Name = userDto.Name,
                Surname = userDto.Surname,
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