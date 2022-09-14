using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sumera_Travel_Corporation.Data;
using Sumera_Travel_Corporation.Data.Dtos;
using Sumera_Travel_Corporation.Models;
using Sumera_Travel_Corporation.Services;

namespace Sumera_Travel_Corporation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ICustomerCrudService _CustomerCrudService;

        public CustomersController(ApplicationDbContext context, ICustomerCrudService customerCrudService)
        {
            _context = context;
            _CustomerCrudService = customerCrudService;
        }
      
        // GET: api/Customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerDto>>> GetCustomers()
        {
            var customers = await _CustomerCrudService.GetCustomersAsync();
            return customers;


        }

        // GET: api/Customers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerDto>> GetCustomer(int id)
        {
            var customer = await _CustomerCrudService.GetCustomerAsync(id);

            return customer;
        }
       

        // PUT: api/Customers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> PutCustomer( CustomerDto customerdto)
        {
            try
            {
                await _CustomerCrudService.PutCustomerAsync(customerdto);
                return Ok(customerdto);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/Customers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomerAsync(CustomerDto customer)
        {
            await _CustomerCrudService.PostCustomerAsync(customer);
            return CreatedAtAction("GetCustomer", new { id = customer.CustomerId }, customer);
        }

            // DELETE: api/Customers/5
            [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
          await _CustomerCrudService.DeleteCustomerAsync(id);
            return Ok();
        }

      
    }
}
