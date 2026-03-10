using Inlammnig2API_WEBBUTECKLING.Data;
using Inlammnig2API_WEBBUTECKLING.Data.Enteties;
using Inlammnig2API_WEBBUTECKLING.Data.Interfaces;

namespace Inlammnig2API_WEBBUTECKLING.Repositories
{
    public class UserRepo : IUserRepo
    {
        private readonly AppDbContext _context;

        public UserRepo(AppDbContext context)
        {
            _context = context;
        }

        public Users CreateUser(Users user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;

        }

        public Users GetUserByemail(string email)
        {

            return _context.Users.FirstOrDefault(u => u.Email == email);
        }

        public Users GetUsersbyId(int id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == id);
        }

        public bool deleteUser(int id)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);

            if (user == null)
            return false;

            _context.Users.Remove(user);
            _context.SaveChanges();
            return true;

        }
    }
}