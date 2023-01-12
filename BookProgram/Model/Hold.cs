using System.ComponentModel.DataAnnotations;
namespace BookProgram.Model
{
    public class Hold
    {
        public int ID { get; set; }

        [Required(ErrorMessage ="Please enter Class Name")]
        [Display(Name ="Class Name")]
        [StringLength(25, MinimumLength = 5, ErrorMessage = "Class Name Must Be Min 5 And Max 25 Characters")]
        public string ClassName { get; set; }



        [Required(ErrorMessage = "Please enter Teacher Name")]
        [Display(Name = "Teacher Name")]
        [StringLength(50, MinimumLength =5, ErrorMessage ="Teacher Name Must Be Min 5 And Max 50 Characters")]
        public string TeacherName { get; set; }

        

    }
}
