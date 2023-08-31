

using _1CommonInfrastructure.Models;
using _2DataAccessLayer.Interfaces;
using _3BusinessLogicLayer.Interfaces;

namespace _3BusinessLogicLayer.Services
{
    public class CarService :  ICarService
    {
        private readonly ICarDal _CarDal;
        //private readonly ICarBalService _CarBalService;
        public CarService(ICarDal CarDal
        //ILoggingService loggingService,
        //ICarDal CarDal,
        //IAuditDal auditDal
       // ICarBalanceService balsvc
        ) 
        {
            _CarDal = CarDal;
            // _CarBalService = balsvc;
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
                //if(balservice.getBal(CarId) = 0)
                _CarDal.DeleteCar(CarId);
            }
            catch (Exception e)
            {
                //_loggingService.WriteLog(LoggingLevel.Error, "Layer", $"Error delete Car Id:{CarId}. {e.Message}", e.StackTrace);
            }
        }
    }
}
