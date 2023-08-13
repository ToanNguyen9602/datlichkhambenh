using Lombok.NET;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [Route("account")]
    [RequiredArgsConstructor]
    public partial class AccountController : Controller
    {
        private readonly UserService userService;
        private readonly BennhanService bennhanService;

        [Route("register")]
        [HttpGet]
        public IActionResult Register()
        {
            var bn = new Benhnhan();
            return View("Register", bn);
        }
        [Route("register")]
        [HttpPost]
        public IActionResult Register(Benhnhan bennhan, string username, string password, string gender) 
        {
            if (userService.Exists(username))
            {
                TempData["msg"] = "Awwwww... wrong choice of username";
                return RedirectToAction("register");
            }
            else
            {
                var user = new User()
                {
                    Username = username,
                    Password = BCrypt.Net.BCrypt.HashPassword(password),
                    Role = false
                };
                bennhan.User = user;
                bennhan.Gioitinh = gender;
                if (bennhanService.CreateBn(bennhan))
                {
                    return RedirectToAction("login");
                } else
                {
                    TempData["msg"] = "Awwwww... Failed";
                return RedirectToAction("register");
                }
            }
        }

        [Route("login")]
        [Route("~/")]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [Route("login")]
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            if (userService.Login(username, password))
            {
               var user = userService.findByUsername(username);
                if (user.Role)
                {
                    HttpContext.Session.SetString("role", "true");
                    return RedirectToAction("khoa", "home", new { area = "admin"});
                } else
                {
                    var bn = bennhanService.getByUsername(username);
                    HttpContext.Session.SetString("tenbn", bn.Tenbn);
                    HttpContext.Session.SetString("role", "false");
                    HttpContext.Session.SetString("mabn", bn.Mabn.ToString());
                    return RedirectToAction("index", "user" , new { area = "user"});
                }
            }
            else
            {
                TempData["msg"] = "Failed";
                return RedirectToAction("login");
            }
        }
        [Route("logout")]
        [HttpGet]

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("tenbn");
            HttpContext.Session.Remove("role");
            HttpContext.Session.Remove("mabn");
            return RedirectToAction("login");
        }
    }
}
