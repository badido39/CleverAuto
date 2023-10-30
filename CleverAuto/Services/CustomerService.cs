using CleverAuto.Helpers;
using CleverAuto.Models;
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
    public class CustomerService : ICustomerServiceRemote
    {
        private readonly HttpClientInstance _httpClientInstance;

        public CustomerService(HttpClientInstance httpClientInstance)
        {
            _httpClientInstance = httpClientInstance;
        }

        public async Task AddCustomer(Customer customer)
        {
            try
            {
                var jsonCustomer = JsonConvert.SerializeObject(customer);
                var content = new StringContent(jsonCustomer, Encoding.UTF8, "application/json");

                var response = await _httpClientInstance.GetHttpClientInstance().PostAsync("api/Customer/CreateCustomerWithCarAndService", content);

                response.EnsureSuccessStatusCode(); // Throw if not a success code

                // Handle response if needed
                var responseContent = await response.Content.ReadAsStringAsync();
                Debug.WriteLine(responseContent);
            }
            catch (HttpRequestException e)
            {
                // Handle exception
                Debug.WriteLine($"Request failed: {e.Message}");
            }
        }

        public async Task<List<Customer>> GetAllCustomerAsync( )
        {
            try
            {
               
               
                HttpResponseMessage response = await _httpClientInstance.GetHttpClientInstance().GetAsync("api/Customer/GetAllCustomers");


                var result = await response.Content.ReadAsStringAsync();

                List<Customer> Customers = JsonConvert.DeserializeObject<List<Customer>>(result);
                return Customers;
            }
            catch (Exception ex)
            {

                return null;
            }
            
        }
    }
    public interface ICustomerServiceRemote
    {
        public Task<List<Customer>> GetAllCustomerAsync();
        public Task AddCustomer(Customer customer);

    }
}
