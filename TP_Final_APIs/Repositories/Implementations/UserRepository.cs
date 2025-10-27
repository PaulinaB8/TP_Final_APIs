using TP_Final_APIs.Entities;
using TP_Final_APIs.Repositories.Interfaces;

namespace TP_Final_APIs.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        public List<User> _context = new List<User>();


        public void CreateRestaurant(User newRestaurant)
        {
            _context.Add(newRestaurant);
            //_context: SaveChanges();
            
        }

        public void DeleteUser(int idUser)
        {
            var userDeleted = _context.FirstOrDefault(u => u.Id == idUser);
        }

        public IEnumerable<User> GetAllRestaurants()
        {
            return _context;
        }

        

        public void UpdateUser(User updatedUser, int idUser)
        {
            //User? user = _context.SingleOrDefault(user => user.Id == idUser);

            //if ( user is not null)
            //{
                
            //}
            throw new NotImplementedException();
        }

        public bool CheckIfUserExists(int idUser)
        {
            var userExistence = _context.Any(user => user.Id == idUser);
            return userExistence;
        }
    }
}
