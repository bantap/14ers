using Microsoft.AspNetCore.Mvc;
using ProjectStep8.Models;

namespace ProjectStep8.Controllers
{
   public class TrailController
      : Controller
   {
      //   F i e l d s   &   P r o p e r t i e s

      private ITrailRepository _repository;
      private IPeakRepository _peakRepository;

      //   C o n s t r u c t o r

      public TrailController(ITrailRepository repository, IPeakRepository peakRepository)
      {
         _repository = repository;
         _peakRepository = peakRepository;
      }

      //   M e t h o d s

      //   C r e a t e

      [HttpGet]
      public IActionResult Add(int peakId)
      {
         Peak p = _peakRepository.GetPeakById(peakId);
         Trail t = new Trail();
         t.Peak = p;
         t.PeakId = peakId;
         return View(t);
      }

      [HttpPost]
      public IActionResult Add(Trail t)
      {
         if (ModelState.IsValid)
         {
            _repository.CreateTrail(t);
            return RedirectToAction("Detail", new { trailId = t.Id });
         }
         return View(t);
      }

      //   R e a d

      public IActionResult Index()
      {
         return View();
      }

      public IActionResult Detail(int trailId)
      {
         Trail trail = _repository.GetTrailById(trailId);
         return View(trail);
      }

      //   U p d a t e

      [HttpGet]
      public IActionResult Edit(int trailId)
      {
         Trail t = _repository.GetTrailById(trailId);
         return View(t);
      }

      [HttpPost]
      public IActionResult Edit(Trail updatedTrail)
      {
         if (ModelState.IsValid)
         {
            _repository.UpdateTrail(updatedTrail);
            return RedirectToAction("Detail", new { trailId = updatedTrail.Id });
         }
         return View(updatedTrail);
      }

      //   D e l e t e

      [HttpGet]
      public IActionResult Delete(int trailId)
      {
         Trail t = _repository.GetTrailById(trailId);
         if (t == null)
         {
            return RedirectToAction("Index", "Peak");
         }
         return View(t);
      }

      [HttpPost]
      public IActionResult Delete(Trail t)
      {
         _repository.DeleteTrail(t.Id);
         return RedirectToAction("Detail", "Peak", new { peakId = t.PeakId });
      }
   }
}
