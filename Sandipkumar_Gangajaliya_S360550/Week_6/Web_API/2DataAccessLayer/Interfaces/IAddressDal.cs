using _1CommonInfrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DataAccessLayer.Interfaces
{
	public interface IAddressDal
	{
        // Getters
        AddressModel? GetById(int AddressId);
        List<AddressModel> GetAll();

        // Actions
        int CreateAddress(AddressModel Address);
        void UpdateAddress(AddressModel Address);
        void DeleteAddress(int AddressId);
    }
}