﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using assignment2C2P.Infrastructure.EF.Repositories;
using assignment2C2P.Models.Customers;
using Microsoft.AspNetCore.Mvc;

namespace assignment2C2P.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private IRepository repository;

        public ValuesController(IRepository repository)
        {
            this.repository = repository;
        }

        [HttpPost("GetByCustomerId")]
        public async Task<ActionResult<Customer>> GetByCustomerId(int customerId)
        {
            var customer = await repository.GetByCustomerId(customerId);
            if (customer != null)
            {
                return customer;
            }
            return NotFound();
        }

        [HttpPost("GetByEmail")]
        public async Task<ActionResult<Customer>> GetByEmail(string email)
        {
            var customer = await repository.GetByEmail(email);
            if (customer != null)
            {
                return customer;
            }
            return NotFound();
        }

        [HttpPost("GetByCustomerIdAndEmail")]
        public async Task<ActionResult<Customer>> GetByCustomerIdAndEmail(int customerId, string email)
        {
            var customer = await repository.GetByCustomerIdAndEmail(customerId, email);
            if (customer != null)
            {
                return customer;
            }
            return NotFound();
        }

    }
}
