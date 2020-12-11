using Microsoft.AspNetCore.Mvc;
using ProjectStep8.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectStep8.Controllers
{
   public class HikeController
      : Controller
   {
      //   F i e l d s   &   P r o p e r t i e s

      IHikeRepository _repository;

      //   C o n s t r u c t o r s

      public HikeController(IHikeRepository repository)
      {
         _repository = repository;
      }

      //   M e t h o d s

      public IActionResult Index()
      {
         IQueryable<Hike> hikes = _repository.GetAllHikes().OrderBy(hike => hike.Date);
         return View(hikes);
      }
   }
}
