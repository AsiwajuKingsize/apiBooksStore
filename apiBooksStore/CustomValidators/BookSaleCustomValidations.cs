using apiBooksStore.DTO;
using apiBooksStore.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace apiBooksStore.CustomValidators
{
    public class BookSaleCustomValidations
    {
        public  class checkBookSaleQuantity : ValidationAttribute
        {
           
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                var bookSaleDTO = (BookSaleDTO)validationContext.ObjectInstance;
                var quantity = (int)value;

                if (bookSaleDTO.Quantity < 1)
                {
                    return new ValidationResult("Book Sale quantity must be greater than zero");
                }

                return ValidationResult.Success;
               
            }
        }

      
    }
}
