using BasketballClubApi.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BCApiTest.ValidationTests
{
    public class BirthYearValidationTest
    {
        private BirthYearValidation yearOfBirthValidation;
        public BirthYearValidationTest()
        {
            yearOfBirthValidation = new BirthYearValidation();
        }

        [Fact]
        public void NullDateShouldThrowNullReferenceException()
        {
            Assert.Throws<NullReferenceException>(() => yearOfBirthValidation.IsValid(null));
        }

        [Fact]
        public void DateWithYearLessThenTwoThousendAndThreeShouldBeTrue()
        {
            DateTime date = new DateTime(2002, 12, 5);
            var result = yearOfBirthValidation.IsValid(date);
            Assert.True(result);
        }
        [Fact]
        public void DateWithYearGraterThenTwoThousendAndTwoShouldBeFalse()
        {
            DateTime date = new DateTime(1967, 12, 5);
            var result = yearOfBirthValidation.IsValid(date);
            Assert.False(result);
        }

    }
}
