using TP_Final_APIs.Models.DTOs.Requests;
using TP_Final_APIs.Models.DTOs.Responses;
using TP_Final_APIs.Services.Interfaces;
using TP_Final_APIs.Repositories.Interfaces;
using TP_Final_APIs.Entities;

namespace TP_Final_APIs.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService (IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public UserDto CreateRestaurant(CreateAndUpdateUserDto newRestaurantDto)
        {
            User user = new()
            {
                Name = newRestaurantDto.Name,
                Password = newRestaurantDto.Password,
                Mail = newRestaurantDto.Mail,
                Status = newRestaurantDto.Status,
                Phone = newRestaurantDto.Phone,
                Categories = newRestaurantDto.Categories,
            };

            _userRepository.CreateRestaurant(user);

            UserDto userDto = new()
            {
                Name = user.Name,
                Password = user.Password,
                Mail = user.Mail,
                Status = user.Status,
                Phone = user.Phone,
                Categories = user.Categories,
            };
            return userDto;

        }

        public void DeleteUser(int idUser)
        {
            _userRepository.DeleteUser(idUser);
        }

        public IEnumerable<UserDto> GetAllRestaurants()
        {
            var IEnumerable = _userRepository.GetAllRestaurants().Select(user => new UserDto
            {
                Name = user.Name,
                Password = user.Password,
                Mail = user.Mail,
                Status = user.Status,
                Phone = user.Phone,
                Categories = user.Categories,
            });
            return IEnumerable;
        }

        public void UpdateUser(CreateAndUpdateUserDto updatedUserDto, int idUser)
        {
            User updatedUser = new User()
            {
                Name = updatedUserDto.Name,
                Password = updatedUserDto.Password,
                Mail = updatedUserDto.Mail,
                Status = updatedUserDto.Status,
                Phone = updatedUserDto.Phone,
                Categories = updatedUserDto.Categories,
            };

            _userRepository.UpdateUser(updatedUser, idUser);
            
        }

        public bool CheckIfUserExists(int idUser)
        {
            var response = _userRepository.CheckIfUserExists(idUser);
            return response;
        }

        public User? Authenticate(string email, string password)
        {
            var user = _userRepository.GetByEmail(email);

            if (user is null)
                return null;

            if (user.Password == password)
                return user;

            return null;
        }
    }
}
