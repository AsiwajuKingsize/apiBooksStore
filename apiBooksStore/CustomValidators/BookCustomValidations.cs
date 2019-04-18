using apiBooksStore.DTO;
using apiBooksStore.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace apiBooksStore.CustomValidators
{
    public class BookCustomValidations
    {
        public class checkBookQuantity : ValidationAttribute
        {

            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                var bookDTO = (BookDTO)validationContext.ObjectInstance;
                var quantity = (int)value;

                if (bookDTO.Quantity < 1)
                {
                    return new ValidationResult("Book quantity must be greater than zero");
                }

                return ValidationResult.Success;


            }
        }
    }
}
