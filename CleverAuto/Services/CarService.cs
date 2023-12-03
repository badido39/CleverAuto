using CleverAuto.Data;
using CleverAuto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleverAuto.Services
{
    public class CarService : ICarService
    {
        private readonly AppDbContext _dbContext;

        public CarService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

       
        public void AddCar(int CustomerId, Car car)
        {
            _dbContext.Cars.Add(car);
            _dbContext.SaveChanges ();
        }

        public Task<List<Car>> GetCarsByCustomerId(int customerId)
        {
                return Task.FromResult( _dbContext.Cars.Where(x=>x.CustomerId == customerId).ToList());
        }

        public void UpdateCar(Car car)
        {
            _dbContext.Cars.Update(car);
            _dbContext.SaveChanges();
        }
    }

    public interface ICarService
    {
        public void AddCar(int CustomerId ,Car car);
        public void UpdateCar(Car car);
        public Task<List<Car>> GetCarsByCustomerId(int customerId);


        
        

    }
}
