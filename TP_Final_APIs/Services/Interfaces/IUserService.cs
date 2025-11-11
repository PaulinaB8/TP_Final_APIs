using TP_Final_APIs.Entities;
using TP_Final_APIs.Models.DTOs.Requests;
using TP_Final_APIs.Models.DTOs.Responses;

namespace TP_Final_APIs.Services.Interfaces
{
    public interface IUserService
    {
        IEnumerable<UserDto> GetAllRestaurants();
        UserDto CreateRestaurant(CreateUserDto newRestaurantDto);
        void DeleteUser(int idUser);
        void UpdateUser(UpdateUserDto updatedUserDto, int idUser);
        bool CheckIfUserExists(int idUser);
        User? Authenticate(string email, string password);

    }
}
