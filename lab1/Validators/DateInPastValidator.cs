using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace lab1.Validators;

public class DateInPastAttribute : ValidationAttribute
{
  
        public override bool IsValid(object? value)
        => value is DateTime date && date <= DateTime.Now;
    

}
