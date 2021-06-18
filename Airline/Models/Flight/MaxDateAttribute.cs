using System;
using System.ComponentModel.DataAnnotations;

namespace Airline.Models
{
    internal class MaxDateAttribute : ValidationAttribute
    {
        public MaxDateAttribute()
        {
        }

        public override bool IsValid(object value)
        {
            var dt = (DateTime)value;
            if (dt <= dt.AddDays(1))
            {
                return true;
            }
            return false;
        }
    }
}