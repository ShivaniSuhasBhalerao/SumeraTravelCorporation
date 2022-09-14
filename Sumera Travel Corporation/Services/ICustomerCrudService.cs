using Microsoft.AspNetCore.Mvc;
using Sumera_Travel_Corporation.Data.Dtos;
using Sumera_Travel_Corporation.Models;

namespace Sumera_Travel_Corporation.Services
{
    public interface ICustomerCrudService
    {
        public Task<List<CustomerDto>> GetCustomersAsync();

        public Task<CustomerDto> GetCustomerAsync(int id);

        public Task PutCustomerAsync(CustomerDto customer);

        public Task PostCustomerAsync(CustomerDto customer);

        public Task DeleteCustomerAsync(int id);
       
    }
}
