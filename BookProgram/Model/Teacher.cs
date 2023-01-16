using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace BookProgram.Model
{
    public class Teacher
    {
        public int ID { get; set; }



        [Required(ErrorMessage = "Please enter Teacher Name")]
        [Display(Name = "Teacher Name")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Teacher Name Must Be Min 5 And Max 50 Characters")]
        public string TeacherName { get; set; }

        
    }
}
