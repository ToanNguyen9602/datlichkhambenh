using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public interface UserService
    {
        public bool Create(User user);

        public bool Exists(string username);

        public bool Login(string username, string password);

        public User findByUsername(string username);
    }
}
