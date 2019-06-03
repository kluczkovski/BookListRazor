using System;
using System.ComponentModel.DataAnnotations;

namespace BookListRazor.Model
{
    public class Book
    {
        [Key]
        public int Int { get; set; }

        [Required]
        [Display(Name="Book Name")]
        public string Name { get; set; }

        public string ISBN { get; set; }

        public string Author { get; set; }


        public Book()
        {
        }
    }
}
