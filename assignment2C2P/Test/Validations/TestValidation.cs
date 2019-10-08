using assignment2C2P.Validations;
using System;
using Xunit;

namespace Test
{
    public class TestValidation
    {
        [Fact]
        public void GetByCustomerId_ShouldAllow_Positive()
        {
            var id = 1;
            var validate = new Validation();
            var result = validate.ValidateCustomerId(id);
            Assert.True(result.Success);
        }

        [Fact]
        public void GetByCustomerId_ShouldNotAllow_Negative()
        {
            var id = -1;
            var validate = new Validation();
            var result = validate.ValidateCustomerId(id);
            Assert.False(result.Success);
        }

        [Fact]
        public void GetByCustomerId_ShouldNotAllow_Empty()
        {
            var id = 0;
            var validate = new Validation();
            var result = validate.ValidateCustomerId(id);
            Assert.False(result.Success);
        }

        [Fact]
        public void GetByEmail_ShouldAllow_ValidEmail()
        {
            var email = "user@domain.com";
            var validate = new Validation();
            var result = validate.ValidateEmail(email);
            Assert.True(result.Success);
        }

        [Fact]
        public void GetByEmail_ShouldNotAllow_InvalidEmail()
        {
            var email = "userdomain.com";
            var validate = new Validation();
            var result = validate.ValidateEmail(email);
            Assert.False(result.Success);
        }
    }
}
