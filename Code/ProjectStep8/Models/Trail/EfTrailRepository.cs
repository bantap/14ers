using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace ProjectStep8.Models
{
   public class EfTrailRepository
      : ITrailRepository
   {
      //   F i e l d s   &   M e t h o d s

      private AppDbContext    _context;
      private IPeakRepository _peakRepository;

      //   C o n s t r u c t o r s

      public EfTrailRepository(AppDbContext context, IPeakRepository peakRepository)
      {
         _context = context;
         _peakRepository = peakRepository;
      }

      //   M e t h o d s

      //   C r e a t e

      public Trail CreateTrail(Trail t)
      {
         if (t == null)
         {
            return null;
         }

         Peak p = _peakRepository.GetPeakById(t.PeakId);
         if (p == null)
         {
            return null;
         }

         _context.Trails.Add(t);
         _context.SaveChanges();
         return t;
      }

      //   R e a d

      public IQueryable<Trail> GetAllTrails()
      {
         return _context.Trails.Include(t => t.Peak);
      }

      public Trail GetTrailById(int trailId)
      {
         return _context.Trails.Include(t => t.Peak).FirstOrDefault(t => t.Id == trailId);
      }

      //   U p d a t e

      public Trail UpdateTrail(Trail t)
      {
         if (t == null)
         {
            return null;
         }

         Trail trailToUpdate = _context.Trails.Find(t.Id);
         if (trailToUpdate != null)
         {
            trailToUpdate.Distance = t.Distance;
            trailToUpdate.Name = t.Name;
            if (t.PeakId > 0)
            {
               trailToUpdate.PeakId = t.PeakId;
            }
            trailToUpdate.StartingElevation = t.StartingElevation;
            _context.SaveChanges();
         }
         return trailToUpdate;
      }

      //   D e l e t e

      public bool DeleteTrail(int trailId)
      {
         Trail t = _context.Trails.Find(trailId);
         if (t == null)
         {
            return false;
         }
         _context.Trails.Remove(t);
         _context.SaveChanges();
         return true;
      }
   }
}
