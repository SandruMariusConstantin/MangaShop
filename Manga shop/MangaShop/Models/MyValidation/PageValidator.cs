using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MangaShop.Models.MyValidation
{
    public class PageValidator : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var manga = (Manga)validationContext.ObjectInstance;
            double page = manga.NoOfPages;
            bool cond = true;


            if (page < 50 || page > 300)
            {
                cond = false;
            }


            return cond ? ValidationResult.Success : new ValidationResult("This is not a valid price!");
        }
    }
}