using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ProjectStep8.Models
{
   public class EfPeakRepository
      : IPeakRepository
   {
      //   F i e l d s   &   P r o p e r t i e s

      private AppDbContext _context;

      //   C o n s t r u c t o r s

      public EfPeakRepository(AppDbContext context)
      {
         _context = context;
      }

      //   M e t h o d s

      //   C r e a t e

      public Peak AddPeak(Peak p)
      {
         if (p == null)
         {
            return null;
         }

         _context.Peaks.Add(p);
         _context.SaveChanges();
         return p;
      }

      //   R e a d

      public IQueryable<Peak> GetAllPeaks()
      {
         return _context.Peaks;
      }

      public Peak GetPeakById(int id)
      {
         // return _context.Peaks.FirstOrDefault(p => p.Id == id);
         // return _context.Peaks.Find(id);
         return _context.Peaks.Include(p => p.Trails).FirstOrDefault(p => p.Id == id);
      }

      //   U p d a t e

      public Peak UpdatePeak(Peak p)
      {
         if (p == null)
         {
            return null;
         }

         Peak peakToUpdate = _context.Peaks.Find(p.Id);
         if (peakToUpdate != null)
         {
            peakToUpdate.County = p.County;
            peakToUpdate.Elevation = p.Elevation;
            peakToUpdate.Name = p.Name;
            peakToUpdate.NearestTown = p.NearestTown;
            _context.SaveChanges();
         }
         return peakToUpdate;
      }

      //   D e l e t e

      public bool DeletePeak(int id)
      {
         Peak p = _context.Peaks.Find(id);
         if (p == null)
         {
            return false;
         }
         _context.Remove(p);
         _context.SaveChanges();
         return true;
      }
   }
}
