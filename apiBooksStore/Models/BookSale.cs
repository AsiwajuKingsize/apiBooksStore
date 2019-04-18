using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace apiBooksStore.Models
{
    [Table("BookSale", Schema = "BooksInventory")]
    public class BookSale
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        
        public int Quantity { get; set; }

        [DataType(DataType.Date)]
        public DateTime SaleDate { get; set; }

        public string Buyer { get; set; }

        public int BookId { get; set; }
        

        
    }
}
