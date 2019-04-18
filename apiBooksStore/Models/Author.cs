using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace apiBooksStore.Models
{
    [Table("Author",Schema = "BooksInventory")]
    public class Author
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string Phone { get; set; }

        [Url]
        public string Website { get; set; }

        public virtual ICollection<Book> Books { get; set; }


    }
}
