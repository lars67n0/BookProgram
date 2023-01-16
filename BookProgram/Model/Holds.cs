using System.ComponentModel.DataAnnotations;
namespace BookProgram.Model
{
    public class Holds
    {
        public int ID { get; set; }

        [Required(ErrorMessage ="Please enter Class Name")]
        [Display(Name ="Class Name")]
        [StringLength(25, MinimumLength = 5, ErrorMessage = "Class Name Must Be Min 5 And Max 25 Characters")]
        public string ClassName { get; set; }



        

        // Foreign Key
        [Display(Name = "Teacher Name")]
        public int TeacherID { get; set; }

        [Display(Name = "Education Name")]
        public int EducationID { get; set; }

        //Navigation Properties
        public Teacher Teacher { get; set; }
        public Education Education { get; set; }

    }
}
