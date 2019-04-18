using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static apiBooksStore.CustomValidators.BookCustomValidations;

namespace apiBooksStore.Models
{
    [Table("Book", Schema = "BooksInventory")]
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookId { get; set; }

        public string Title { get; set; }

        [checkBookQuantity]
        public int Quantity { get; set; }

        public double Price { get; set; }

        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }

    }
}
