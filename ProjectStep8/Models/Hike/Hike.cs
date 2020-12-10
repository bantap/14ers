using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectStep8.Models
{
   [Table("Hike")]
   public class Hike
   {
      public int      Id      { get; set; }
      public int      UserId  { get; set; }
      public int      TrailId { get; set; }
      public Trail    Trail   { get; set; }
      public DateTime Date    { get; set; }
      public string   Notes   { get; set; }
   }
}
