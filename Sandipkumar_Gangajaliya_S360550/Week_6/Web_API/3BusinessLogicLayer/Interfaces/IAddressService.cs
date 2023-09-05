using _1CommonInfrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3BusinessLogicLayer.Interfaces
{
	public interface IAddressService
	{
        Task<AddressModel?> GetById(int AddressId);
        Task<List<AddressModel>> GetAll();

        Task<int> CreateAddress(AddressModel Address);
        Task UpdateAddress(AddressModel Address);
        Task DeleteAddress(int AddressId);
    }
}
