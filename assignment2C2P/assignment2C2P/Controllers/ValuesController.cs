using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using assignment2C2P.Infrastructure.EF.Repositories;
using assignment2C2P.Models.Customers;
using assignment2C2P.Models.Responses;
using assignment2C2P.Validations;
using Microsoft.AspNetCore.Mvc;

namespace assignment2C2P.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private IRepository repository;
        private IValidation validation;

        public ValuesController(IRepository repository, IValidation validation)
        {
            this.repository = repository;
            this.validation = validation;
        }

        [HttpPost("GetByCustomerId")]
        public async Task<ActionResult<Response<CustomerDto>>> GetByCustomerId(int customerId)
        {
            var validateTest = validation.ValidateCustomerId(customerId);
            if (validateTest.Success != true)
            {
                var errorMessage = Response<CustomerDto>.SendResposeError(validateTest);
                return BadRequest(errorMessage);
            }

            var customer = await repository.GetByCustomerId(customerId);
            if (customer != null)
            {
                var dto = customer.CustomerToDto();
                var response = Response<CustomerDto>.SendRespose(dto, true);
                return response;
            }
            return NotFound();
        }

        [HttpPost("GetByEmail")]
        public async Task<ActionResult<Response<CustomerDto>>> GetByEmail(string email)
        {
            var validateTest = validation.ValidateEmail(email);
            if (validateTest.Success != true)
            {
                var errorMessage = Response<CustomerDto>.SendResposeError(validateTest);
                return BadRequest(errorMessage);
            }

            var customer = await repository.GetByEmail(email);
            if (customer != null)
            {
                var dto = customer.CustomerToDto();
                var response = Response<CustomerDto>.SendRespose(dto, true);
                return response;
            }
            return NotFound();
        }

        [HttpPost("GetByCustomerIdAndEmail")]
        public async Task<ActionResult<Response<CustomerDto>>> GetByCustomerIdAndEmail(int customerId, string email)
        {
            var validateTest = validation.ValidateCustomerIdAndEmail(email, customerId);
            if (validateTest.Success != true)
            {
                var errorMessage = Response<CustomerDto>.SendResposeError(validateTest);
                return BadRequest(errorMessage);
            }

            var customer = await repository.GetByCustomerIdAndEmail(customerId, email);
            if (customer != null)
            {
                var dto = customer.CustomerToDto();
                var response = Response<CustomerDto>.SendRespose(dto, true);
                return response;
            }
            return NotFound();
        }

    }
}
