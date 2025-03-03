using System;
using System.ComponentModel.DataAnnotations;

namespace TenantManagement.Models
{

    public class MinimumAgeAttribute : ValidationAttribute
    {
        int _minAge;

        public MinimumAgeAttribute(int minAge)
        {
            _minAge = minAge;
        }

        public override bool IsValid(object value)
        {
            DateTime date;
            if (DateTime.TryParse(value.ToString(), out date))
            {
                    return date.AddYears(_minAge) < DateTime.Now;
            }
            return false;
        }
    }
}
