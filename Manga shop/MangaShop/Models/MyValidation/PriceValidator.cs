using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MangaShop.Models.MyValidation
{
    public class PriceValidator : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var manga = (Manga)validationContext.ObjectInstance;
            double price = manga.Price;
            bool cond = true;

            
            if (price < 10 || price > 1000)
            {
                cond = false;           
            }
            

            return cond ? ValidationResult.Success : new ValidationResult("This is not a valid price!");
        }
    }
}