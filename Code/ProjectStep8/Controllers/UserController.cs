using Microsoft.AspNetCore.Mvc;
using ProjectStep8.Models;

namespace ProjectStep8.Controllers
{
   public class UserController : Controller
   {
      //   F i e l d s   &   P r o p e r t i e s

      private IUserRepository _repository;

      //   C o n s t r u c t o r s

      public UserController(IUserRepository repository)
      {
         _repository = repository;
      }

      //   M e t h o d s

      //   C r e a t e

      [HttpGet]
      public IActionResult Register()
      {
         return View();
      }

      [HttpPost]
      public IActionResult Register(User u)
      {
         _repository.AddUser(u);
         if (u.Id < 1)
         {
            return View(u);
         }

         return RedirectToAction("Index", "Peak");
      }

      //   R e a d

      public IActionResult Index()
      {
         return View();
      }

      [HttpGet]
      public IActionResult Login()
      {
         return View();
      }

      [HttpPost]
      public IActionResult Login(User u)
      {
         bool validUser = _repository.Login(u);
         if (validUser == true)
         {
            return RedirectToAction("Index", "Peak");
         }
         return View(u);
      }

      public IActionResult Logout()
      {
         _repository.Logout();
         return RedirectToAction("Index", "Peak");
      }

      //   U p d a t e

      //   D e l e t e
   }
}
