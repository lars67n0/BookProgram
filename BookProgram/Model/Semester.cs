using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace BookProgram.Model
{
    public class Semester
    {

        public int ID { get; set; }

        public string SemesterName { get; set; }

        
        [Required(ErrorMessage = "Please Enter Start Date")]
        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }


        // Foreign Key
        [Display(Name = "Teacher Name ")]
        public int TeacherID { get; set; }

        [Display(Name = "Education Name ")]
        public int EducationID { get; set; }


        //Navigation Properties
        public Teacher Teacher { get; set; }

        public Education EducationName { get; set; }
    }
}
