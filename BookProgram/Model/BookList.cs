using System.ComponentModel.DataAnnotations;

namespace BookProgram.Model
{
    public class BookList
    {
        public int ID { get; set; }

        [Required(ErrorMessage ="Please Enter Title Name")]
        [StringLength(60, MinimumLength =3,ErrorMessage="Title Name Max 60 Characters and Min 3.")]
        
        public string Title { get; set; }

        [Required(ErrorMessage = "Please Enter Author Name")]
        [StringLength(50, MinimumLength =3, ErrorMessage ="Name Must Be Between 3 And 60 Characters!")]
        [Display(Name = "Author Name")]
        public string Author { get; set; }

        [Required(ErrorMessage = "Please Enter Release Date")]
        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        
        


    }
}
