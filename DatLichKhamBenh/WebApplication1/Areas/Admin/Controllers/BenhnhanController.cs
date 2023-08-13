using Lombok.NET;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services;

namespace WebApplication1.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin/benhnhan")]
    [RequiredArgsConstructor]
    public partial class BenhnhanController : Controller
    {
        private readonly BennhanService bennhanService;
        private readonly LichKhamService lichKhamService;

        [Route("")]
        [Route("index")]
        [Route("benhnhan")]
        public IActionResult Index()
        {
            ViewBag.benhnhans = bennhanService.findAll();
            return View("Benhnhan");
        }

        [Route("searchLSKBn")]
        public IActionResult SearchLSKBn(int id)
        {
            ViewBag.ben = bennhanService.getById(id);
            ViewBag.lsKhams = lichKhamService.findLSkhamByMabn(id);
            return View("LSKBn");
        }
    }
}
