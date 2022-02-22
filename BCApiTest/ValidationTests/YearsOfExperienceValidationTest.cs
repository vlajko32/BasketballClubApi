using BasketballClubApi.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BCApiTest.ValidationTests
{
    public class YearsOfExperienceValidationTest
    {
        YearsOfExperienceValidation yearsOfExperienceValidation;

        public YearsOfExperienceValidationTest()
        {
            yearsOfExperienceValidation = new YearsOfExperienceValidation();
        }

        [Fact]
        public void NonIntTypeShouldBeFalse()
        {
            Assert.False(yearsOfExperienceValidation.IsValid(2.12));
        }

        [Theory]
        [InlineData(8)]
        [InlineData(2)]
        [InlineData(4)]
        public void ValidEspbShouldBeTrue(int espb)
        {
            Assert.True(yearsOfExperienceValidation.IsValid(espb));
        }

        [Theory]
        [InlineData(-5)]
        [InlineData(100)]
        public void ValidEspbShouldBeFalse(int espb)
        {
            Assert.False(yearsOfExperienceValidation.IsValid(espb));
        }
    }
}
