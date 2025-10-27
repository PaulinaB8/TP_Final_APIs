using TP_Final_APIs.Data;
using TP_Final_APIs.Entities;
using TP_Final_APIs.Repositories.Interfaces;

namespace TP_Final_APIs.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        
        private readonly TpFinalContexts _context;

        public UserRepository(TpFinalContexts context)
        {
            _context = context;
        }

        public void CreateRestaurant(User newRestaurant)
        {
            _context.Users.Add(newRestaurant);
            //_context: SaveChanges();
            
        }

        public void DeleteUser(int idUser)
        {
            var userDeleted = _context.Users.FirstOrDefault(u => u.Id == idUser);
        }

        public IEnumerable<User> GetAllRestaurants()
        {
            return _context.Users;
        }

        

        public void UpdateUser(User updatedUser, int idUser)
        {
            _context.Users.Update(updatedUser);
            
        }

        public bool CheckIfUserExists(int idUser)
        {
            var userExistence = _context.Users.Any(user => user.Id == idUser);
            return userExistence;
        }
    }
}
