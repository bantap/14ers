using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectStep8.Models
{
   [Table("Trail")]
   public class Trail
   {
      //   F i e l d s   &   P r o p e r t i e s

      public int    Id                { get; set; }

      [Required(ErrorMessage = "Trail Name Is Required")]
      public string Name              { get; set; }

      [Required(ErrorMessage = "Strating Elevation Is Required")]
      public int    StartingElevation { get; set; }

      [Required(ErrorMessage = "Distance Is Required")]
      public float  Distance          { get; set; }

      [ForeignKey("Peak")]
      public int  PeakId { get; set; }
      public Peak Peak   { get; set; }

      //   C o n s t r u c t o r s

      //   M e t h o d s
   }
}
