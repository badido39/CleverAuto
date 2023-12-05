using CleverAuto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleverAuto.Services
{
    public class ProductService
    {
    }


    public interface IProductService
    {
        public Task<List<Service>> GetServicesAsync();
        public void AddService(Service   service);
        public void UpdateService(Service service);
        public Task<Service> GetServiceById(int serviceId);
    }
}
