using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectStep8.Models
{
   [Table("Hike")]
   public class Hike
   {
      public int       Id             { get; set; }

      [Required(ErrorMessage = "User Is Required")]
      public int       UserId         { get; set; }

      [Required(ErrorMessage = "Trail Is Required")]
      public int       TrailId        { get; set; }
      public Trail     Trail          { get; set; }

      [Column(TypeName = "date")]
      [DataType(DataType.Date)]
      [Required(ErrorMessage = "Date Is Required")]
      [UIHint("date")]
      public DateTime? Date           { get; set; }

      public string    TrailCondition { get; set; }

      public string    Weather        { get; set; }

      public string    Notes          { get; set; }

      public bool      Share          { get; set; } = false;
   }
}
