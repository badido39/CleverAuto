using CleverAuto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleverAuto.Services
{
    public class CustomerService : ICustomerServiceLocal
    {
        public Task<Customer[]> GetCustomerAsync(DateTime startDate)
        {
            throw new NotImplementedException();
        }
    }
    public interface ICustomerServiceLocal
    {
        public Task<Customer[]> GetCustomerAsync(DateTime startDate);

    }
}
