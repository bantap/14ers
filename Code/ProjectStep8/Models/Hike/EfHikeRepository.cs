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

      public Hike CreateHike(Hike hike)
      {
         hike.UserId = _userRepository.GetLoggedInUserId();
         _context.Hikes.Add(hike);
         _context.SaveChanges();
         return hike;
      }

      //   R e a d

      public IQueryable<Hike> GetAllHikes()
      {
         return _context.Hikes.Where(h => h.UserId == _userRepository.GetLoggedInUserId())
                              .Include(h => h.Trail)
                              .ThenInclude(t => t.Peak);
      }

      public Hike GetHikeById(int hikeId)
      {
         return _context.Hikes.Where(h => h.Id == hikeId && h.UserId == _userRepository.GetLoggedInUserId())
                              .Include(h => h.Trail)
                              .ThenInclude(t => t.Peak)
                              .FirstOrDefault();
      }

      //   U p d a t e

      public Hike UpdateHike(Hike hike)
      {
         if (hike == null)
         {
            return null;
         }

         Hike hikeToUpdate = getHikeById(hike.Id);
         if (hikeToUpdate != null)
         {
            hikeToUpdate.Date = hike.Date;
            hikeToUpdate.Notes = hike.Notes;
            hikeToUpdate.Share = hike.Share;
            hikeToUpdate.TrailCondition = hike.TrailCondition;
            hikeToUpdate.TrailId = hike.TrailId;
            hikeToUpdate.Weather = hike.Weather;
            _context.SaveChanges();
         }

         return hikeToUpdate;
      }

      //   D e l e t e

      public bool DeleteHike(int hikeId)
      {
         Hike hikeToDelete = getHikeById(hikeId);
         if (hikeToDelete != null)
         {
            _context.Hikes.Remove(hikeToDelete);
            _context.SaveChanges();
            return true;
         }

         return false;
      }

      //   P r i v a t e   M e t h o d s

      private Hike getHikeById(int hikeId)
      {
         return _context.Hikes.FirstOrDefault(h => h.Id == hikeId && h.UserId == _userRepository.GetLoggedInUserId());
      }
   }
}
