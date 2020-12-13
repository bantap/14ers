using Microsoft.AspNetCore.Mvc;
using ProjectStep8.Models;
using System.Linq;

namespace ProjectStep8.Controllers
{
   public class HikeController
      : Controller
   {
      //   F i e l d s   &   P r o p e r t i e s

      IHikeRepository _repository;
      IUserRepository _userRepository;

      //   C o n s t r u c t o r s

      public HikeController(IHikeRepository repository, IUserRepository userRepository)
      {
         _repository     = repository;
         _userRepository = userRepository;
      }

      //   M e t h o d s

      //   C r e a t e

      [HttpGet]
      public IActionResult Add(int trailId)
      {
         if (!_userRepository.IsUserLoggedIn())
         {
            return RedirectToAction("Index", "Peak");
         }

         return View(new Hike { TrailId = trailId });
      }

      [HttpPost]
      public IActionResult Add(Hike h)
      {
         if (!_userRepository.IsUserLoggedIn())
         {
            return RedirectToAction("Index", "Peak");
         }

         if (ModelState.IsValid)
         {
            _repository.CreateHike(h);
            return RedirectToAction("Index");
         }

         return View(h);
      }

      //   R e a d

      public IActionResult Index()
      {
         if (!_userRepository.IsUserLoggedIn())
         {
            return RedirectToAction("Index", "Peak");
         }

         return View(_repository.GetAllHikes().OrderBy(hike => hike.Date));
      }

      public IActionResult Detail(int hikeId)
      {
         if (!_userRepository.IsUserLoggedIn())
         {
            return RedirectToAction("Index", "Peak");
         }

         Hike h = _repository.GetHikeById(hikeId);
         if (h == null)
         {
            return RedirectToAction("Index", "Peak");
         }

         return View(h);
      }

      //   U p d a t e

      [HttpGet]
      public IActionResult Edit(int hikeId)
      {
         if (!_userRepository.IsUserLoggedIn())
         {
            return RedirectToAction("Index", "Peak");
         }

         Hike h = _repository.GetHikeById(hikeId);
         if (h == null)
         {
            return RedirectToAction("Index", "Peak");
         }

         return View(h);
      }

      [HttpPost]
      public IActionResult Edit(Hike h)
      {
         if (h == null || !_userRepository.IsUserLoggedIn())
         {
            return RedirectToAction("Index", "Peak");
         }

         if (ModelState.IsValid)
         {
            _repository.UpdateHike(h);
            return RedirectToAction("Index");
         }

         return View(h);
      }

      //   D e l e t e

      [HttpGet]
      public IActionResult Delete(int hikeId)
      {
         if (!_userRepository.IsUserLoggedIn())
         {
            return RedirectToAction("Index", "Peak");
         }

         Hike h = _repository.GetHikeById(hikeId);
         if (h == null)
         {
            return RedirectToAction("Index", "Peak");
         }

         return View(h);
      }

      [HttpPost]
      public IActionResult Delete(Hike h)
      {
         if (!_userRepository.IsUserLoggedIn())
         {
            return RedirectToAction("Index", "Peak");
         }

         if (h != null)
         {
            _repository.DeleteHike(h.Id);
         }

         return RedirectToAction("Index");
      }
   }
}
