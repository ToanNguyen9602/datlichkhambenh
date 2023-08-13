using Lombok.NET;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin/bacsi")]
    [RequiredArgsConstructor]
    public partial class BacsiController : Controller
    {
        private readonly BacsiService bacsiService;
        private readonly KhoaService khoaService;
        private readonly LichKhamService lichKhamService;

        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
            ViewBag.khoas = khoaService.findAll2();
            ViewBag.bacsis = bacsiService.findAll();
            return View("Bacsi");
        }

        [Route("fetchBacsi")]
        public IActionResult FetchBacsi()
        {
            return new JsonResult(new
            {
                bacsis = bacsiService.findAll()
            });
        }
        [Route("removeBacsi")]
        [HttpGet]
        public IActionResult RemoveBacsi(int id)
        {
            return new JsonResult(new
            {
                isSuccessful = bacsiService.RemoveBacsi(id)
            });
        }

        [Route("addBacsi")]
        [HttpPost]
        public IActionResult AddBacsi(string tenbs, int khoaId, string ngaysinh)
        {
            var bacsi = new Bacsi()
            {
                Makhoa = khoaId,
                Tenbs = tenbs,
                Ngaysinh = DateTime.ParseExact(ngaysinh, "MM/dd/yyyy", CultureInfo.InvariantCulture)
               
            };
            return new JsonResult(new
            {
                isSuccessful = bacsiService.CreateBacsi(bacsi)
            });
        }

        [Route("editBacsi")]
        [HttpGet]
        public IActionResult EditBacsi(int id)
        {
            return new JsonResult(new
            {
                bacsi = bacsiService.findById(id)
            });
        }

        [Route("editBacsi")]
        [HttpPost]
        public IActionResult EditBacsi(int id, int khoaId, string tenbs, string ngaysinh)
        {
            var bacsi = bacsiService.getById(id);
            bacsi.Makhoa = khoaId;
            bacsi.Tenbs = tenbs;
            bacsi.Ngaysinh = DateTime.ParseExact(ngaysinh, "MM/dd/yyyy", CultureInfo.InvariantCulture);
            return new JsonResult(new
            {
                isSuccessful = bacsiService.UpdateBacsi(bacsi)
            });
        }

        [Route("info")]
        [HttpGet]
        public IActionResult Info(int id) 
        {
            ViewBag.idBacsi = id;
            ViewBag.lichkhams = lichKhamService.findLichKhamByMabs(id);
            return View("LKBacsi");
        }

        [Route("fetchLichKham")]
        [HttpGet]
        public IActionResult SearchLichKham(int id, string start, string end)
        {
            var startTime = DateTime.ParseExact(start, "MM/dd/yyyy", CultureInfo.InvariantCulture);
            var endTime = DateTime.ParseExact(end, "MM/dd/yyyy", CultureInfo.InvariantCulture);

            return new JsonResult(new
            {
                lichkhams = lichKhamService.SearchLKBetweenSE(startTime, endTime, id)
            });
        }
    }
}
