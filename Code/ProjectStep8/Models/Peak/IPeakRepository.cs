using System.Linq;

namespace ProjectStep8.Models
{
   public interface IPeakRepository
   {
      //   C r e a t e

      public Peak AddPeak(Peak p);

      //   R e a d

      public IQueryable<Peak> GetAllPeaks();

      public Peak GetPeakById(int id);

      //   U p d a t e

      public Peak UpdatePeak(Peak p);

      //   D e l e t e

      public bool DeletePeak(int id);
   }
}
