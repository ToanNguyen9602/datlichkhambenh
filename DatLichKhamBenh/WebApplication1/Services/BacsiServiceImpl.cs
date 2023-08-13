using Lombok.NET;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    [RequiredArgsConstructor]
    public partial class BacsiServiceImpl : BacsiService
    {
        private readonly DatabaseContext db;

        public bool CreateBacsi(Bacsi bacsi)
        {
            try
            {
                db.Bacsis.Add(bacsi);
                return db.SaveChanges() > 0;
            } catch (Exception ex)
            {
                return false;
            }
        }

        public dynamic findAll()
        {
            return db.Bacsis.Select(b => new
            {
                Mabs = b.Mabs,
                Tenbs = b.Tenbs,
                Ngaysinh = b.Ngaysinh,
                Makhoa = b.Makhoa,
                Khoa = b.Khoa.Tenkhoa
            }).ToList();
        }

        public dynamic findById(int id)
        {
           var bacsi = db.Bacsis.Find(id);
            return new
            {
                Mabs = bacsi.Mabs,
                Tenbs = bacsi.Tenbs,
                Ngaysinh = bacsi.Ngaysinh,
                Makhoa = bacsi.Makhoa,
                Khoa = bacsi.Khoa.Tenkhoa
            };
        }

        public List<Bacsi> findByKhoaId(int id)
        {
           return db.Bacsis.Where(bs => bs.Makhoa == id).ToList();
        }

        public Bacsi getById(int id)
        {
            return db.Bacsis.Find(id);
        }

        public bool RemoveBacsi(int id)
        {
            try
            {
                db.Bacsis.Remove(db.Bacsis.Find(id));
                return db.SaveChanges() > 0;
            } catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateBacsi(Bacsi bacsi)
        {
            try {
                db.Entry(bacsi).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                return db.SaveChanges() > 0;
            } catch { return false; }
        }
    }
}
