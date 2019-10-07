using assignment2C2P.Models.ValidationTests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace assignment2C2P.Validations
{
    public class Validation : IValidation
    {
        const string NO_INQUIRY_CRITERIA = "No inquiry criteria";
        const string INVALID_CUSTOMER_ID = "Invalid Customer ID";
        const string INVALID_EMAIL = "Invalid Email";

        bool success;
        string message;

        public Validation()
        {
            success = true;
            message = "";
        }

        public ValidationTest ReturnValidationTest(bool success, string message)
        {
            return new ValidationTest()
            {
                Success = success,
                Message = message
            };
        }

        public ValidationTest ValidateCustomerId(int customerId)
        {

            if (customerId < 0)
            {
                success = false;
                message = INVALID_CUSTOMER_ID;
                return ReturnValidationTest(success, message);
            }
            return ReturnValidationTest(success, message);
        }

        public ValidationTest ValidateEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                success = false;
                message = NO_INQUIRY_CRITERIA;
                return ReturnValidationTest(success, message);
            }
            else
            {
                try
                {
                    MailAddress m = new MailAddress(email);
                    return ReturnValidationTest(success, message);
                }
                catch (FormatException)
                {
                    success = false;
                    message = INVALID_EMAIL;
                    return ReturnValidationTest(success, message);
                }
            }
        }

        public ValidationTest ValidateCustomerIdAndEmail(string email, int customerId)
        {
            if (string.IsNullOrEmpty(email) && customerId == 0)
            {
                success = false;
                message = NO_INQUIRY_CRITERIA;
                return ReturnValidationTest(success, message);
            }

            if (!ValidateCustomerId(customerId).Success)
            {
                return ValidateCustomerId(customerId);
            }
            if (!ValidateEmail(email).Success)
            {
                return ValidateEmail(email);
            }
            return ReturnValidationTest(success, message);
        }
    }
}
