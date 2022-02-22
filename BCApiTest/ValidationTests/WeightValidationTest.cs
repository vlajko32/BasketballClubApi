using BasketballClubApi.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BCApiTest.ValidationTests
{
    public class WeightValidationTest
    {
        WeightValidation weightValidation;

        public WeightValidationTest()
        {
            weightValidation = new WeightValidation();
        }

        [Fact]
        public void NonIntTypeShouldBeFalse()
        {
            Assert.False(weightValidation.IsValid(2.12));
        }

        [Theory]
        [InlineData(90)]
        [InlineData(80)]
        [InlineData(67)]
        public void ValidEspbShouldBeTrue(int height)
        {
            Assert.True(weightValidation.IsValid(height));
        }

        [Theory]
        [InlineData(11)]
        [InlineData(311)]
        public void ValidEspbShouldBeFalse(int height)
        {
            Assert.False(weightValidation.IsValid(height));
        }
    }
}