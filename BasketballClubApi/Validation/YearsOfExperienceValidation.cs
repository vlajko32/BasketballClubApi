using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BasketballClubApi.Validation
{
    /// <summary>
    /// Klasa koja sluzi za validaciju godina iskustva trenera
    /// </summary>
    public class YearsOfExperienceValidation: ValidationAttribute
    {
        ///<inheritdoc/>
        public override bool IsValid(object? value)
        {
           
            if(value is Int32 temp)
            {
                if(temp> 0 && temp < 50)
                {
                    return true;
                }
                
            }
            return false;
        }
    }
}
