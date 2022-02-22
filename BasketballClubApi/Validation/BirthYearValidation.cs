using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BasketballClubApi.Validation
{
    /// <summary>
    /// Klasa koja nam sluzi za validaciju godine rodjenja
    /// </summary>
    public class BirthYearValidation: ValidationAttribute
    {

        ///<inheritdoc/>
        ///<exception cref="System.NullReferenceException" />
        public override bool IsValid(object value)
        {
            if (value == null)
            {
                throw new NullReferenceException();
            }
            if (value is DateTime date)
            {
                if (date.Year >= 1980)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
