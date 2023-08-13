using WebApplication1.Models;

namespace WebApplication1.Services
{
    public interface KhoaService
    {
        public dynamic findAll();
        public dynamic findById(int id);

        public List<Khoa> findAll2();
        public bool CreateKhoa(Khoa khoa);
        public bool UpdateKhoa(int id, string Tenkhoa);
        public bool RemoveKhoa(int id);
    }
}
