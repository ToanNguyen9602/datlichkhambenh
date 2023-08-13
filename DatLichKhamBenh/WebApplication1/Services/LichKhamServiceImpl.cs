using Lombok.NET;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    [RequiredArgsConstructor]
    public partial class LichKhamServiceImpl : LichKhamService
    {
        private readonly DatabaseContext db;

        public bool CreateLK(Lichkham lk)
        {
           if (db.Lichkhams.Count(lichKham => lichKham.Ngaykham == lk.Ngaykham && lichKham.Mabs == lk.Mabs) > 0)
            {
                return false;
            } else
            {
                db.Lichkhams.Add(lk);
                return db.SaveChanges() > 0;
            }
        }

        public List<Lichkham> findLichKhamByMabn(int mabn)
        {
            return db.Lichkhams.Where(lk => lk.Ngaykham >= DateTime.Now && lk.Mabn == mabn).ToList();
        }

        public dynamic findLichKhamByMabs(int id)
        {
            return db.Lichkhams.Where(x => x.Mabs == id).Select(lk => new
            {
                Id = lk.Id,
                Mabs = lk.Mabs,
                Mabn = lk.Mabn,
                Ngaykham = lk.Ngaykham,
                Noidung = lk.Noidung,
                Bacsi = lk.Bacsi.Tenbs,
                Bennhan = lk.Bennhan.Tenbn
            }).ToList();
        }

        public List<Lichkham> findLSkhamByMabn(int id)
        {
           return db.Lichkhams.Where(lk => lk.Mabn == id && (lk.Ngaykham < DateTime.Now)).ToList();
        }

        public dynamic SearchLKBetweenSE(DateTime startTime, DateTime endTime, int id)
        {
            return db.Lichkhams.Where(lk => lk.Mabs == id && (lk.Ngaykham >= startTime && lk.Ngaykham <= endTime)).Select(lk => new
            {
                Id = lk.Id,
                Mabs = lk.Mabs,
                Mabn = lk.Mabn,
                Ngaykham = lk.Ngaykham,
                Noidung = lk.Noidung,
                Bacsi = lk.Bacsi.Tenbs,
                Bennhan = lk.Bennhan.Tenbn
            }).ToList();
        }
    }
}
