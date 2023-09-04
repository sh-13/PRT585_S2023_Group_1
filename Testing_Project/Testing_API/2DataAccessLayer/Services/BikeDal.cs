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
    public class BikeDal : IBikeDal
    {
        //private readonly TestDBEntities context;
        private DBEntitiesContext _db;
        public BikeDal(DBEntitiesContext dbctx)
        {
            this._db = dbctx; // new TestDBEntities();
        }


        public List<BikeModel> GetAll()
        {
            var result = _db.Bikes.ToList();

            var returnObject = new List<BikeModel>();
            foreach (var item in result)
            {
                returnObject.Add(item.ToBikeModel());
            }

            return returnObject;
        }

        public BikeModel? GetById(int BikeId)
        {
            var result = _db.Bikes.SingleOrDefault(x => x.BikeId == BikeId);
            return result?.ToBikeModel();
        }


        public int CreateBike(BikeModel Bike)
        {
            var newBike = Bike.ToBike();
            _db.Bikes.Add(newBike);
            _db.SaveChanges();
            return newBike.BikeId;
        }


        public void UpdateBike(BikeModel Bike)
        {
            var existingBike = _db.Bikes
                .SingleOrDefault(x => x.BikeId == Bike.BikeId);

            if (existingBike == null)
            {
                throw new ApplicationException($"Bike {Bike.BikeId} does not exist.");
            }
            Bike.ToBike(existingBike);

            _db.Update(existingBike);
            _db.SaveChanges();
        }

        public void DeleteBike(int BikeId)
        {
            var efModel = _db.Bikes.Find(BikeId);
            _db.Bikes.Remove(efModel);
            _db.SaveChanges();


        }

    }

}
