using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static apiBooksStore.CustomValidators.BookSaleCustomValidations;

namespace apiBooksStore.DTO
{
    public class BookSaleDTO
    {
        public int Id { get; set; }

        [checkBookSaleQuantity]
        public int Quantity { get; set; }

        [DataType(DataType.Date)]
        public DateTime SaleDate { get; set; }

        public string Buyer { get; set; }

        public int BookId { get; set; }
    }
}
