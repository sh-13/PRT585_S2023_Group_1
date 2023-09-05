using _1CommonInfrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DataAccessLayer.Interfaces
{
    public interface ICarDal
    {
        // Getters
        CarModel? GetById(int CarId);
        List<CarModel> GetAll();

        // Actions
        int CreateCar(CarModel Car);
        void UpdateCar(CarModel Car);
        void DeleteCar(int CarId);
    }
}
