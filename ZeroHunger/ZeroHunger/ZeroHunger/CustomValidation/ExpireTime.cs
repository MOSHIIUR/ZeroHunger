using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZeroHunger.CustomValidation
{
    public class ExpireTime: ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime inputDateTime;

            // Check if the input value is a valid DateTime
            if (DateTime.TryParse(value.ToString(), out inputDateTime))
            {
                // Calculate the difference between the input DateTime and the current DateTime
                TimeSpan timeDiff = inputDateTime - DateTime.Now;

                // Check if the time difference is less than or equal to 3 hours
                return (timeDiff.TotalHours <= 3);
            }

            // If the input value is not a valid DateTime, return false
            return false;
        }
    }
}