using System.Linq;

namespace ProjectStep8.Models
{
   public interface IUserRepository
   {
      //   C r e a t e

      public User AddUser(User u);

      //   R e a d

      public IQueryable<User> GetAllUsers();
      public string GetLoggedInUserEmail();
      public int GetLoggedInUserId();
      public User GetUserByEmail(string userEmail);
      public User GetUserById(int userId);
      public bool IsUserAdmin();
      public bool IsUserLoggedIn();
      public bool Login(User u);
      public void Logout();


      //   U p d a t e

      public User UpdateUser(User u);

      //   D e l e t e

      public bool DeleteUser(int userId);
      public bool DeleteUser(string userEmail);
   }
}
