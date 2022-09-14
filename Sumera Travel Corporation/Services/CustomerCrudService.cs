using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sumera_Travel_Corporation.Data;
using Sumera_Travel_Corporation.Data.Dtos;
using Sumera_Travel_Corporation.Models;

namespace Sumera_Travel_Corporation.Services
{
    public class CustomerCrudService:ICustomerCrudService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CustomerCrudService(ApplicationDbContext newvariable, IMapper newmapper)
        {
            _context = newvariable;
            _mapper = newmapper;
        }

        public async Task DeleteCustomerAsync(int id)
        {
            var delcustomer = await _context.Customers.SingleAsync(c => c.CustomerId == id);
            _context.Customers.Remove(delcustomer);
            await _context.SaveChangesAsync();
        }

        public async Task<CustomerDto> GetCustomerAsync(int id)
        {
            var customer = await _context.Customers.FindAsync(id);

            var customerdto = _mapper.Map<CustomerDto>(customer);
            return customerdto;
        }

        public async Task<List<CustomerDto>> GetCustomersAsync()
        {
            try
            {
            var customers = await _context.Customers.ToListAsync();
              
            var customerdto = customers.Select(d => _mapper.Map<CustomerDto>(d)).ToList();

            return customerdto;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task PostCustomerAsync(CustomerDto customer1)
        {
            var postcustomer=_mapper.Map<Customer>(customer1);
            _context.Add(postcustomer);
            await _context.SaveChangesAsync();

            
        }

     

        public async Task PutCustomerAsync( CustomerDto customerdto)
        {
            var putcustomer = _mapper.Map<Customer>(customerdto);
             _context.Customers.Update(putcustomer);
            await _context.SaveChangesAsync();
        }
    }

       
    }

