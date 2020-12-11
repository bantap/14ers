using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectStep8.Models
{
   [Table("Goal")]
   public class Goal
   {
      public int      Id         { get; set; }

      [Required(ErrorMessage = "User Is Required")]
      public int      UserId     { get; set; }

      [Required(ErrorMessage = "Trail Is Required")]
      public int      TrailId    { get; set; }
      public Trail    Trail      { get; set; }

      [Required(ErrorMessage = "Goal Date Is Required")]
      public DateTime GoalDate   { get; set; }

      public int?     HikeId     { get; set; }
   }
}
