

using _1CommonInfrastructure.Models;
using _2DataAccessLayer.Interfaces;
using _3BusinessLogicLayer.Interfaces;

namespace _3BusinessLogicLayer.Services
{
    public class BikeService :  IBikeService
    {
        private readonly IBikeDal _BikeDal;
        //private readonly IBikeBalService _BikeBalService;
        public BikeService(IBikeDal BikeDal
        //ILoggingService loggingService,
        //IBikeDal BikeDal,
        //IAuditDal auditDal
       // IBikeBalanceService balsvc
        ) 
        {
            _BikeDal = BikeDal;
            // _BikeBalService = balsvc;
        }

        public async Task<BikeModel?> GetById(int BikeId)
        {           
            return _BikeDal.GetById(BikeId);
        }

        public async Task<List<BikeModel>> GetAll()
        {            
            return _BikeDal.GetAll();
        }

        public async Task<int> CreateBike(BikeModel Bike)
        {
            //write validations here
            var newBikeId = _BikeDal.CreateBike(Bike);
            return newBikeId;
        }

        public async Task UpdateBike(BikeModel Bike)
        {
            //write validations here 
            _BikeDal.UpdateBike(Bike);
        }

        public async Task DeleteBike(int BikeId)
        {            
            try
            {
                //if(balservice.getBal(BikeId) = 0)
                _BikeDal.DeleteBike(BikeId);
            }
            catch (Exception e)
            {
                //_loggingService.WriteLog(LoggingLevel.Error, "Layer", $"Error delete Bike Id:{BikeId}. {e.Message}", e.StackTrace);
            }
        }
    }
}
