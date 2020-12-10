using System.Linq;

namespace ProjectStep8.Models
{
   public interface IHikeRepository
   {
      //   C r e a t e

      public Hike CreateHike(Hike h);

      //   R e a d

      public IQueryable<Hike> GetAllHikes();

      public Hike GetHikeById(int hikeId);

      //   U p d a t e

      public Hike UpdateHike(Hike h);

      //   D e l e t e

      public bool DeleteHike(int hikeId);
   }
}
