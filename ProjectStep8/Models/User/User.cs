using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectStep8.Models
{
   [Table("User")]
   public class User
   {
      public int    Id       { get; set; }

      [EmailAddress]
      [MaxLength(128)]
      [MinLength(10)]
      [Required(ErrorMessage = "User Name / Email Address is required")]
      [UIHint("email")] // type="email"
      public string Email    { get; set; }

      [MaxLength(128)]
      [Required(ErrorMessage = "Password is required")]
      [UIHint("password")] // type="password"
      public string Password { get; set; }
      public bool   IsAdmin  { get; set; } = false;

      //[Column(TypeName = "date")]
      //[DataType(DataType.Date)]
      //[Required(ErrorMessage = "Birthdate is required")]
      //[UIHint("date")]
      //public DateTime? Birthdate { get; set; }

      //[Column(TypeName = "decimal(3, 1)")] // 99.9
      //[Range(0.0, 20.0, ErrorMessage = "Beer Out Of Range")]
      //[Required(ErrorMessage = "Beer Is Required")]
      //[UIHint("number")]
      //public float LitersOfBeerPerDay { get; set; }
   }
}
