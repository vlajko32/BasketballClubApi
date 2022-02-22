using BasketballClubApi.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BCApiTest.ValidationTests
{
    public class NameValidationTest
    {
        private NameLengthValidation nameValidation;

        public NameValidationTest()
        {
            nameValidation = new NameLengthValidation();
        }

        [Fact]
        public void NonStringTypeShoudlBeFalse()
        {
            Assert.False(nameValidation.IsValid(123));
        }

        [Theory]
        [InlineData("Pera")]
        [InlineData("Stojkovic")]
        [InlineData("Mia")]
        public void NameLongerThenOneCharacterShouldBeTrue(string name)
        {
            var result = nameValidation.IsValid(name);
            Assert.True(result);
        }

        [Theory]
        [InlineData("A")]
        [InlineData("")]
        public void NameShorterThen2CharacterShouldBeFalse(string name)
        {
            var result = nameValidation.IsValid(name);
            Assert.False(result);
        }

        [Fact]
        public void NullNameShoudThrowNullReferenceExeption()
        {
            Assert.Throws<NullReferenceException>(() => nameValidation.IsValid(null));
        }
    }
}
