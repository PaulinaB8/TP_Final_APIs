using TP_Final_APIs.Entities;

namespace TP_Final_APIs.Repositories.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<User> getAllRestaurants();
        void createRestaurant(User newRestaurant);
        void deleteUser(int idUser);
        void updateUser(User updatedUser, int idUser);
    }
}
