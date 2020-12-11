using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ProjectStep8.Models
{
   public class EfHikeRepository
      : IHikeRepository
   {
      //   F i e l d s   &   P r o p e r t i e s

      private AppDbContext _context;
      private IUserRepository _userRepository;

      //   C o n s t r u c t o r s

      public EfHikeRepository(AppDbContext context, IUserRepository userRepository)
      {
         _context = context;
         _userRepository = userRepository;
      }

      //   M e t h o d s

      //   C r e a t e

      public Hike CreateHike(Hike h)
      {
         throw new System.NotImplementedException();
      }

      //   R e a d

      public IQueryable<Hike> GetAllHikes()
      {
         return _context.Hikes.Where(c => c.UserId == _userRepository.GetLoggedInUserId());
      }

      public Hike GetHikeById(int hikeId)
      {
         Hike h = _context.Hikes.Include(c => c.Trail).FirstOrDefault(c => c.Id == hikeId);
         return h;
      }

      //   U p d a t e

      public Hike UpdateHike(Hike h)
      {
         if (h != null)
         {
            Hike hikeToUpdate = _context.Hikes.Find(h.Id);
            if (hikeToUpdate != null)
            {
               hikeToUpdate.Date = h.Date;
               hikeToUpdate.Notes = h.Notes;
               hikeToUpdate.TrailId = h.TrailId;
               hikeToUpdate.UserId = h.UserId;
               _context.SaveChanges();
               return hikeToUpdate;
            }
         }

         return null;
      }

      //   D e l e t e

      public bool DeleteHike(int hikeId)
      {
         Hike hikeToDelete = GetHikeById(hikeId);
         if (hikeToDelete != null)
         {
            _context.Hikes.Remove(hikeToDelete);
            _context.SaveChanges();
            return true;
         }

         return false;
      }

   }
}
