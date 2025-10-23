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

        public UserDto createRestaurant(CreateAndUpdateUserDto newRestaurantDto)
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

            _userRepository.createRestaurant(user);

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

        public void deleteUser(int idUser)
        {
            _userRepository.deleteUser(idUser);
        }

        public IEnumerable<UserDto> getAllRestaurants()
        {
            var IEnumerable = _userRepository.getAllRestaurants().Select(user => new UserDto
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

        public void updateUser(CreateAndUpdateUserDto updatedUserDto, int idUser)
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

            _userRepository.updateUser(updatedUser, idUser);
            
        }
    }
}
