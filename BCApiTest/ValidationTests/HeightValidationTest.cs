using BasketballClubApi.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BCApiTest.ValidationTests
{
    public class HeightValidationTest
    {
        HeightValidation heightValidation;

        public HeightValidationTest()
        {
            heightValidation = new HeightValidation();
        }

        [Fact]
        public void NonIntTypeShouldBeFalse()
        {
            Assert.False(heightValidation.IsValid(2.12));
        }

        [Theory]
        [InlineData(190)]
        [InlineData(120)]
        [InlineData(167)]
        public void ValidEspbShouldBeTrue(int height)
        {
            Assert.True(heightValidation.IsValid(height));
        }

        [Theory]
        [InlineData(11)]
        [InlineData(311)]
        public void ValidEspbShouldBeFalse(int height)
        {
            Assert.False(heightValidation.IsValid(height));
        }
    }
}
