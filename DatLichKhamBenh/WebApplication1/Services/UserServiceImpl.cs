using Lombok.NET;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    [RequiredArgsConstructor]
    public partial class UserServiceImpl : UserService
    {
        private readonly DatabaseContext db;

        public bool Create(User account)
        {
            try
            {
                db.Users.Add(account);
                return db.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }

        public bool Exists(string username)
        {
            return db.Users.Count(a => a.Username == username) > 0;
        }

        public User findByUsername(string username)
        {
            return db.Users.SingleOrDefault(a => a.Username == username);
        }

        public bool Login(string username, string password)
        {
            try
            {
                var account = db.Users.SingleOrDefault(a => a.Username == username );
                if (account != null)
                {
                    return BCrypt.Net.BCrypt.Verify(password, account.Password);
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}
