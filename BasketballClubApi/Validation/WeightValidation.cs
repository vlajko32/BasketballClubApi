using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BasketballClubApi.Validation
{
    /// <summary>
    /// Klasa koja nam sluzi za validaciju tezine
    /// </summary>
    public class WeightValidation: ValidationAttribute
    {
        ///<inheritdoc/>
        public override bool IsValid(object? value)
        {

            if (value is Int32 temp)
            {
                if (temp > 30 && temp < 160)
                {
                    return true;
                }

            }
            return false;
        }
    }
}
