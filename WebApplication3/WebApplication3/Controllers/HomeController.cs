using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private ISession _session => _httpContextAccessor.HttpContext.Session;
        private readonly WebDbContext _context;

        public HomeController(WebDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;

            _context = context;
        }

        public IActionResult Index()
        {
            
            return View();
        }
       

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserName,Password")] User user)
        {
            if (ModelState.IsValid)
            {
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction("Login");
            }
            return View(user);
        }
        

        public IActionResult About()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Login(IFormCollection log)
        {
            string user = log["UserName"].ToString();
            string pass = log["Password"].ToString();

            var islogin = _context.Users.SingleOrDefault(x => x.UserName.Equals(user) && x.Password.Equals(pass));
            if (islogin != null)
            {
                if (user == "Admin")
                {
                    _session.SetString("Ten", user);
                    TempData["result"] = "success";

                    return RedirectToAction("Index", "Users");
                }
                else
                {
                    _session.SetString("Ten", user);
                    TempData["result"] = "success";
                    return RedirectToAction("IndexLog", "Home");
                }
            }
            else
                return View();
        }
        public IActionResult IndexLog()
        {
            
            
            if (TempData["result"] != null)
                ViewBag.Mess = "Đăng nhập  thành công";
            ViewBag.session = _session.GetString("Ten");
            return View();
        }
        public IActionResult Logout()
        {
            _session.Clear();
            return RedirectToAction("Login");
        }
    }
}
