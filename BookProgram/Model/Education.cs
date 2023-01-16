using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace BookProgram.Model
{
    public class Education
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "Education Name ")]
        [StringLength(60, MinimumLength = 5, ErrorMessage = "Must Be A Name Between 5 And Max 60 Characters")]

        public string EducationName { get; set; }




    }
}
