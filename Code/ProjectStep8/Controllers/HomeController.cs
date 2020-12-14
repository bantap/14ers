using Microsoft.AspNetCore.Mvc;
using ProjectStep8.Models;
using System.Diagnostics;

namespace ProjectStep8.Controllers
{
   public class HomeController
      : Controller
   {
      //   F i e l d s   &   P r o p e r t i e s

      private IPeakRepository _repository;

      //   C o n s t r u c t o r s

      public HomeController(IPeakRepository repository, IUserRepository userRepository)
      {
         _repository = repository;
         // userRepository.Login(new Models.User { Email = "PBanta101@GMail.Com", Password = "Wombat1" });
      }

      //   M e t h o d s

      //   C r e a t e

      //   R e a d

      public IActionResult Index()
      {
         return View(_repository.GetAllPeaks());
      } // end Index( )

      //   U p d a t e

      //   D e l e t e

      //   M i s c

      public IActionResult Privacy()
      {
         return View();
      }

      [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
      public IActionResult Error()
      {
         return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
      }
   }
}
