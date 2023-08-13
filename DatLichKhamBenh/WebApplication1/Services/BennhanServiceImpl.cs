using Lombok.NET;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    [RequiredArgsConstructor]

    public partial class BennhanServiceImpl : BennhanService
    {
        private readonly DatabaseContext db;

        public bool CreateBn(Benhnhan bennhan)
        {
            try
            {
                db.Benhnhans.Add(bennhan);
                return db.SaveChanges() > 0;
            } catch
            { return false; }
        }

        public List<Benhnhan> findAll()
        {
            return db.Benhnhans.ToList();
        }

        public Benhnhan getById(int id)
        {
            return db.Benhnhans.Find(id);
        }

        public Benhnhan getByUsername(string username)
        {
            return db.Benhnhans.Where(bn => bn.User.Username == username).FirstOrDefault();
        }

        public bool isExist(int keyword)
        {
            return db.Benhnhans.Count(x => x.Mabn == keyword) > 0;
        }
    }
}
