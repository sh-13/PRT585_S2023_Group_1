using System;
using _1CommonInfrastructure.Models;
using _2DataAccessLayer.Interfaces;
using _3BusinessLogicLayer.Interfaces;

namespace _3BusinessLogicLayer.Services
{
    public class CityService :  ICityService
    {
        private readonly ICityDal _CityDal;
        public CityService(ICityDal CityDal)
        {
            _CityDal = CityDal;
        }

        public async Task<CityModel?> GetById(int CityId)
        {
            return _CityDal.GetById(CityId);
        }

        public async Task<List<CityModel>> GetAll()
        {
            return _CityDal.GetAll();
        }

        public async Task<int> CreateCity(CityModel City)
        {
            //write validations here
            var newCityId = _CityDal.CreateCity(City);
            return newCityId;
        }

        public async Task UpdateCity(CityModel City)
        {
            //write validations here
            _CityDal.UpdateCity(City);
        }

        public async Task DeleteCity(int CityId)
        {
            try
            {
                _CityDal.DeleteCity(CityId);
            }
            catch (Exception e)
            {
                //_loggingService.WriteLog(LoggingLevel.Error, "Layer", $"Error delete City Id:{CityId}. {e.Message}", e.StackTrace);
            }
        }
    }
}
