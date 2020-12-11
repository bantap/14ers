using System.Linq;

namespace ProjectStep8.Models
{
   public interface ITrailRepository
   {
      //   C r e a t e

      public Trail CreateTrail(Trail t);

      //   R e a d

      public IQueryable<Trail> GetAllTrails();

      public Trail GetTrailById(int trailId);

      //   U p d a t e

      public Trail UpdateTrail(Trail t);

      //   D e l e t e

      public bool DeleteTrail(int trailId);
   }
}
