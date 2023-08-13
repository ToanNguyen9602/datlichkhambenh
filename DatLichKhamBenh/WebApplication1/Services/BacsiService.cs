using WebApplication1.Models;

namespace WebApplication1.Services
{
    public interface BacsiService
    {
        public bool CreateBacsi(Bacsi bacsi);
        public dynamic findAll();
        public dynamic findById(int id);
        public List<Bacsi> findByKhoaId(int id);
        public Bacsi getById(int id);
        public bool RemoveBacsi(int id);

        public bool UpdateBacsi(Bacsi bacsi);
    }
}
