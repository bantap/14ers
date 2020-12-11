using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectStep8.Models
{
   [Table("Peak")]
   public class Peak
   {
      //   F i e l d s   &   P r o p e r t i e s

      public int Id { get; set; }

      [Required(ErrorMessage = "Peak Name Is Required")]
      public string Name { get; set; }

      [Required(ErrorMessage = "Peak Elevation Is Required")]
      public int Elevation { get; set; }

      public string NearestTown { get; set; }

      public string County { get; set; }


      public List<Trail> Trails { get; set; }

      //   C o n s t r u c t o r s

      //   M e t h o d s
   }
}
