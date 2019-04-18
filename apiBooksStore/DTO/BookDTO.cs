using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static apiBooksStore.CustomValidators.BookCustomValidations;

namespace apiBooksStore.DTO
{
    public class BookDTO
    {
        public int BookId { get; set; }

        public string Title { get; set; }

        [checkBookQuantity]
        public int Quantity { get; set; }

        public double Price { get; set; }

        public int AuthorId { get; set; }
    }
}
