using Lombok.NET;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Areas.Users.Controllers
{
    [Area("user")]
    [Route("user/user")]
    [RequiredArgsConstructor]
    public partial class UserController : Controller
    {
        private readonly KhoaService khoaService;
        private readonly BacsiService bacsiService;
        private readonly LichKhamService lichKhamService;
        private readonly BennhanService bennhanService;

        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {   
            ViewBag.khoas = khoaService.findAll();
            return View("Khoa");
        }

        [Route("dsBacsi")]
        public IActionResult DSBacsi(int id)
        {   
            ViewBag.khoa = khoaService.findById(id);
            ViewBag.bacsis = bacsiService.findByKhoaId(id);
            return View("Bacsi");
        }

        [Route("getBsById")]
        [HttpGet]
        public IActionResult GetBsById(int id)
        {
            return new JsonResult(new
            {
                bs = bacsiService.findById(id)
            });
        }

        [Route("datLichKham")]
        [HttpPost]

        public IActionResult DatLichKham(int mabs, string ngaykham, string noidung)
        {
            var lk = new Lichkham()
            {
                Mabs = mabs,
                Mabn = Convert.ToInt32(HttpContext.Session.GetString("mabn")),
                Ngaykham = DateTime.ParseExact(ngaykham, "MM/dd/yyyy", CultureInfo.InvariantCulture),
                Noidung = noidung
            };
            return new JsonResult(new 
            {
                isSuccessful = lichKhamService.CreateLK(lk)
            });
           
        }
        [Route("searchBn")]
        public IActionResult SearchBn(int keyword)
        {
            return new JsonResult(new
            {
                isExist = bennhanService.isExist(keyword)
            }) ; 
        }

        [Route("infoBn")]
        public IActionResult InfoBenhNhan(int mabn)
        {
            ViewBag.bn = bennhanService.getById(mabn);
            return View("InfoBn");
        }
        [Route("infoLKbn")]
        public IActionResult InfoLKBenhnhan()   
        {   
            var mabn = Convert.ToInt32(HttpContext.Session.GetString("mabn"));
            ViewBag.lichkhams = lichKhamService.findLichKhamByMabn(mabn);
            return View("LSKBn");
        }
     }
}
