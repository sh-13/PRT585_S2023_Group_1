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
    public class CarDal : ICarDal
    {
        //private readonly TestDBEntities context;
        private DBEntitiesContext _db;
        public CarDal(DBEntitiesContext dbctx)
        {
            this._db = dbctx; // new TestDBEntities();
        }


        public List<CarModel> GetAll()
        {
            var result = _db.Cars.ToList();

            var returnObject = new List<CarModel>();
            foreach (var item in result)
            {
                returnObject.Add(item.ToCarModel());
            }

            return returnObject;
        }

        public CarModel? GetById(int CarId)
        {
            var result = _db.Cars.SingleOrDefault(x => x.CarId == CarId);
            return result?.ToCarModel();
        }


        public int CreateCar(CarModel Car)
        {
            var newCar = Car.ToCar();
            _db.Cars.Add(newCar);
            _db.SaveChanges();
            return newCar.CarId;
        }


        public void UpdateCar(CarModel Car)
        {
            var existingCar = _db.Cars
                .SingleOrDefault(x => x.CarId == Car.CarId);

            if (existingCar == null)
            {
                throw new ApplicationException($"Car {Car.CarId} does not exist.");
            }
            Car.ToCar(existingCar);

            _db.Update(existingCar);
            _db.SaveChanges();
        }

        public void DeleteCar(int CarId)
        {
            var efModel = _db.Cars.Find(CarId);
            _db.Cars.Remove(efModel);
            _db.SaveChanges();
        }

    }

}
