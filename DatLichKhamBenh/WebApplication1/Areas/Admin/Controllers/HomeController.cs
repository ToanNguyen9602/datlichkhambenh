using Lombok.NET;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin/home")]
    [RequiredArgsConstructor]
    public partial class HomeController : Controller
    {
        private readonly KhoaService khoaService;

      
        [Route("khoa")]
        [Route("index")]
      
        [Route("home")]
        [Route("")]
        public IActionResult Khoa()
        {
            ViewBag.khoas = khoaService.findAll();
            var khoa = new Khoa();


            return View("Khoa", khoa);
        }

        [Route("fetchKhoa")]
        [HttpGet]
        public IActionResult FecthKhoa()
        {
            var dsKhoa = khoaService.findAll();
            return new JsonResult(new
            {
                khoas = dsKhoa
            }); 
        }

        [Route("editKhoa")]
        [HttpGet]
        public IActionResult EditKhoa(int id)
        {   

            return new JsonResult(new
            {
                khoa = khoaService.findById(id)
            });
        }
        [Route("editKhoa")]
        [HttpPost]
        public IActionResult EditKhoa(int id, String tenKhoa)
        {
            return new JsonResult(new
            {
                isSuccessful = khoaService.UpdateKhoa(id, tenKhoa)
            });
        }
        [Route("addKhoa")]
        [HttpPost]
        public IActionResult CreateKhoa(string tenKhoa)
        {
            var khoa = new Khoa() {
                Tenkhoa = tenKhoa
            };
            return new JsonResult(new
            {
                isSuccessful = khoaService.CreateKhoa(khoa)
            });
        }

        [Route("removeKhoa")]
        [HttpGet]
        public IActionResult RemoveKhoa(int id)
        {
            return new JsonResult(new
            {
                isSuccessful = khoaService.RemoveKhoa(id)
            });
        }

    }
}
