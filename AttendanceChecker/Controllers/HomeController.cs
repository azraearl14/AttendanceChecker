using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AttendanceChecker.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public IActionResult AdminOnly()
        {
            return View();
        }

        //private readonly SignInManager<IdentityUser> _signInManager;

        //public HomeController(SignInManager<IdentityUser> signInManager)
        //{
        //    _signInManager = signInManager;
        //}

        //public IActionResult Index()
        //{
        //    return View();
        //}

        //[HttpGet]
        //[AllowAnonymous]
        //public IActionResult Login()
        //{
        //    return View();
        //}

        //[HttpPost]
        //[AllowAnonymous]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Login(UserModel model, string returnUrl = null)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, model.IsAdmin, lockoutOnFailure: false);

        //        if (result.Succeeded)
        //        {
        //            return RedirectToAction("AdminDashboard");
        //        }
        //        else
        //        {
        //            ModelState.AddModelError("", "Invalid login attempt.");
        //        }
        //    }
        //    if (!ModelState.IsValid)
        //    {
        //        foreach (var modelState in ViewData.ModelState.Values)
        //        {
        //            foreach (var error in modelState.Errors)
        //            {
        //                ModelState.AddModelError("", "Invalid login attempt.");
        //            }
        //        }

        //        return View(model);
        //    }

        //    return View(model);
        //}

        //[HttpGet]
        //[Authorize(Roles = "Admin")]
        //public IActionResult Dashboard()
        //{
        //    return View();
        //}

        //[HttpPost]
        //[Authorize]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Logout()
        //{
        //    await _signInManager.SignOutAsync();
        //    return RedirectToAction(nameof(Login));
        //}
        //private UserDBContext db = new UserDBContext();

        //public ActionResult Index()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult Index(string username, string password)
        //{
        //    var user = db.Users.FirstOrDefault(u => u.Username == username && u.Password == password);

        //    if (user != null)
        //    {
        //        if (user.IsAdmin)
        //        {
        //            return RedirectToAction("AdminDashboard");
        //        }
        //        else
        //        {
        //            return RedirectToAction("UserDashboard");
        //        }
        //    }
        //    else
        //    {
        //        ViewBag.ErrorMessage = "Invalid username or password.";
        //        return View();
        //    }
        //}

        //[Authorize(Roles = "Admin")]
        //public ActionResult AdminDashboard()
        //{
        //    return View("AdminDashboard");
        //}

        //[Authorize(Roles = "User")]
        //public ActionResult UserDashboard()
        //{
        //    return View();
        //}
    }
}