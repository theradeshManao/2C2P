using assignment2C2P.Models.ValidationTests;

namespace assignment2C2P.Validations
{
    public interface IValidation
    {
        ValidationTest ValidateCustomerId(int customerId);
        ValidationTest ValidateEmail(string email);
        ValidationTest ValidateCustomerIdAndEmail(string email, int customerId);
    }
}
