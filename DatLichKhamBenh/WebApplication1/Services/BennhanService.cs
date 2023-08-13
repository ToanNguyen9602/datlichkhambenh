using WebApplication1.Areas.Admin.Controllers;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public interface BennhanService
    {
        public bool CreateBn(Benhnhan bennhan);
        public List<Benhnhan> findAll();
        public Benhnhan getById(int id);

        public Benhnhan getByUsername(string username);
        public bool isExist(int keyword);
    }
}
