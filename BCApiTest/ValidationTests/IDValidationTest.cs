using BasketballClubApi.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;


namespace BCApiTest.ValidationTests
{
    public class IDValidationTest
    {
        private readonly IDValidation idValidation;

        public IDValidationTest()
        {
            idValidation = new IDValidation();
        }

        [Fact]
        public void NonIntTypeShouldBeFalse()
        {
            Assert.False(idValidation.IsValid(2.12));
        }

        [Fact]
        public void IdGraterThenZeroShouldBeValid()
        {
            var result = idValidation.IsValid(8);
            Assert.True(result);
        }

        [Theory]
        [InlineData(-2)]
        [InlineData(-123)]
        [InlineData(0)]
        public void IdLessThenZeroShouldBeInvalid(int id)
        {
            var result = idValidation.IsValid(id);
            Assert.False(result);
        }

        
    }
}
