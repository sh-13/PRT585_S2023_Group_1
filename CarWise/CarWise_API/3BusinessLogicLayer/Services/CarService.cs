using _1CommonInfrastructure.Models;
using _2DataAccessLayer.Interfaces;
using _3BusinessLogicLayer.Interfaces;

namespace _3BusinessLogicLayer.Services
{
    public class CarService :  ICarService
    {
        private readonly ICarDal _CarDal;
        public CarService(ICarDal CarDal) 
        {
            _CarDal = CarDal;
        }

        public async Task<CarModel?> GetById(int CarId)
        {           
            return _CarDal.GetById(CarId);
        }

        public async Task<List<CarModel>> GetAll()
        {            
            return _CarDal.GetAll();
        }

        public async Task<int> CreateCar(CarModel Car)
        {
            //write validations here
            var newCarId = _CarDal.CreateCar(Car);
            return newCarId;
        }

        public async Task UpdateCar(CarModel Car)
        {
            //write validations here 
            _CarDal.UpdateCar(Car);
        }

        public async Task DeleteCar(int CarId)
        {            
            try
            {
                _CarDal.DeleteCar(CarId);
            }
            catch (Exception e)
            {
            }
        }
    }
}
