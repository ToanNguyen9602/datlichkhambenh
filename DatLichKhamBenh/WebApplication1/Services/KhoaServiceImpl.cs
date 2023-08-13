using Lombok.NET;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    [RequiredArgsConstructor]
    public partial class KhoaServiceImpl : KhoaService
    {
        private readonly DatabaseContext db;

        public bool CreateKhoa(Khoa khoa)
        {
           db.Khoas.Add(khoa);
            return db.SaveChanges() > 0;
        }

        public dynamic findAll()
        {
            return db.Khoas.Select(k => new
            {
                Makhoa = k.Makhoa,
                Tenkhoa = k.Tenkhoa
            }).ToList();
        }

        public List<Khoa> findAll2()
        {
            return db.Khoas.ToList();
        }

        public dynamic findById(int id)
        {   
            var k = db.Khoas.Find(id);
            return new {
                Makhoa = k.Makhoa,
                Tenkhoa = k.Tenkhoa
            };
        }

        public bool RemoveKhoa(int id)
        {
            try
            {
                db.Khoas.Remove(db.Khoas.Find(id));
                return db.SaveChanges() > 0;
            }  catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateKhoa(int id, string Tenkhoa)
        {
            try
            {
                var khoa = db.Khoas.Find(id);
                khoa.Tenkhoa = Tenkhoa;
                db.Entry(khoa).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                return db.SaveChanges() > 0;
            } catch (Exception ex)
            {
                
                return false;
            }
        }
    }
}
