using WebApplication1.Models;

namespace WebApplication1.Services
{
    public interface LichKhamService
    {
        public bool CreateLK(Lichkham lk);
        public List<Lichkham> findLichKhamByMabn(int mabn);
        public dynamic findLichKhamByMabs(int id);
        public List<Lichkham> findLSkhamByMabn(int id);
        public dynamic SearchLKBetweenSE(DateTime startTime, DateTime endTime, int id);
    }
}
