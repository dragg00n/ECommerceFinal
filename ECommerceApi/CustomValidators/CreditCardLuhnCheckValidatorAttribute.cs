using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceApi.CustomValidators
{
    public class CreditCardLuhnCheckAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var luhnCheck = new LuhnCheck();
            if(luhnCheck.PassesLuhnCheck(value.ToString()))
            {
                return ValidationResult.Success;
            } else
            {
                return new ValidationResult("Bad Credit Card Number - Does Not Pass Luhn Check");
            }
        }
    }
}
