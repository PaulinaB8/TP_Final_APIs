using TP_Final_APIs.Entities;

namespace TP_Final_APIs.Repositories.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAllRestaurants();
        void CreateRestaurant(User newRestaurant);
        void DeleteUser(int idUser);
        void UpdateUser(User updatedUser, int idUser);
        bool CheckIfUserExists(int idUser);
    }
}
