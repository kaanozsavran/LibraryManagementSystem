using System.ComponentModel.DataAnnotations;

namespace libraryManagementSystem.Data{


    public class Book {

         [Key]
        public int BookID { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Author { get; set; }

        public int PublicationYear { get; set; }

        public string Category { get; set; }

    }
}