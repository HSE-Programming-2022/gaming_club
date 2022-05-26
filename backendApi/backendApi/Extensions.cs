using backendApi.Dtos;
using backendApi.Entities;

namespace backendApi
{
    public static class Extensions
    {
        public static UserDto AsDto(this User user)
        {
            return new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Surname = user.Surname,
                Password = user.Password,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Balance = user.Balance,
                CreatedDate =  user.CreatedDate
            };
        } 
    }
}