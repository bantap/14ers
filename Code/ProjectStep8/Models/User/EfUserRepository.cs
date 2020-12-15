using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace ProjectStep8.Models
{
   public class EfUserRepository
      : IUserRepository
   {
      //   F i e l d s   &   P r o p e r t i e s

      private AppDbContext _context;
      private SHA256       _passwordHasher;
      private ISession     _session;

      //   C o n s t r u c t o r s

      public EfUserRepository(AppDbContext context, IHttpContextAccessor foo)
      {
         _context = context;
         _session = foo.HttpContext.Session;
      }

      //   M e t h o d s

      //   C r e a t e

      public User AddUser(User u)
      {
         try
         {
            u.Password = encryptPassword(u.Email, u.Password);
            _context.Users.Add(u);
            _context.SaveChanges();
         }
         catch (Exception e)
         {
            u.Id = -1;
         }
         u.Password = "";
         return u;
      }

      //   R e a d

      public IQueryable<User> GetAllUsers()
      {
         return _context.Users;
      }

      public User GetUserByEmail(string userEmail)
      {
         User u = _context.Users.FirstOrDefault(u => u.Email == userEmail);
         return u;
      }

      public User GetUserById(int userId)
      {
         return _context.Users.Find(userId);
      }

      public bool Login(User u)
      {
         User dbUser = GetUserByEmail(u.Email);

         if (dbUser == null)
         {
            return false;
         }

         u.Password = encryptPassword(u.Email, u.Password);

         if (dbUser.Password == u.Password)
         {
            _session.SetInt32("userId", dbUser.Id);
            _session.SetString("userEmail", u.Email);
            if (dbUser.IsAdmin == true)
            {
               _session.SetInt32("userAdmin", 1);
            }
            else
            {
               _session.SetInt32("userAdmin", 0);
            }
            return true;
         }

         return false;
      }

      public bool IsUserLoggedIn()
      {
         int? userId = _session.GetInt32("userId");
         if (userId == null)
         {
            return false;
         }
         else
         {
            return true;
         }
      }

      public int GetLoggedInUserId()
      {
         int? userId = _session.GetInt32("userId");
         if (userId == null)
         {
            return -1;
         }
         else
         {
            return userId.Value;
         }
      }


      //   U p d a t e

      public User UpdateUser(User u)
      {
         throw new NotImplementedException();
      }

      //   D e l e t e

      public bool DeleteUser(int userId)
      {
         throw new NotImplementedException();
      }

      public bool DeleteUser(string userEmail)
      {
         throw new NotImplementedException();
      }

      public string GetLoggedInUserEmail()
      {
         return _session.GetString("userEmail");
      }

      public bool IsUserAdmin()
      {
         if (_session.GetInt32("userAdmin") == 1)
         {
            return true;
         }
         return false;
      }

      public void Logout()
      {
         _session.Remove("userEmail");
         _session.Remove("userId");
         _session.Remove("userAdmin");
      }

      //   P r i v a t e   M e t h o d s

      private string encryptPassword(string username, string password)
      {
         if (_passwordHasher == null)
         {
            _passwordHasher = SHA256.Create();
         }

         byte[] usernameByteArray = Encoding.ASCII.GetBytes(username.ToLower());
         byte[] passwordByteArray = Encoding.ASCII.GetBytes(password);
         for (int i = 0; i < passwordByteArray.Length; i++)
         {
            passwordByteArray[i] ^= usernameByteArray[i % usernameByteArray.Length];
         }
         byte[] hashedPasswordByteArray = _passwordHasher.ComputeHash(passwordByteArray);
         string hashedPassword = "";
         foreach (byte b in hashedPasswordByteArray)
         {
            hashedPassword += b.ToString("x2");
         }
         return hashedPassword;
      }
   }
}
