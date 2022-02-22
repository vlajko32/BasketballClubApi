using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BasketballClubApi.Validation
{
    /// <summary>
    /// Klasa koja nam sluzi za validaciju visine
    /// </summary>
    public class HeightValidation: ValidationAttribute
    {
        ///<inheritdoc/>
        public override bool IsValid(object? value)
        {

            if (value is Int32 temp)
            {
                if (temp > 90 && temp < 235)
                {
                    return true;
                }

            }
            return false;
        }
    }
}
