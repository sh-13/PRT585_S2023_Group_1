using System;
using _1CommonInfrastructure.Models;
using _2DataAccessLayer.Interfaces;
using _3BusinessLogicLayer.Interfaces;

namespace _3BusinessLogicLayer.Services
{
    public class AddressService :  IAddressService
    {
        private readonly IAddressDal _AddressDal;
        public AddressService(IAddressDal AddressDal)
        {
            _AddressDal = AddressDal;
        }

        public async Task<AddressModel?> GetById(int AddressId)
        {
            return _AddressDal.GetById(AddressId);
        }

        public async Task<List<AddressModel>> GetAll()
        {
            return _AddressDal.GetAll();
        }

        public async Task<int> CreateAddress(AddressModel Address)
        {
            //write validations here
            var newAddressId = _AddressDal.CreateAddress(Address);
            return newAddressId;
        }

        public async Task UpdateAddress(AddressModel Address)
        {
            //write validations here
            _AddressDal.UpdateAddress(Address);
        }

        public async Task DeleteAddress(int AddressId)
        {
            try
            {
                _AddressDal.DeleteAddress(AddressId);
            }
            catch (Exception e)
            {
                //_loggingService.WriteLog(LoggingLevel.Error, "Layer", $"Error delete Address Id:{AddressId}. {e.Message}", e.StackTrace);
            }
        }
    }
}
