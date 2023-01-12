using System.ComponentModel.DataAnnotations;
namespace BookProgram.Model
{
    public class Orders
    {
        public int ID { get; set; }
        [Required]
        [Display(Name ="Order Value")]
        [StringLength(4, MinimumLength =1, ErrorMessage ="Must Be A Number over 0 And Max 1000")]
        public string OrderName { get; set; }

        //Foreign Key
        [Display(Name ="Class Name")]
        public int HoldID { get; set; }

        [Display(Name ="Book Title")]
        public int BookListID { get; set; }

        //Navigation Properties
        public  Hold Hold { get; set; }

        public BookList BookList { get; set; }


    }
}
