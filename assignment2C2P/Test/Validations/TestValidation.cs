using assignment2C2P.Validations;
using System;
using Xunit;

namespace Test
{
    public class TestValidation
    {
        const string NO_INQUIRY_CRITERIA = "No inquiry criteria";
        const string INVALID_CUSTOMER_ID = "Invalid Customer ID";
        const string INVALID_EMAIL = "Invalid Email";

        [Fact]
        public void GetByCustomerId_ShouldAllow_Positive()
        {
            var customerId = 1;
            var validate = new Validation();
            var result = validate.ValidateCustomerId(customerId);
            Assert.True(result.Success);
        }

        [Fact]
        public void GetByCustomerId_ShouldNotAllow_Negative()
        {
            var customerId = -1;
            var validate = new Validation();
            var result = validate.ValidateCustomerId(customerId);
            Assert.False(result.Success);
            Assert.Equal(result.Message, INVALID_CUSTOMER_ID);
        }

        [Fact]
        public void GetByCustomerId_ShouldNotAllow_ZeroOrEmpty()
        {
            var customerId = 0;
            var validate = new Validation();
            var result = validate.ValidateCustomerId(customerId);
            Assert.False(result.Success);
            Assert.Equal(result.Message, INVALID_CUSTOMER_ID);
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
            Assert.Equal(result.Message, INVALID_EMAIL);
        }

        [Fact]
        public void GetByEmail_ShouldNotAllow_Empty()
        {
            var email = string.Empty;
            var validate = new Validation();
            var result = validate.ValidateEmail(email);
            Assert.False(result.Success);
            Assert.Equal(result.Message, INVALID_EMAIL);
        }


        [Fact]
        public void GetByCustomerIdAndEmail_ShouldAllow_ValidCustomerIdAndValidEmail()
        {
            var email = "user@domain.com";
            var customerId = 1;
            var validate = new Validation();
            var result = validate.ValidateCustomerIdAndEmail(email, customerId);
            Assert.True(result.Success);
        }

        [Fact]
        public void GetByCustomerIdAndEmail_ShouldNotAllow_InValidCustomerIdAndValidEmail()
        {
            var email = "user@domain.com";
            var customerId = -1;
            var validate = new Validation();
            var result = validate.ValidateCustomerIdAndEmail(email, customerId);
            Assert.False(result.Success);
            Assert.Equal(result.Message, INVALID_CUSTOMER_ID);
        }

        [Fact]
        public void GetByCustomerIdAndEmail_ShouldNotAllow_ValidCustomerIdAndInValidEmail()
        {
            var email = "userdomain.com";
            var customerId = 1;
            var validate = new Validation();
            var result = validate.ValidateCustomerIdAndEmail(email, customerId);
            Assert.False(result.Success);
            Assert.Equal(result.Message, INVALID_EMAIL);
        }

        [Fact]
        public void GetByCustomerIdAndEmail_ShouldNotAllow_InValidCustomerIdAndInValidEmail()
        {
            var email = "user@domain.com";
            var customerId = -1;
            var validate = new Validation();
            var result = validate.ValidateCustomerIdAndEmail(email, customerId);
            Assert.False(result.Success);
            Assert.Equal(result.Message, INVALID_CUSTOMER_ID);
        }

        [Fact]
        public void GetByCustomerIdAndEmail_ShouldNotAllow_CustomerIdAndEmailAreEmpty()
        {
            var email = string.Empty;
            var customerId = 0;
            var validate = new Validation();
            var result = validate.ValidateCustomerIdAndEmail(email, customerId);
            Assert.False(result.Success);
            Assert.Equal(result.Message, NO_INQUIRY_CRITERIA);
        }
    }
}
