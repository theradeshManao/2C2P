using assignment2C2P.Models.ValidationTests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace assignment2C2P.Validations
{
    public interface IValidation
    {
        ValidationTest ValidateCustomerId(int customerId);
        ValidationTest ValidateEmail(string email);
        ValidationTest ValidateCustomerIdAndEmail(string email, int customerId);
    }
}
