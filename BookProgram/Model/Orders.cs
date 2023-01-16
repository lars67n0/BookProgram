using System.ComponentModel.DataAnnotations;
namespace BookProgram.Model
{
    public class Orders
    {
        public int ID { get; set; }
        [Required]
        [Display(Name ="Order Value")]
        [Range(1,1000, ErrorMessage ="Must Be A Number Between 1 And Max 1000")]
        public string OrderValue { get; set; }

        //Foreign Key
        [Display(Name ="Class Name")]
        public int EducationID { get; set; }

        [Display(Name ="Book Title")]
        public int BookListID { get; set; }

        //Navigation Properties
        public  Education Education { get; set; }

        public BookList BookList { get; set; }


    }
}
