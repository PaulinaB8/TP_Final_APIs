using TP_Final_APIs.Models.DTOs.Requests;
using TP_Final_APIs.Models.DTOs.Responses;

namespace TP_Final_APIs.Services.Interfaces
{
    public interface IUserService
    {
        IEnumerable<UserDto> getAllRestaurants();
        UserDto createRestaurant(CreateAndUpdateUserDto newRestaurantDto);
        void deleteUser(int idUser);
        void updateUser(CreateAndUpdateUserDto updatedUserDto, int idUser);

    }
}
