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
    public class CityDal : ICityDal
    {
        //private readonly TestDBEntities context;
        private DBEntitiesContext _db;
        public CityDal(DBEntitiesContext dbctx)
        {
            this._db = dbctx; // new TestDBEntities();
        }


        public List<CityModel> GetAll()
        {
            var result = _db.Cities.ToList();

            var returnObject = new List<CityModel>();
            foreach (var item in result)
            {
                returnObject.Add(item.ToCityModel());
            }

            return returnObject;
        }

        public CityModel? GetById(int CityId)
        {
            var result = _db.Cities.SingleOrDefault(x => x.CityId == CityId);
            return result?.ToCityModel();
        }


        public int CreateCity(CityModel City)
        {
            var newCity = City.ToCity();
            _db.Cities.Add(newCity);
            _db.SaveChanges();
            return newCity.CityId;
        }


        public void UpdateCity(CityModel City)
        {
            var existingCity = _db.Cities
                .SingleOrDefault(x => x.CityId == City.CityId);

            if (existingCity == null)
            {
                throw new ApplicationException($"City {City.CityId} does not exist.");
            }
            City.ToCity(existingCity);

            _db.Update(existingCity);
            _db.SaveChanges();
        }

        public void DeleteCity(int CityId)
        {
            var efModel = _db.Cities.Find(CityId);
            _db.Cities.Remove(efModel);
            _db.SaveChanges();


        }

    }
}
