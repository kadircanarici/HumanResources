using HumanResources.Models.Concrete;
using HumanResources.Repository.Shared.Abstract;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HumanResources.Web.Controllers
{
    public class UserController : Controller
    {
        public readonly IUnitOfWork unitOfWork;

        public UserController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        // GET: UserController
        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }

        [HttpPost]
        public async Task<IActionResult> Login(AppUser appUser)
        {
            AppUser user = unitOfWork.AppUser.GetFirstOrDefault(u => u.UserName == appUser.UserName && u.Password == appUser.Password);
            if(user!=null)
            {
                List<Claim> userClaims = new List<Claim>();
                userClaims.Add(new Claim(ClaimTypes.Name, user.UserName));
                userClaims.Add(new Claim(ClaimTypes.GivenName, user.Name));
                userClaims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
                userClaims.Add(new Claim(ClaimTypes.Role, user.AppUserRole.Name));

                var claimsIdentity = new ClaimsIdentity(userClaims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                return Json(user);

            }
            return View(appUser);
        }


        [Authorize(Roles = "Admin")]
        public IActionResult GetAll()
        {
            return Json(new { data = unitOfWork.AppUser.GetAll().ToList<AppUser>() });
        }


        [Authorize(Roles = "Admin")]
        public IActionResult Delete(AppUser appUser)
        {
            AppUser foundUser = unitOfWork.AppUser.GetFirstOrDefault(f => f.Id == appUser.Id);
            foundUser.IsDeleted = true;
            unitOfWork.AppUser.Remove(foundUser);
            unitOfWork.Save();
            return Json(foundUser);
        }


        [Authorize(Roles = "Admin")]
        public IActionResult FindById(AppUser appUser)
        {
            return Json(unitOfWork.AppUser.GetFirstOrDefault(u => u.Id == appUser.Id));
        }
    }
}
