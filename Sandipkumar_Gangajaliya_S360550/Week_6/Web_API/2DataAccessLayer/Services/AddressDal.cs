using _1CommonInfrastructure.Models;
using _2DataAccessLayer.Context;
using _2DataAccessLayer.Context.Models;
using _2DataAccessLayer.Interfaces;
using _2DataAccessLayer.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DataAccessLayer.Services
{
    public class AddressDal : IAddressDal
    {
        //private readonly TestDBEntities context;
        private DBEntitiesContext _db;
        public AddressDal(DBEntitiesContext dbctx)
        {
            this._db = dbctx; // new TestDBEntities();
        }


        public List<AddressModel> GetAll()
        {
            var result = _db.Addresses.ToList();

            var returnObject = new List<AddressModel>();
            foreach (var item in result)
            {
                returnObject.Add(item.ToAddressModel());
            }

            return returnObject;
        }

        public AddressModel? GetById(int AddressId)
        {
            var result = _db.Addresses.SingleOrDefault(x => x.AddressId == AddressId);
            return result?.ToAddressModel();
        }


        public int CreateAddress(AddressModel Address)
        {
            var newAddress = Address.ToAddress();
            _db.Addresses.Add(newAddress);
            _db.SaveChanges();
            return newAddress.AddressId;
        }


        public void UpdateAddress(AddressModel Address)
        {
            var existingAddress = _db.Addresses
                .SingleOrDefault(x => x.AddressId == Address.AddressId);

            if (existingAddress == null)
            {
                throw new ApplicationException($"Address {Address.AddressId} does not exist.");
            }
            Address.ToAddress(existingAddress);

            _db.Update(existingAddress);
            _db.SaveChanges();
        }

        public void DeleteAddress(int AddressId)
        {
            var efModel = _db.Addresses.Find(AddressId);
            _db.Addresses.Remove(efModel);
            _db.SaveChanges();


        }

    }
}
