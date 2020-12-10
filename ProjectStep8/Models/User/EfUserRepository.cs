﻿using Microsoft.AspNetCore.Http;
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
      private ISession     _session;

      //   C o n s t r u c t o r s

      public EfUserRepository(AppDbContext context, IHttpContextAccessor foo)
      {
         _context = context;
         _session = foo.HttpContext.Session;
      }

      // public EfUserRepository(AppDbContext context, HttpContext foo)
      // {
      //    _context = context;
      //    _session = foo.Session;
      // }

      //   M e t h o d s

      //   C r e a t e

      public User AddUser(User u)
      {
         try
         {
            u.Password = encrypt(u.Password);
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

      public bool Login(User u) // email    password
      {
         User dbUser = GetUserByEmail(u.Email);

         if (dbUser == null)
         {
            return false;
         }

         u.Password = encrypt(u.Password);

         if (dbUser.Password == u.Password)
         {
            _session.SetInt32("userId", dbUser.Id);
            _session.SetString("userEmail", dbUser.Email);
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

      // VIM Rocks ! ! ! ! !

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
            return userId.Value; // Value is an int
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


      private string encrypt(string password)
      {
         SHA256 myHashingVar = SHA256.Create();
         byte[] passwordByteArray = Encoding.ASCII.GetBytes(password);
         passwordByteArray[0] += 1;
         passwordByteArray[1] += 2;
         passwordByteArray[2] += 3;
         passwordByteArray[3] += 4;
         byte[] hashedPasswordByteArray = myHashingVar.ComputeHash(passwordByteArray);
         string hashedPassword = "";
         foreach (byte b in hashedPasswordByteArray)
         {
            hashedPassword += b.ToString("x2");
         }
         return hashedPassword;
      }
   }
}