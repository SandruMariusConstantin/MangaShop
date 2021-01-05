using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MangaShop.Models.MyValidation
{
    public class VolumeValidator : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var manga = (Manga)validationContext.ObjectInstance;
            double volume = manga.VolumeNumber;
            bool cond = true;


            if (volume < 1 || volume > 50)
            {
                cond = false;
            }


            return cond ? ValidationResult.Success : new ValidationResult("This is not a valid price!");
        }
    }
}