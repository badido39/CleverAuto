using CleverAuto.Data;
using CleverAuto.Helpers;
using CleverAuto.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CleverAuto.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly AppDbContext _dbContext;

        public CustomerService(AppDbContext dbContext)
        {

            _dbContext = dbContext;
        }

        public  void AddCustomer(Customer customer)
        {
            _dbContext.Customers.Add(customer);
            _dbContext.SaveChanges();
        }

        public Task<Customer[]> GetAllCustomerAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Customer> GetCustomerById(int customerId)
        {
            return Task.FromResult(_dbContext.Customers.Include(x=>x.Cars).FirstOrDefault(x => x.Id == customerId));
        }

        public Task<List<Customer>> GetCustomersAsync()
        {
            return Task.FromResult( _dbContext.Customers.Include(x=>x.Cars).ThenInclude(x=>x.Services).ToList());;
        }

        public void UpdateCustomer(Customer customer)
        {
            _dbContext.Customers.Update(customer);
            _dbContext.SaveChanges();
        }
    }
    public interface ICustomerService
    {
        public Task<Customer[]> GetAllCustomerAsync();
        public void AddCustomer(Customer customer);
        public void UpdateCustomer(Customer customer);
        public Task<List<Customer>> GetCustomersAsync();
        public Task<Customer> GetCustomerById(int customerId);

    }
}
